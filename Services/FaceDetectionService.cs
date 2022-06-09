using Emgu.CV;
using SEM.API.Interfaces;
using System.Drawing;
using Emgu.CV.Structure;
using System.IO;
using System;

namespace SEM.API.Services
{
    public class FaceDetectionService : IFaceDetectionService
    {
        static readonly CascadeClassifier classifier = new CascadeClassifier(
            Path.Combine(Environment.CurrentDirectory,
                        "Helpers/haarcascade_frontalface_alt_tree.xml"));
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