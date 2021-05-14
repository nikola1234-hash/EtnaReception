using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using BookSoft.BLL.Services;
using BookSoft.Domain.Models;
using Prism.Events;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using Reception.Events;
using Reception.Services;
using Syncfusion.UI.Xaml.Scheduler;
using Syncfusion.Windows.Shared;

namespace Reception.ViewModels
{
    public class SchedulerViewModel : BindableBase
    {

        private ScheduleAppointmentCollection _events;
        public ScheduleAppointmentCollection Events
        {
            get => _events;
            set => SetProperty(ref _events, value);
        }
        private ObservableCollection<object> _resources;
        public ObservableCollection<object> Resources
        {
            get => _resources;
            set => SetProperty(ref _resources, value);
        }

        private readonly IReceptionService _receptionService;
        public ICommand DeleteBookingCommand { get; }
        public ICommand OpenEditor { get; }
        private readonly IDialogService _dialogService;
        public SchedulerViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;
        }

        public SchedulerViewModel(IReceptionService receptionService, IEventAggregator eventAggregator, IDialogService dialogService)
        {
            _receptionService = receptionService;
            _dialogService = dialogService;
            InitializeResources();
            InitializeBookings();
            DeleteBookingCommand = new DelegateCommand<object>(ExecuteDelete);
            OpenEditor = new DelegateCommand<object>(ExecuteOpenEditor);

        }

        private void ExecuteOpenEditor(object obj)
        {
            var e = obj as AppointmentEditorOpeningEventArgs;
            e.Cancel = true;
            if (e.Appointment is null)
            {
                var p = new DialogParameters();
                p.Add("dolazak", e.DateTime);

                _dialogService.ShowDialog("CreateNewReservationDialog", p, result => {});
            }

        }

        private void ExecuteDelete(object appointment)
        {
            var e = appointment as AppointmentDeletingEventArgs;
            if (e.Appointment.Id != null)
            {
                var result = MessageBox.Show("Da li ste sigurni da zelite da otkazete rezervaciju?","",
                    MessageBoxButton.YesNo);
                var i = e.Appointment.ResourceIdCollection.FirstOrDefault();
                if (result == MessageBoxResult.Yes)
                {
                    var room = (RoomScheduler)i;
                    if (room != null)
                    {
                        int rowsAffected = _receptionService.CancelReservation(room.ReservationId);
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Uspesno izbrisana rezervacija");
                            Events.Clear();
                            InitializeBookings();
                        }
                    }
                 
                }
            }
        }

        private void InitializeResources()
        {
            Resources = new ObservableCollection<object>();
            var roomResources = _receptionService.LoadRoomResource();

            foreach (var room in roomResources)
            {
                var obj = new SchedulerResource()
                {
                    Name = room.RoomNumber,
                    Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFF")),
                    Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#9d65c9")),
                    Id = room.Id
                };
                Resources.Add(obj);
            }
        }


        private void InitializeBookings()
        {
            
            Events = new ScheduleAppointmentCollection();
            var reservation = _receptionService.LoadRoomScheduler();
           

            foreach (var item in reservation)
            {
                if (item.StartDate != null && item.EndDate != null)
                {

                    var appointments = new ScheduleAppointment()
                    {
                        StartTime = (DateTime)item.StartDate,
                        EndTime = (DateTime)item.EndDate,
                        Subject = ScheduleDetailsHelper.FormatSubject(item),
                        Notes = ScheduleDetailsHelper.FormatDetails(item),

                        ResourceIdCollection = new ObservableCollection<object>() { item, item.Id },
                        AppointmentBackground = new SolidColorBrush(color: (Color)ColorConverter.ConvertFromString("#FFE671B8"))
                    };
                    Events.Add(appointments);
                }
            }
        }
    }
}
