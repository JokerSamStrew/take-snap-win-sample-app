using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using AForge.Controls;
using AForge.Video;
using AForge.Video.DirectShow;

namespace TakeWebCamSnapshotForge
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
        }

        private VideoCaptureDevice videoSource;

        private void Form_Load( object sender, EventArgs e )
        {
            // Получить список доступных камер
            FilterInfoCollection videoDevices = new FilterInfoCollection( FilterCategory.VideoInputDevice );

            // Выбрать первую камеру из списка
            videoSource = new VideoCaptureDevice( videoDevices[0].MonikerString );

            // Запустить камеру
            videoSource.Start();

            // Получить текущий кадр с камеры
            var controlPlayer = new VideoSourcePlayer { VideoSource = videoSource, Dock = DockStyle.Fill };
            splitContainer.Panel2.Controls.Add( controlPlayer );
        }

        private void Form_FormClosed( object sender, FormClosedEventArgs e )
        {
            videoSource.Stop();
        }

        private bool frameReceived = false;

        private void button_Click( object sender, EventArgs e )
        {
            frameReceived = false;
            videoSource.NewFrame += GetSnap;
            while ( !frameReceived ) Thread.Sleep( 200 );
            videoSource.NewFrame -= GetSnap;
        }

        private void GetSnap( object sender, NewFrameEventArgs eventargs )
        {
            if ( frameReceived )
                return;

            panel.BackgroundImage = ( Image )eventargs.Frame.Clone();
            frameReceived = true;
        }
    }
}