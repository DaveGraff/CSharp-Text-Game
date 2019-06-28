using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_Game {
    class Output {
        //Constants for selection options in each location
        private static readonly string[] home = { "[R]est at the Inn", "[V]isit the Shop", "[F]ight Monsters", "[E]xit without saving" };
        private static readonly string[] fighting = { "[K]ill yourself", "[R]eturn Home" };
        private static readonly string[] shop = { "[E]xit the shop" };
        private static readonly string[] dead = { "You Died..." };
        private static readonly string[] mainMenu = { "Welcome to [Game Name!]\n", "[S]tart", "[L]oad", "[E]xit" };

        static readonly Dictionary<State, string[]> options = new Dictionary<State, string[]>() {
            {State.MainMenu, mainMenu },
            {State.Home, home },
            {State.Shop, shop },
            {State.Fighting, fighting },
            {State.Dead, dead }
        };

        private static readonly Dictionary<char, string> homeD = new Dictionary<char, string>() {
            {'r',"You spend a night at the Inn. \nHealth Fully Restored!" }
        };
        private static readonly Dictionary<char, string> fightingD = new Dictionary<char, string>() {
            {'k',"rip..." }
        };
        private static readonly Dictionary<char, string> shopD = new Dictionary<char, string>() {
            
        }; private static readonly Dictionary<char, string> deadD = new Dictionary<char, string>() {

        };
        private static readonly Dictionary<State, Dictionary<char, string>> states = new Dictionary<State, Dictionary<char, string>>() {
            {State.Home, homeD },
            {State.Fighting, fightingD },
            {State.Shop, shopD },
            {State.Dead, deadD }
        };
        public static State GameState { get; set; } = State.MainMenu;

        public static void DisplayState() {
            Console.Clear();
            foreach (string x in options[GameState]) {
                Console.WriteLine(x);
            }
        }
        public static void DisplayState(char action) {
            Console.Clear();
            foreach (string option in options[GameState]) {
                Console.WriteLine(option);
            }
            Console.WriteLine();

            if (states[Output.GameState].ContainsKey(action))
                Console.WriteLine(states[Output.GameState][action]);
        }
    }
}
