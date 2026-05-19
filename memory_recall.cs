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
            if (File.ReadAllText("names.txt").Contains(name))
            {
                MessageBox.Show($"Welcome back {name}!", "Welcome Back", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                File.AppendAllText("names.txt", name + Environment.NewLine);
            }

        }
        public void write_favorite_topic(string message)
        {
            

        }

    }
}
