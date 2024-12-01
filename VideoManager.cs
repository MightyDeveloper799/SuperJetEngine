using System;
using System.IO;
using Vlc.DotNet.Core;
using Vlc.DotNet.Core.Interops.Signatures;

namespace SuperJet
{
    public class VideoManager
    {
        private static VlcMediaPlayer vlcMediaPlayer;

        static VideoManager()
        {
            var vlcLibDirectory = new DirectoryInfo(@"C:/Program Files/VideoLAN/VLC");
            var vlcOption = new string[] { };
            vlcMediaPlayer = new VlcMediaPlayer(vlcLibDirectory, vlcOption);
        }

        public void PlayVideo(string filePath)
        {
            vlcMediaPlayer.SetMedia(new FileInfo(filePath));
        }

        public void StopVideo()
        {
            vlcMediaPlayer.Stop();
        }

        public void PauseVideo()
        {
            vlcMediaPlayer.Pause();
        }
    }
}
