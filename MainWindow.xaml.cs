using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Media;
using System.Speech.Synthesis;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;


namespace Part2OfPoe
{
 
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.Closing += MainWindow_Closing;
            InitializeComponent();
            //new voice_greeting();
            
        }
        //Global variable
        string name;
        

        Random random = new Random();
        // create an instance of the dictionary and arrays class to access the topics and responses
        my_dictionary_and_arrays dictionary = new my_dictionary_and_arrays();
        // create an instance of the chatbot voice class to access the text to speech functionality
        chatbot_voice voice = new chatbot_voice();
        // create an instance of the list view items class to access the methods that create the list view items
        List_view_items list_items = new List_view_items();
        // create an instance of the name validation class to access the method that validates the name input
        name_validation validate = new name_validation();

        task_repo repo = new task_repo();



        // variables to keep track of the current topic and index of the response for that topic
        string current_topic = "";
        int current_index = 0;
        bool topicFound = false;
        bool more_info_true_or_fasle = false;
        int count = 1;

       

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
            name = UsernameTextBox.Text.Trim().ToLower();

            // validate the name input
            if (!validate.validate_name(name))
            {
                return;
            }
            

            StackPanel welcome_panel = new StackPanel
            {
                Orientation = Orientation.Horizontal
            };
            // list item for the welcome message and chatbot name with different colors and font sizes
            
            Random rand = new Random();

            int Index = rand.Next(0, dictionary.random_greeting().Length);
           
            voice.speak(dictionary.random_greeting()[Index]);

            welcome_panel.Children.Add(list_items.chatbot_name());
            welcome_panel.Children.Add(list_items.welcome_user(dictionary.random_greeting()[Index]));

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
                Orientation = Orientation.Vertical
            };

            panel.Children.Add(list_items.user_name(name));
            panel.Children.Add(list_items.message_input(message));
            topicFound = false;

            chats_list.Items.Add(panel);
            
            //chech if the message is to add a task
            if (message.ToLower().StartsWith("add task"))
            {
                try
                {
                    string[] parts = message.Split(',');


                    string title = parts[1].Trim();
                    string description = parts[2].Trim();
                    string reminder = string.Empty;

                    if(parts.Length > 3)
                    {
                        reminder = parts[3].Trim();
                    }

                    repo.add_task(title, description, reminder);


                    StackPanel Panel = new StackPanel
                    {
                        Orientation = Orientation.Vertical
                    };
 
                    Panel.Children.Add(list_items.chatbot_name());
                    Panel.Children.Add(list_items.topic_item("Task added successfully!"));
                    chats_list.Items.Add(Panel);

                }
                catch
                {
                    StackPanel Panel = new StackPanel
                    {
                        Orientation = Orientation.Vertical
                    };

                    Panel.Children.Add(list_items.chatbot_name());
                    Panel.Children.Add(list_items.No_Info("Invalid task format. Please use the format: add task,Title,Description,YYYY/MM/DD"));
                    chats_list.Items.Add(Panel);
                }
                focus_or_clear_chat_input();
                return;
            }
           

            // validate the message input
            if (String.IsNullOrEmpty(message))
            {
                MessageBox.Show("Message cannot be empty!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                chat_input.Focus();
                return;
            }
            // close the application if the user types "exit"
            if (message.ToLower().Trim().Equals("exit"))
            {

                if (MessageBoxResult.Yes == MessageBox.Show("Are you sure you want to exit the application?", "Exit Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question))
                {
                    Application.Current.Shutdown();
                }
                chat_input.Focus();
                chat_input.Clear();

                return;
            }

            // Check if the message contains any of the topics
            foreach (var topic in dictionary.Topics())
            {
                if (message.ToLower().Trim().Contains(topic.Key))
                {
                    
                    count = 1;
                    int randomIndex = random.Next(0, topic.Value.Length);

                    current_topic = topic.Key;
                    current_index = randomIndex;

                    voice.speak(topic.Value[randomIndex]);

                  
                    // create a stack panel to hold the chatbot name and response
                    StackPanel topic_panel = new StackPanel
                    {
                        Orientation = Orientation.Vertical
                    };

                    topic_panel.Children.Add(list_items.chatbot_name());
                    topic_panel.Children.Add(list_items.topic_item(topic.Value[randomIndex]));

                    // add the stack panel to the chat list
                    chats_list.Items.Add(topic_panel);

                    focus_or_clear_chat_input();
                    topicFound = true;
                    
                }

            }
            // check if the message contains tell me more or explain more or give me another tip and responds with another definition of the topic that is already mentioned in the message
            if(message.ToLower().Trim().Contains("tell me more") || message.ToLower().Trim().Contains("explain more") || message.ToLower().Trim().Contains("give me another tip"))
            {
                Random rand = new Random();
                int index = rand.Next(0, dictionary.random_more_info_query_without_topic().Length);

                if (!String.IsNullOrEmpty(current_topic) )
                {
                    // if the user asks for more information about a topic for the second time, don't ask if they are interested in it
                    if(count == 1)
                    {
                        if_user_asks_for_more_info();
                    }
                    // increment 
                    count++;


                    var topic_definitions = dictionary.Topics()[current_topic];
                    current_index = (current_index + 1) % topic_definitions.Length;

                    StackPanel topic_panel = new StackPanel
                    {
                        Orientation = Orientation.Vertical
                    };
                    topic_panel.Children.Add(list_items.chatbot_name());
                    topic_panel.Children.Add(list_items.topic_item($": {topic_definitions[current_index]} "));
                    chats_list.Items.Add(topic_panel);

                    voice.speak(topic_definitions[current_index]);

                    focus_or_clear_chat_input();
                    topicFound = true;
                }
                    else
                    {
                    
                    voice.speak(dictionary.random_more_info_query_without_topic()[index]);
                    MessageBox.Show(dictionary.random_more_info_query_without_topic()[index], "No Topic Mentioned", MessageBoxButton.OK, MessageBoxImage.Information);

                  
                    StackPanel topic_panel = new StackPanel
                    {
                        Orientation = Orientation.Vertical
                    };

                    topic_panel.Children.Add(list_items.chatbot_name());
                    topic_panel.Children.Add(list_items.topic_item(dictionary.random_more_info_query_without_topic()[index]));
                    chats_list.Items.Add(topic_panel);

                    focus_or_clear_chat_input();
                    topicFound = true;
                }
            }
            // if the user asks what their favorite topic is, the chatbot responds with the topic that is mentioned int the topics file according to the name of the user
            if (message.ToLower().Trim().Contains("favorite topic"))
            {
                count = 1;
                if (!File.Exists("topics.txt"))
                {
                    File.Create("topics.txt").Close();
                }
                Random rand = new Random();
                int index = rand.Next(0, dictionary.random_favorite_topic_not_found().Length);

                // check if the file contains the name of the user and it returns the last name of that user with its topic
                if (File.Exists("topics.txt"))
                {
                    string[] lines = File.ReadAllLines("topics.txt");
                    string favorite_topic = lines.LastOrDefault(line => line.Contains($"Favorite topic: {name}"));
                    favorite_topic = favorite_topic?.Replace($"Favorite topic: {name}", "").Trim();

                    if (!string.IsNullOrEmpty(favorite_topic))
                    {
                        voice.speak($"Your favorite topic is {favorite_topic}");
                        MessageBox.Show($"Your favorite topic is {favorite_topic}", "Favorite Topic", MessageBoxButton.OK, MessageBoxImage.Information);

                        focus_or_clear_chat_input();
                        topicFound = true;
                        StackPanel topic_panel = new StackPanel
                        {
                            Orientation = Orientation.Vertical
                        };

                        topic_panel.Children.Add(list_items.chatbot_name());
                        topic_panel.Children.Add(list_items.topic_item($"Your favorite topic is {favorite_topic}"));
                        chats_list.Items.Add(topic_panel);
                        topicFound = true;
                    }
                    else
                    {
                        
                        voice.speak(dictionary.random_favorite_topic_not_found()[index]);
                        MessageBox.Show(dictionary.random_favorite_topic_not_found()[index], "Favorite Topic Not Found", MessageBoxButton.OK, MessageBoxImage.Information);
                       

                        StackPanel topic_panel = new StackPanel
                        {
                            Orientation = Orientation.Vertical
                        };
                        topic_panel.Children.Add(list_items.chatbot_name());
                        topic_panel.Children.Add(list_items.topic_item(dictionary.random_favorite_topic_not_found()[index]));

                        chats_list.Items.Add(topic_panel);

                        focus_or_clear_chat_input();
                        topicFound=true;
                        
                    }

                }

            }
            // check for any sentiment in the message and respond with a random response from the dictionary according to the sentiment
            foreach (var sentiment in dictionary.sentiment_detection())
            {
                if (message.ToLower().Trim().Contains(sentiment.Key))
                {
                    count = 1;
                    int randomIndex = random.Next(0, sentiment.Value.Length);
                    int rand = random.Next(0, dictionary.user_tips().Length);
                    voice.speak(sentiment.Value[randomIndex]);
                    
                   
                    StackPanel sentiment_panel = new StackPanel
                    {
                        Orientation = Orientation.Vertical
                    };
                    sentiment_panel.Children.Add(list_items.chatbot_name());
                    sentiment_panel.Children.Add(list_items.return_sentiment_support_and_tip(sentiment.Value[randomIndex], dictionary.user_tips()[rand]));
                    
                    voice.speak(dictionary.user_tips()[rand]);

                    chats_list.Items.Add(sentiment_panel);

                    focus_or_clear_chat_input();
                    topicFound = true;
                    break;
                }

            }

            // if no topic is found in the message, return a random response from the dictionary
            if (!topicFound)
            {
                Random rand = new Random();
                int index = rand.Next(0, dictionary.random_responces_if_no_info().Length);

                StackPanel response_panel = new StackPanel
                {
                    Orientation = Orientation.Vertical
                };
                // list item for the chatbot response with a random response from the dictionary and different color and font size
                
                voice.speak(dictionary.random_responces_if_no_info()[index]);


                response_panel.Children.Add(list_items.chatbot_name());
                response_panel.Children.Add(list_items.No_Info(dictionary.random_responces_if_no_info()[index]));
                // reset the current topic and index
                current_index = 0;
                current_topic = "";

                chats_list.Items.Add(response_panel);
                focus_or_clear_chat_input();

            }


        }
       
     
        // method to write to the file a user is interested in a topic
        private void if_user_asks_for_more_info()
        {
            Random rand = new Random();
            int index = rand.Next(0, dictionary.random_ask_user_if_they_are_interested_in_topic().Length);
            voice.speak(dictionary.random_ask_user_if_they_are_interested_in_topic()[index]);
           

            if (MessageBoxResult.Yes == MessageBox.Show(dictionary.random_ask_user_if_they_are_interested_in_topic()[index], "More Information", MessageBoxButton.YesNo, MessageBoxImage.Question))
            {
                if (!File.Exists("topics.txt"))
                {
                    File.Create("topics.txt").Close();
                }

                if (File.Exists("topics.txt"))
                {
                    File.AppendAllText("topics.txt", $" Favorite topic: {name} {current_topic} " + Environment.NewLine);
                }

                MessageBox.Show("I will remember that!", "Favorite Topic", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {
                Random rand2 = new Random();
                int index2 = rand2.Next(0, dictionary.random_not_interested_in_topic().Length);
                voice.speak(dictionary.random_not_interested_in_topic()[index2]);
                MessageBox.Show(dictionary.random_not_interested_in_topic()[index2], "No Problem", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        // method to focus and clear the chat input
        public void focus_or_clear_chat_input()
        {
            chat_input.Focus();
            chat_input.Clear();

        }

        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(
                "Are you sure you want to exit the application?",
                "Exit Confirmation",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question
            );

            // If user clicks No, cancel the closing
            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
            }


        }
       

    }
}
