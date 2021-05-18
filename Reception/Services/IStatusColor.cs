using System.Windows.Media;

namespace Reception.Services
{
    public interface IStatusColor
    {
        Color LoadColor(int id);
    }
}