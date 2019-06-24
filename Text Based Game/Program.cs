using System;
using System.Threading;
using System.Collections.Generic;
using Melanchall.DryWetMidi.Devices;
using Melanchall.DryWetMidi.Smf;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_Game {

    class Program {
        static void Main(string[] args) {
            Thread t = new Thread(() => playSong("Mario-Sheet-Music-Death-Sound.mid"));
            t.Start();

            Console.WriteLine("Welcome to [Game Name!]");
            Console.WriteLine("[S]tart\n[L]oad\n[E]xit");

            char[] controlKeys = new char[] {'s', 'l', 'e'};

            char inputChar;
            do {
                inputChar = Console.ReadKey().KeyChar;
            } while (!controlKeys.Contains(inputChar));

            switch (inputChar) {
                case 'e':
                case 's':
                case 'l':
                    Console.WriteLine("Unsupported :(");
                    break;
            }
            
        }






        static void playSong(string fileName) {
            var midiFile = MidiFile.Read("../../Sounds/" + fileName);

            while (true) {
                using (var outputDevice = OutputDevice.GetByName("Microsoft GS Wavetable Synth")) {
                    midiFile.Play(outputDevice);
                }
            }
        }
    }
}
