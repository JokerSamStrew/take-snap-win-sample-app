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
        private bool frameReceived;

        private VideoCaptureDevice videoSource;

        public Form()
        {
            InitializeComponent();
        }

        private void Form_Load( object sender, EventArgs e )
        {
            // Получить список доступных камер
            var videoDevices = new FilterInfoCollection( FilterCategory.VideoInputDevice );

            foreach ( FilterInfo item in videoDevices )
                listBox.Items.Add( item.Name );

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