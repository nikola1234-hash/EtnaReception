using System;
using System.Collections.Generic;
using System.Text;
using BookSoft.Domain.Models;
using Reception.EventArgs;

namespace Reception.Mediator
{
    public class SelectedGuestChange
    {
        private SelectedGuestChange() { }
        private static SelectedGuestChange _instance = new SelectedGuestChange();

        public static SelectedGuestChange GetIstance()
        {
            return _instance;
        }

        public event EventHandler<SelectedGuestEventArgs> SelectedGuestHasChanged;

        public void OnSelectedGuestChanged(object sender, Guest guest)
        {
            var selectedGuestDelegate = SelectedGuestHasChanged as EventHandler<SelectedGuestEventArgs>;
            if (selectedGuestDelegate != null)
            {
                selectedGuestDelegate(this, new SelectedGuestEventArgs {Guest = guest});
            }
        }


    }
}
