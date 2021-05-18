using System.Windows.Media;

namespace Reception.Services
{
    public enum StatusType
    {
        NaCekanju = 1,
        Potrvdjeno = 2,
        Realizovano = 3
    }
    public interface IStatusColor
    {
        Color SetColor(int id);
    }
}