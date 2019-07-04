using System;
using System.Threading;
using System.Linq;
using System.Windows.Media;
using System.Windows.Threading;

namespace Text_Based_Game {
    class Jukebox {
        private MediaPlayer music;
        private string soundsDirectory;

        public Jukebox(string soundsDirectory) {
            music = new MediaPlayer();
            this.soundsDirectory = soundsDirectory;
        }

        public void PlayBackground(string song) {
            string filename = AppContext.BaseDirectory + soundsDirectory + song;

            music.Open(new Uri(@filename));
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

        //Plays any general sound file 
        public static void PlaySong(string fileName) {
            var p1 = new MediaPlayer();
            fileName = AppContext.BaseDirectory + "../../Sounds/" + fileName;
            p1.Open(new Uri(@fileName));
            p1.Play();
        }
    }
}