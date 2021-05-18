using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Automation.Peers;
using BookSoft.BLL.Services;
using System.Windows.Media;


namespace Reception.Services
{
    public class StatusColor : IStatusColor
    {
        private const string naCekanju = "#2dccff";
        private const string potvrdjeno = "#fce83a";
        private const string realizovano = "#56f000";

        private readonly IReceptionService _receptionService;
        public StatusColor(IReceptionService receptionService)
        {
            _receptionService = receptionService;
        }

        public Color LoadColor(int id)
        {
            Color color = new Color();
            if (id == 0) return color;
            var item = _receptionService.LoadStatusByReservationId(id);
            // ReSharper disable once PossibleNullReferenceException
           
            switch (item.Id)
            {
                case 1:
                    return color = (Color) ColorConverter.ConvertFromString(naCekanju);
                case 2:
                    return color = (Color) ColorConverter.ConvertFromString(potvrdjeno);
                case 3:
                    return color = (Color) ColorConverter.ConvertFromString(realizovano);
            }

            return color;
        }
    }
}
