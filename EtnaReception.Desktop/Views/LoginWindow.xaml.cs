using EtnaReception.Desktop.Events;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EtnaReception.Desktop.Views
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow(IEventAggregator eventAggregator)
        {
            InitializeComponent();
            eventAggregator.GetEvent<LoginEvent>().Subscribe(OnLogin);
        }

        private void OnLogin(bool success)
        {
            DialogResult = success;
        }
    }
}
