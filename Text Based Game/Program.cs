using System;
using System.Threading;
using System.Linq;
using System.Media;
using System.Windows.Media;
using System.Windows.Threading;

namespace Text_Based_Game {
    class Program {
        static Thread music;
        static void Main(string[] args) {
            music = new Thread(() => playBackground("Button Press.wav"));
            music.Start();

            Console.WriteLine("Welcome to [Game Name!]");
            Console.WriteLine("[S]tart\n[L]oad\n[E]xit");

            //Handle menu
            char[] controlKeys = new char[] {'s', 'l', 'e'};

            char inputChar;
            do {
                inputChar = Console.ReadKey().KeyChar;
            } while (!controlKeys.Contains(inputChar));

            switch (inputChar) {
                case 'e':
                    System.Environment.Exit(0);
                    break;
                case 's':
                    startGame();
                    break;
                case 'l':
                    Console.WriteLine("Unsupported :(");
                    break;
            }
        }

        static void startGame() {
            Thread test = new Thread(()=>playSong("Button Press.wav"));
            test.Start();
            Console.ReadKey();
        }

        static void loadGame() {

        }


        static void playSong(string fileName) {
            var p1 = new MediaPlayer();
            fileName = AppContext.BaseDirectory + "../../Sounds/" + fileName;
            p1.Open(new Uri(@fileName));
            p1.Play();
        }
        static void playBackground(string fileName) {
            Dispatcher.CurrentDispatcher.VerifyAccess();

            MediaPlayer backGroundMusic = new MediaPlayer();
            fileName = AppContext.BaseDirectory + "../../Sounds/" + fileName;
            backGroundMusic.Open(new Uri(@fileName));
            backGroundMusic.MediaEnded += new EventHandler((sender, e) =>
            {
                backGroundMusic.Stop();
                backGroundMusic.Position = TimeSpan.Zero;
                backGroundMusic.Play();
            });
            backGroundMusic.Play();

            Dispatcher.Run();
        }
    }
}
