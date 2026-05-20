using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;

namespace Part2OfPoe
{
    public class memory_recall
    {
        public void write_name_of_user(string name)
        {
            //create a text file called names.txt if it doesn't exist
            if (!File.Exists("names.txt"))
            {
                File.Create("names.txt").Close();
            }
            // write the name to the file
            if (File.ReadAllText("names.txt").Contains(name))
            {
                MessageBox.Show($"Welcome back {name}!", "Welcome Back", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            else
            {
                File.AppendAllText("names.txt", name + Environment.NewLine);
                MessageBox.Show($"I recognize you are a new user. Welcome {name}😊","New User Recognition", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }
      
    }
}
