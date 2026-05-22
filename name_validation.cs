using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

namespace Part2OfPoe
{
    public class name_validation
    {
        // This method validates the input name based on specific criteria:
        public bool validate_name(string name)
        {
            if (String.IsNullOrEmpty(name))
            {

                MessageBox.Show("Name Cannot be empty!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else if (!Regex.IsMatch(name, @"^[a-zA-Z]+$"))
            {
                MessageBox.Show("Name can only contain letters!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else if (name.Length <= 2)
            {
                MessageBox.Show("Name can't be 2 or less letters", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

    }
}
