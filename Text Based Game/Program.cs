using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Threading;


namespace Text_Based_Game {
    class Program {
        private static Jukebox music = new Jukebox("../../Sounds/");

        static void Main(string[] args) {
            music.PlayBackground("Menu.wav");
            menuState();
        }

        static void menuState() {
            switch (Output.displayState("menu")) {
                case 'S':
                    homeState();
                    break;
                case 'L':
                    break;
                case 'E':
                    exit();
                    break;
            }
        }

        static void homeState() {
            switch (Output.displayState("home")) {
                case 'R':
                    for(int i = 0; i < 2; i++) {
                        Console.Clear();
                        Console.WriteLine("Z");
                        Thread.Sleep(300);
                        Console.WriteLine("Z");
                        Thread.Sleep(300);
                        Console.WriteLine("Z...");
                        Thread.Sleep(300);
                    }
                    homeState();
                    break;
                case 'V':
                    break;
                case 'F':
                    break;
                case 'E':
                    menuState();
                    break;
            }
        }

        static void exit() {
            music.Stop();
            Environment.Exit(0);
        }       
    }
}
