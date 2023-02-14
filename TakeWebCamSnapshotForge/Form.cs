using System;
using System.Windows.Forms;
using AForge.Controls;
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
            Controls.Add( controlPlayer );
        }

        private void Form_FormClosed( object sender, FormClosedEventArgs e )
        {
            videoSource.Stop();
        }
    }
}