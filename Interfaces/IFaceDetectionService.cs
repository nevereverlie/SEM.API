using System.Threading.Tasks;
using System.Drawing;

namespace SEM.API.Interfaces
{
    public interface IFaceDetectionService
    {
        bool IsFaceDetected(Image image, int userId);
    }
}