using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;

namespace Part2OfPoe
{
    public class chatbot_voice
    {
       

       

        public void speak(string chatbot_response)
        {
            SpeechSynthesizer synthesizer = new SpeechSynthesizer();
            // set the voice to microsoft zira desktop
            synthesizer.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Senior);
            synthesizer.Rate = 2; // set the rate to normal
            synthesizer.Volume = 100; // set the volume to maximum
            synthesizer.SpeakAsync(chatbot_response);

        }

    }
}
