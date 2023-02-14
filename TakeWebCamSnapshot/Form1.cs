using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibVLCSharp.Shared;

namespace TakeWebCamSnapshot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private MediaPlayer _mp;


        private void Form1_Load( object sender, EventArgs e )
        {
            var _libVLC = new LibVLC();

            _libVLC.SetDialogHandlers( ( _, _ ) => Task.CompletedTask,
                ( dialog, _, _, _, _, _ ) =>
                {
                    //dialog.PostLogin(Settings.Login, Settings.Password, false);
                    return Task.CompletedTask;
                },
                ( _, _, _, _, _, _, _, _ ) => Task.CompletedTask,
                ( _, _, _, _, _, _, _ ) => Task.CompletedTask,
                ( _, _, _ ) => Task.CompletedTask );

            var media = new Media( _libVLC, "dshow//:", FromType.FromLocation );
            media.AddOption( ":live-caching=0" );
            media.AddOption( ":no-audio" );
            media.AddOption( ":dshow-fps=30" );
            media.AddOption( ":dshow-adev=none" );
            media.AddOption( ":no-dshow-config" );
            media.AddOption( ":no-dshow-tuner" );
            _mp = new MediaPlayer( _libVLC )
            {
                Media = media
            };

            if ( !_mp.Play() ) toolStripStatusLabel1.Text = "Error in Playing...";

            videoView1.MediaPlayer = _mp;
        }

        private void button1_Click( object sender, EventArgs e )
        {
            if ( !_mp.TakeSnapshot( 0,
                    "D:\\Projects\\TakeWebCamSnapshot\\TakeWebCamSnapshot\\bin\\Debug\\current_snap.png",
                    0, 0 ) )
                toolStripStatusLabel1.Text = "Fail TakeSnapshot";
        }

        private void Form1_FormClosing( object sender, FormClosingEventArgs e )
        {
            _mp.Dispose();
        }
    }
}