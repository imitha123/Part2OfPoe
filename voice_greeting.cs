using System;
using System.Media;
using System.Windows;

namespace Part2OfPoe
{
    public class voice_greeting
    {
        // constructor to call the greetingVoice method when an instance of the class is created
        public voice_greeting()
        {
            greetingVoice();
        }
        public void greetingVoice()
        {
            string path_directory = AppDomain.CurrentDomain.BaseDirectory;
            //ChatArea.AppendText($"{path_directory} {Environment.NewLine}");
            string recordPath = path_directory.Replace("\\bin\\Debug", "");

            string record = System.IO.Path.Combine(recordPath, "Recording.wav");
            play_voice(record);
        }

        public void play_voice(string voice)
        {
            try
            {
                using (SoundPlayer speechObj = new SoundPlayer(voice))
                {
                    speechObj.PlaySync();
                }

            }
            catch (Exception error)
            {
                MessageBox.Show($"ChatBot: Error playing voice - {error.Message}");
            }
        }
    }
}