using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using BookSoft.BLL.Services;
using BookSoft.Domain.Models;
using Prism.Events;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using Reception.Services;
using Syncfusion.UI.Xaml.Scheduler;
using Syncfusion.Windows.Shared;

namespace Reception.ViewModels
{
    public class SchedulerViewModel : BindableBase
    {
        private readonly IDialogService _dialogService;

        private readonly IReceptionService _receptionService;
        private readonly IStatusColor _statusColor;

        private ScheduleAppointmentCollection _events;
        private ObservableCollection<object> _resources;

        public SchedulerViewModel(IDialogService dialogService, IStatusColor statusColor)
        {
            _dialogService = dialogService;
            _statusColor = statusColor;
        }

        public SchedulerViewModel(IReceptionService receptionService, IEventAggregator eventAggregator,
            IDialogService dialogService, IStatusColor statusColor)
        {
            _receptionService = receptionService;
            _dialogService = dialogService;
            _statusColor = statusColor;
            InitializeResources();
            InitializeBookings();
            DeleteBookingCommand = new DelegateCommand<object>(ExecuteDelete);
            OpenEditor = new DelegateCommand<object>(ExecuteOpenEditor);
        }

        public ScheduleAppointmentCollection Events
        {
            get => _events;
            set => SetProperty(ref _events, value);
        }

        public ObservableCollection<object> Resources
        {
            get => _resources;
            set => SetProperty(ref _resources, value);
        }

        public ICommand DeleteBookingCommand { get; }
        public ICommand OpenEditor { get; }

        private void ExecuteOpenEditor(object obj)
        {
            var e = obj as AppointmentEditorOpeningEventArgs;
            var id = new object();
            e.Cancel = true;
            //if (e.DateTime.Date < DateTime.Now.Date)
            //{
            //    //TODO: Some awesome message notification
            //    return;
            //}
            if (e.Appointment is null)
            {
                var p = new DialogParameters();
                p.Add("dolazak", e.DateTime);
                _dialogService.ShowDialog("CreateNewReservationDialog", p, result => { });
            }

            if (e.Appointment != null)
            {
                var d = e.Appointment.ResourceIdCollection.FirstOrDefault();
                var p = (RoomScheduler) d;
                var parameters = new DialogParameters();
                parameters.Add("roomScheduler", p);
                _dialogService.ShowDialog("EditReservationDialogView", parameters, result => { });
            }
        }

        private void ExecuteDelete(object appointment)
        {
            var e = appointment as AppointmentDeletingEventArgs;
            if (e.Appointment.Id != null)
            {
                var result = MessageBox.Show("Da li ste sigurni da zelite da otkazete rezervaciju?", "",
                    MessageBoxButton.YesNo);
                var i = e.Appointment.ResourceIdCollection.FirstOrDefault();
                if (result == MessageBoxResult.Yes)
                {
                    var room = (RoomScheduler) i;
                    if (room != null)
                    {
                        var rowsAffected = _receptionService.CancelReservation(room.ReservationId);
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
                var obj = new SchedulerResource
                {
                    Name = room.RoomNumber,
                    Foreground = new SolidColorBrush((Color) ColorConverter.ConvertFromString("#FFFFFF")),
                    Background = new SolidColorBrush((Color) ColorConverter.ConvertFromString("#9d65c9")),
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
                if (item.StartDate != null && item.EndDate != null)
                {
                    var color = _statusColor.SetColor(item.ReservationId);
                    var appointments = new ScheduleAppointment
                    {
                        StartTime = (DateTime) item.StartDate,
                        EndTime = (DateTime) item.EndDate,
                        Subject = ScheduleDetailsHelper.FormatSubject(item),
                        Notes = ScheduleDetailsHelper.FormatDetails(item),

                        ResourceIdCollection = new ObservableCollection<object> {item, item.Id},
                        AppointmentBackground = new SolidColorBrush(color)
                    };
                    Events.Add(appointments);
                }
        }
    }
}