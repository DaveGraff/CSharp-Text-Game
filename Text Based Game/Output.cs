using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Text_Based_Game {
    class Output {
        private static Dictionary<string, string> states = new Dictionary<string, string>() {
            {"menu", "Welcome to Adventures United!\n[S]tart\n[L]oad\n[E]xit" },
            {"home", "[R]est at the Inn\n[V]isit the Shop\n[F]ight Monsters\n[E]xit without saving" },
            {"dead", "You died..." },
            {"shop", "[E]xit the shop" },
            {"adventure", "[F]ight monster\n[R]eturn" },
            {"playerturn", "[A]ttack\n[U]se Item\n[R]un away" }
        };

        public static Char displayState(string state) {
            string regex = ("\\[.\\]");
            MatchCollection matches = Regex.Matches(states[state], regex);
            Char[] options = matches.Cast<Match>().Select(m => m.Value[1]).ToArray();

            Char keyVal = '\n';
            while (!options.Contains(keyVal)) {
                Console.Clear();
                Console.WriteLine(states[state]);
                keyVal = Char.ToUpper(Console.ReadKey().KeyChar);
                Jukebox.PlaySong("Button Press.wav");
            }

            return keyVal;
        }
    }
}
