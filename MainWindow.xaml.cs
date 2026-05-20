using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Speech.Synthesis;


namespace Part2OfPoe
{
 
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           // new voice_greeting();
            
        }
        //Global variables
        string name;
        
        Random random = new Random();
        my_dictionary dictionary = new my_dictionary();



        // method to start the chatbot when the start button is clicked
        private void start_ai(object sender, RoutedEventArgs e)
        {
            // set the welcome grid hidden
            WelcomeGrid.Visibility = Visibility.Hidden;
            // set username grid visible
            UsernameGrid.Visibility = Visibility.Visible;
        }


        // method to submit the username and start the chat
        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            // take the name from the text box and set it to the validate
            name = UsernameTextBox.Text.Trim();

            // validate the name input
            if (String.IsNullOrEmpty(name))
            {

                MessageBox.Show("Name Cannot be empty!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (!Regex.IsMatch(name, @"^[a-zA-Z]+$"))
            {
                MessageBox.Show("Name can only contain letters!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }else if(name.Length <= 2)
            {
                MessageBox.Show("Name can't be 2 or less letters", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            StackPanel welcome_panel = new StackPanel
            {
                Orientation = Orientation.Horizontal
            };
            // list item for the welcome message and chatbot name with different colors and font sizes
            ListViewItem welcome_item = new ListViewItem();
            welcome_item.Content = new TextBlock()
            {
                Text = $": Welcome {name}! I am your CyberSecurity Chatbot, you may ask me anything about cybersecurity.😁",
                Foreground = Brushes.LightBlue,
                FontSize = 15,

            };

            ListViewItem bot_name_item = new ListViewItem();
            bot_name_item.Content = new TextBlock
            {
                Text = $"ChatBot",
                Foreground = Brushes.Green,
                FontSize = 15,
            };
            welcome_panel.Children.Add(bot_name_item);
            welcome_panel.Children.Add(welcome_item);

            UsernameGrid.Visibility = Visibility.Hidden;
                ChatGrid.Visibility = Visibility.Visible;

                chats_list.Items.Add(welcome_panel);

            // create an instance of the memory recall class and write the name of the user to a text file
            memory_recall recall = new memory_recall();
            recall.write_name_of_user(name);

        }

        // method to send a message when the send button is clicked
        private void SendMessageButton(object sender, RoutedEventArgs e)
        {
            string message = chat_input.Text;
            name = UsernameTextBox.Text;
            // create a stack panel to hold the name and message
            StackPanel panel = new StackPanel
            {
                Orientation = Orientation.Horizontal
            };
            // list item for the message and name with different colors and font sizes
            ListViewItem Message_item = new ListViewItem();
            Message_item.Content = new TextBlock
            {
                Text = $": {message}",
                Foreground = Brushes.Yellow,
                FontSize = 15
            };

            ListViewItem Name_item = new ListViewItem();
            Name_item.Content = new TextBlock
            {
                Text = $"{name}",
                Foreground = Brushes.White,
                FontSize = 15,
            };

            panel.Children.Add(Name_item);
            panel.Children.Add(Message_item);

            chats_list.Items.Add(panel);

            if (String.IsNullOrEmpty(message))
            {
                MessageBox.Show("Message cannot be empty!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                chat_input.Focus();
                return;
            }
            // close the application if the user types "exit"
            if (message.ToLower().Equals("exit"))
            {

                if(MessageBoxResult.Yes == MessageBox.Show("Are you sure you want to exit?", "Exit Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question))
                {
                    Application.Current.Shutdown();
                }
                chat_input.Focus();
                chat_input.Clear();

                return;
            }

            // Check if the message contains any of the topics
            bool topicFound = false;

            
            foreach (var topic in dictionary.Topics())
            {
                if (message.ToLower().Contains(topic.Key) && !message.ToLower().Trim().Contains("interested in"))
                {

                    int randomIndex = random.Next(0, topic.Value.Length);

                    // list item for the chatbot response with the topic definition and different color and font size
                    ListViewItem topic_item = new ListViewItem();
                    topic_item.Content = new TextBlock
                    {
                        Text = $": {topic.Value[randomIndex]} ",
                        Foreground = Brushes.LightBlue,
                        FontSize = 15,
                    };
                    // list item for the chatbot name with different color and font size
                    ListViewItem bot_name_item = new ListViewItem();
                    bot_name_item.Content = new TextBlock
                    {
                        Text = $"ChatBot",
                        Foreground = Brushes.Green,
                        FontSize = 15,
                    };
                    // create a stack panel to hold the chatbot name and response
                    StackPanel topic_panel = new StackPanel
                    {
                        Orientation = Orientation.Horizontal
                    };

                    topic_panel.Children.Add(bot_name_item);
                    topic_panel.Children.Add(topic_item);

                    chats_list.Items.Add(topic_panel);
                    topicFound = true;
                    chat_input.Focus();
                    chat_input.Clear();


                   
                    break;
                }

            }

            foreach (var topic in dictionary.Topics())
            {
                if (message.ToLower().Trim().Contains("interested in"))
                {
                    // check if file exists if not create it
                    if (!File.Exists("topics.txt"))
                    {
                        File.Create("topics.txt").Close();
                    }

                    if (message.ToLower().Trim().Contains(topic.Key))
                    {
                        File.AppendAllText("topics.txt", $" Favorite topic: {name} {topic.Key} " + Environment.NewLine);
                        MessageBox.Show($"Great! I have noted that your favorite topic is {topic.Key}. Feel free to ask me anything about {topic.Key}😊👍!", "Favorite Topic Noted", MessageBoxButton.OK, MessageBoxImage.Information);
                        topicFound = true;
                        chat_input.Focus();
                        chat_input.Clear();
                    }
                }

            }

            foreach (var topic in dictionary.Topics())
            {
                if (message.ToLower().Trim().Contains("favorite topic"))
                {
                    // check if file exists if not create it
                    if (!File.Exists("topics.txt"))
                    {
                        File.Create("topics.txt").Close();
                    }

                    if (File.Exists("topics.txt"))
                    {
                        string[] lines = File.ReadAllLines("topics.txt");
                        if (lines.Length > 0 && lines[lines.Length - 1].Contains(name))
                        {
                            string lastLine = lines[lines.Length - 1];
                            MessageBox.Show($"Your Favorite Topic is {lastLine.Replace($" Favorite topic: {name}", "")}" , "Favorite Topic Found",MessageBoxButton.OK, MessageBoxImage.Information);
                            topicFound = true;
                            chat_input.Focus();
                            chat_input.Clear();
                            break;
                        }
                        else
                        {
                            MessageBox.Show("You haven't told me your favorite topic yet! Please tell me by saying 'I am interested in [topic]'.", "No Favorite Topic Found", MessageBoxButton.OK, MessageBoxImage.Information);
                            chat_input.Focus();
                            chat_input.Clear();
                        }
                    }
                   break;
                }
            }


            if (!topicFound)
            {
                Random rand = new Random();
                int randInt = rand.Next(0, dictionary.random_responces().Length);

                StackPanel response_panel = new StackPanel
                {
                    Orientation = Orientation.Horizontal
                };
                // list item for the chatbot response with a random response from the dictionary and different color and font size
                ListViewItem response_item = new ListViewItem();
                response_item.Content = new TextBlock
                {
                    Text = $": {dictionary.random_responces()[randInt]}",
                    Foreground = Brushes.Red,
                    FontSize = 15,
                };

                ListViewItem bot_name_item = new ListViewItem();
                bot_name_item.Content = new TextBlock
                {
                    Text = $"ChatBot",
                    Foreground = Brushes.Green,
                    FontSize = 15,
                };
                response_panel.Children.Add(bot_name_item);
                response_panel.Children.Add(response_item);

                chats_list.Items.Add(response_panel);
                chat_input.Focus();
                chat_input.Clear();

            }


        }
        // place holder text for the chat input and username input
        private void chat_input_GotFocus(object sender, RoutedEventArgs e)
        {
            if (chat_input.Text == "Ask anything about cybersecurity...")
            {
                chat_input.Text = "";
            }

        }

        private void UsernameTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (UsernameTextBox.Text == "Eg. John")
            {
                UsernameTextBox.Text = "";
            }

        }
    }
}
