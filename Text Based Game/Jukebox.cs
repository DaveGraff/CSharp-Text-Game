using System;
using System.Threading;
using System.Linq;
using System.Windows.Media;
using System.Windows.Threading;

namespace Text_Based_Game {
    class Jukebox {
        private MediaPlayer music;
        private readonly string mainMusic = "Menu.wav";
        private readonly string fileName;
        public Jukebox() {
            music = new MediaPlayer();
            fileName = AppContext.BaseDirectory + "../../Sounds/" + mainMusic;
        }
        public void Play() {
            music.Open(new Uri(@fileName));
            music.MediaEnded += new EventHandler((sender, e) => {
                music.Stop();
                music.Position = TimeSpan.Zero;
                music.Play();
            });
            music.Play();
        }
        public void Stop() { 
            music.Stop();
        }
    }
}
