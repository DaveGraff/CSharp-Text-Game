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
            //Thread music = new Thread(playSong);
            Thread t = new Thread(() => playSong("Mario-Sheet-Music-Death-Sound.mid"));
            t.Start();

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
