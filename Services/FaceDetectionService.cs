using System.Threading.Tasks;
using Emgu.CV;
using Revisory_Control.API.Interfaces;
using System.Drawing;
using Emgu.CV.Structure;

namespace Revisory_Control.API.Services
{
    public class FaceDetectionService : IFaceDetectionService
    {
        static readonly CascadeClassifier classifier = new CascadeClassifier("Helpers/haarcascade_frontalface_alt_tree.xml");
        public bool IsFaceDetected(Image image, int userId)
        {
            Rectangle[] rectangles = DetectFaces(image);

            if (rectangles.Length > 0) return true;

            else return false;
        }

        private static Rectangle[] DetectFaces(Image image)
        {
            Bitmap bitmap = new Bitmap(image);
            Image<Bgr, byte> grayImage = bitmap.ToImage<Bgr, byte>();
            Rectangle[] rectangles = classifier.DetectMultiScale(grayImage, 1.4, 0);
            return rectangles;
        }
    }
}