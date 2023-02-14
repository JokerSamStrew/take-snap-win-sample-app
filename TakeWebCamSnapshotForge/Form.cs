using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
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

            listBox.DisplayMember = "Name";

            foreach ( FilterInfo item in videoDevices )
                listBox.Items.Add( item );

            if ( listBox.Items.Count > 0 )
            {
                listBox.SelectedIndex = 0;

                videoSource = new VideoCaptureDevice( SelectedFilterInfo.MonikerString );

                // Запустить камеру
                videoSource.Start();
            }

            videoSourcePlayer.VideoSource = videoSource;
        }

        private FilterInfo SelectedFilterInfo => ( FilterInfo )listBox.SelectedItem;

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

        private void applyButton_Click( object sender, EventArgs e )
        {
            if ( SelectedFilterInfo.MonikerString == videoSource.Source ) return;

            videoSource.Stop();
            videoSource.Source = SelectedFilterInfo.MonikerString;
            videoSource.Start();
        }
    }
}