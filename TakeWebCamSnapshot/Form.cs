using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibVLCSharp.Shared;

namespace TakeWebCamSnapshotVLC
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
            _libVlc.SetDialogHandlers( ( _, _ ) => Task.CompletedTask,
                ( _, _, _, _, _, _ ) => Task.CompletedTask,
                ( _, _, _, _, _, _, _, _ ) => Task.CompletedTask,
                ( _, _, _, _, _, _, _ ) => Task.CompletedTask,
                ( _, _, _ ) => Task.CompletedTask );
        }

        private readonly LibVLC _libVlc = new();

        private MediaPlayer CreateMediaPlayer()
        {
            var media = new Media( _libVlc, "dshow//:", FromType.FromLocation );
            media.AddOption( ":live-caching=0" );
            media.AddOption( ":no-audio" );
            media.AddOption( ":dshow-fps=30" );
            media.AddOption( ":dshow-adev=none" );
            media.AddOption( ":no-dshow-config" );
            media.AddOption( ":no-dshow-tuner" );
            var _mp = new MediaPlayer( _libVlc )
            {
                Media = media
            };

            if ( !_mp.Play() ) toolStripStatusLabel.Text = "Error in Playing...";
            return _mp;
        }

        private void TakeSnapshot()
        {
            if ( !videoView.MediaPlayer?.TakeSnapshot( 0, textBox.Text,
                    0, 0 ) ?? true )
                toolStripStatusLabel.Text = "Fail Take Snapshot";
        }

        private void Form_Load( object sender, EventArgs e )
        {
            videoView.MediaPlayer = CreateMediaPlayer();
            textBox.Text = Path.Combine( Path.GetDirectoryName( Assembly.GetEntryAssembly().Location ),
                "current_snap.png" );
        }

        private void button_Click( object sender, EventArgs e )
        {
            TakeSnapshot();
        }

        private void Form_FormClosing( object sender, FormClosingEventArgs e )
        {
            videoView.MediaPlayer?.Dispose();
        }
    }
}