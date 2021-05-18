using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Windows.Automation.Peers;
using BookSoft.BLL.Services;
using System.Windows.Media;


namespace Reception.Services
{
    [SuppressMessage("ReSharper", "IdentifierTypo")]
    public class StatusColor : IStatusColor
    {
        private const string NaCekanju = "#2dccff";
        private const string Potvrdjeno = "#fce83a";
        private const string Realizovano = "#56f000";

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
            switch (item.Id)
            {
                case (int)StatusType.NaCekanju:
                    return color = (Color) ColorConverter.ConvertFromString(NaCekanju);
                case (int)StatusType.Potrvdjeno:
                    return color = (Color) ColorConverter.ConvertFromString(Potvrdjeno);
                case (int)StatusType.Realizovano:
                    return color = (Color) ColorConverter.ConvertFromString(Realizovano);
            }
            return color;
        }
    }
}
