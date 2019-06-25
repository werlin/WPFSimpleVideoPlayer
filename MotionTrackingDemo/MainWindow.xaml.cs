using Accord.Video;
using Accord.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MotionTrackingDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private OpenFileDialog openFileDialog = new OpenFileDialog();

        public MainWindow()
        {
            InitializeComponent();

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // create video source
                FileVideoSource fileSource = new FileVideoSource(openFileDialog.FileName);

                // open it
                OpenVideoSource(fileSource);
            }
            
        }

        private void OpenVideoSource(IVideoSource source)
        {
            
            // stop current video source
            CloseCurrentVideoSource();

            // start new video source
            framePlayer.VideoSource = source;
            framePlayer.Start();
        }

        private void CloseCurrentVideoSource()
        {
            if (framePlayer.VideoSource != null)
            {
                framePlayer.SignalToStop();

                // wait ~ 3 seconds
                for (int i = 0; i < 30; i++)
                {
                    if (!framePlayer.IsRunning)
                        break;
                    System.Threading.Thread.Sleep(100);
                }

                if (framePlayer.IsRunning)
                {
                    framePlayer.Stop();
                }

                framePlayer.VideoSource = null;
            }
        }
    }
}
