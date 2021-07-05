using System;
using System.Collections.Generic;
using System.Text;
using BookSoft.Domain.Models;

namespace Reception.EventArgs
{
   public class SelectedGuestEventArgs : System.EventArgs
   {
        public Guest Guest { get; set; }
   }
}
