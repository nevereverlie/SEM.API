using System.Threading.Tasks;
using System.Drawing;

namespace Revisory_Control.API.Interfaces
{
    public interface IFaceDetectionService
    {
        bool IsFaceDetected(Image image, int userId);
    }
}