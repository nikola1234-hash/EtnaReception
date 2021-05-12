using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using System.Windows.Media;
using BookSoft.BLL.Services;
using Prism.Events;
using Prism.Mvvm;
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

        public SchedulerViewModel()
        {

        }

        public SchedulerViewModel(IReceptionService receptionService, IEventAggregator eventAggregator)
        {
            _receptionService = receptionService;
            InitializeScheduler();
            DeleteBookingCommand = new DelegateCommand<object>(ExecuteDelete);

        }

        private void ExecuteDelete(object appointment)
        {
            var e = appointment as AppointmentDeletingEventArgs;
            if (e.Appointment.Id != null)
            {
                var i = e.Appointment.ResourceIdCollection.FirstOrDefault();
                int id = (int) i;


            }
        }


        private void InitializeScheduler()
        {
            

            Resources = new ObservableCollection<object>();
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

                        ResourceIdCollection = new ObservableCollection<object>() { item.Id },
                        AppointmentBackground = new SolidColorBrush(color: (Color)ColorConverter.ConvertFromString("#FFE671B8"))
                    };
                    Events.Add(appointments);
                }

                var obj = new SchedulerResource()
                {
                    Name = item.RoomNumber,
                    Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFF")),
                    Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#9d65c9")),
                    Id = item.Id
                };
                Resources.Add(obj);
            }
        }
    }
}
