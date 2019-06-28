﻿using System;
using System.Threading;
using System.Linq;
using System.Windows.Media;
using System.Windows.Threading;
using System.Collections.Generic;

namespace Text_Based_Game {
    class Program {
        static State GameState = State.MainMenu;
        //Constants for selection options in each location
        static readonly string[] homeOptions = {"[R]est at the Inn","[V]isit the Shop", "[F]ight Monsters", "[E]xit without saving"};
        static readonly string[] fightingOptions = { "[K]ill yourself", "[R]eturn Home" };
        static readonly string[] shop = { "[E]xit the shop" };
        static readonly string[] dead = { "You Died..." };
        static readonly string[] mainMenu = { "Welcome to [Game Name!]\n", "[S]tart", "[L]oad", "[E]xit" };

        static readonly Dictionary<string, string> sounds = new Dictionary<string, string>() {
            {"select","Button Press.wav"},
            {"dead", "Mario-Sheet-Music-Death-Sound.mid" }
        };

        static Jukebox backgroundMusic;

        static void Main(string[] args) {
            backgroundMusic = new Jukebox();
            backgroundMusic.Play();
            Output.GameState = GameState;

            //Handle menu
            Output.DisplayState();
            

            char[] controlKeys = new char[] { 's', 'l', 'e' };
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
                    Console.WriteLine();
                    StartGame();
                    break;
                case 'l':
                    Console.WriteLine("Unsupported :(");
                    break;
            }
        }

        static void StartGame() {
            GameState = State.Home;
            Output.GameState = GameState;
            Output.DisplayState();
            char action;
            while (GameState != State.Exit) {
                GameStep((action=Console.ReadKey().KeyChar));
                Output.DisplayState(action);
            }
        }

        //Prints avaiable options based on GameState and Options lists
        

        static void GameStep(char selection) {
            PlaySong(sounds["select"]);
            Console.WriteLine();
            switch (GameState) {
                case State.Home:
                    switch (selection) {
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
                            Dead();
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
            Output.GameState = GameState;
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
