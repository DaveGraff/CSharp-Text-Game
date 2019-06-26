using System;
using System.Threading;
using System.Linq;
using System.Windows.Media;
using System.Windows.Threading;
using System.Collections.Generic;

namespace Text_Based_Game {
    class Program {

        static State GameState;

        //Constants for selection options in each location
        static readonly string[] homeOptions = {"[R]est at the Inn","[V]isit the Shop", "[F]ight Monsters", "[E]xit without saving"};
        static readonly string[] fightingOptions = { "[K]ill yourself", "[R]eturn Home" };
        static readonly string[] shop = { "[E]xit the shop" };
        static readonly string[] dead = { "You Died..." };

        static Dictionary<string, string> sounds = new Dictionary<string, string>() {
            {"select","Button Press.wav"},
            {"dead", "Mario-Sheet-Music-Death-Sound.mid" }
        };

        static Jukebox backgroundMusic;

        //Different States to describe the characters current location in the game
        //Used by GameState variable
        enum State { Exit, Dead, Home, Fighting, Shop }; 

        static void Main(string[] args) {
            backgroundMusic = new Jukebox();
            backgroundMusic.Play();

            Console.WriteLine("Welcome to [Game Name!]");
            Console.WriteLine("[S]tart\n[L]oad\n[E]xit");

            //Handle menu
            char[] controlKeys = new char[] {'s', 'l', 'e'};

            char inputChar;
            do {
                inputChar = Console.ReadKey().KeyChar;
            } while (!controlKeys.Contains(inputChar));

            PlaySong(sounds["select"]);
            switch (inputChar) {
                case 'e':
                    Environment.Exit(0);
                    break;
                case 's':
                    StartGame();
                    break;
                case 'l':
                    Console.WriteLine("Unsupported :(");
                    break;
            }
        }

        static void StartGame() {
            GameState = State.Home;
            while (GameState != State.Exit) {
                PrintOptions();
                GameStep(Console.ReadKey().KeyChar);
            }
        }

        //Prints avaiable options based on GameState and Options lists
        static void PrintOptions() {
            string[] options;
            switch (GameState) {
                case State.Home:
                    options = homeOptions;
                    break;
                case State.Fighting:
                    options = fightingOptions;
                    break;
                case State.Shop:
                    options = shop;
                    break;
                case State.Dead:
                    options = dead;
                    Dead();
                    break;
                default:
                    options = new string[0];
                    break;
            }
            Console.WriteLine();
            foreach(string option in options) {
                Console.WriteLine(option);
            }

        }

        static void GameStep(char selection) {
            PlaySong(sounds["select"]);
            Console.WriteLine();
            switch (GameState) {
                case State.Home:
                    switch (selection) {
                        case 'r':
                            Console.WriteLine("Taking a quick nap....");
                            break;
                        case 'v':
                            GameState = State.Shop;
                            break;
                        case 'f':
                            GameState = State.Fighting;
                            break;
                        case 'e':
                            GameState = State.Exit;
                            break;
                            
                    }
                    break;
                case State.Fighting:
                    switch (selection) {
                        case 'k':
                            GameState = State.Dead;
                            break;
                        case 'r':
                            GameState = State.Home;
                            break;
                    }
                    break;
                case State.Shop:
                    switch (selection) {
                        case 'e':
                            GameState = State.Home;
                            break;
                    }
                    break;
            }

        }

        static void Dead() {
            backgroundMusic.Stop();
            PlaySong(sounds["dead"]);
        }


        static void loadGame() {

        }

        //Plays any general sound file 
        static void PlaySong(string fileName) {
            var p1 = new MediaPlayer();
            fileName = AppContext.BaseDirectory + "../../Sounds/" + fileName;
            p1.Open(new Uri(@fileName));
            p1.Play();
        }
    }
}
