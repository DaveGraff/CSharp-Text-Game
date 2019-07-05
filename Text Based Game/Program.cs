using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Threading;


namespace Text_Based_Game {
    class Program {
        private static readonly Jukebox music = new Jukebox("../../Sounds/");

        static void Main(string[] args) {
            music.PlayBackground("Menu.wav");
            MenuState();
        }

        static void MenuState() {
            switch (Output.displayState("menu")) {
                case 'S':
                    HomeState();
                    break;
                case 'L':
                    LoadState();
                    break;
                case 'E':
                    Exit();
                    break;
            }
        }

        static void HomeState() {
            switch (Output.displayState("home")) {
                case 'R':
                    for (int i = 0; i < 2; i++) {
                        Console.Clear();
                        Console.Write("Z ");
                        Thread.Sleep(300);
                        Console.Write("Z ");
                        Thread.Sleep(300);
                        Console.Write("Z...");
                        Thread.Sleep(300);
                    }
                    HomeState();
                    break;
                case 'V':
                    ShopState();
                    break;
                case 'G':
                    AdventureState();
                    break;
                case 'E':
                    MenuState();
                    break;
            }
        }

        static void LoadState() {
            //TODO: Logic for load game
            Output.MetaData = "[R]eturn";
            switch (Output.displayState("load")) {
                case 'R':
                    MenuState();
                    break;
            }
        }

        static void ShopState() {
            //TODO: Logic for buying items
            switch (Output.displayState("shop")) {
                case 'E':
                    HomeState();
                    break;
            }
        }

        static void AdventureState() {
            switch (Output.displayState("adventure")) {
                case 'F':
                    FightState();
                    break;
                case 'R':
                    HomeState();
                    break;
            }

        }
        
        static void FightState() {
            switch (Output.displayState("playerturn")) {
                case 'A':
                    break;
                case 'U':
                    break;
                case 'R':
                    AdventureState();
                    break;
            }
        }

        static void Exit() {
            music.Stop();
            Environment.Exit(0);
        }
    }
}
