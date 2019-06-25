using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MotionTrackingDemo
{
    public class SingleImageFrame
    {

        public ImageSource FrameImageSource { get; private set; }

        public SingleImageFrame(ImageSource image)
        {
            FrameImageSource = image;
        }
    }

    public class FrameImageCache : List<SingleImageFrame>
    {
        public void AddImage(ImageSource image)
        {
            Add(new SingleImageFrame(image));
        }
    }
}
