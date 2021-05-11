using System;
using System.Collections.ObjectModel;
using System.Windows.Media;
using BookSoft.BLL.Services;
using Prism.Mvvm;
using Prism.Regions;
using Reception.Services;
using Syncfusion.UI.Xaml.Scheduler;

namespace Reception.ViewModels
{
    public class ReceptionViewModel : BindableBase, INavigationAware
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

        public ReceptionViewModel(IReceptionService receptionService)
        {
            _receptionService = receptionService;
        }

        private void Clear()
        {
            Events.Clear();
            Resources.Clear();
        }
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return false;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            Clear();
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            InitializeScheduler();
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

