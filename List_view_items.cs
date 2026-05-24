using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using static System.Net.Mime.MediaTypeNames;

namespace Part2OfPoe
{
    public class List_view_items
    {
        // This method creates a ListViewItem with the content "ChatBot" styled in green and with a font size of 15.
        public ListViewItem chatbot_name()
        {
            ListViewItem item = new ListViewItem();

            item.Content = new TextBlock
            {
                Text = $"ChatBot",
                Foreground = Brushes.Green,
                FontSize = 15,
            };
            return item;
        }
        // This method creates a ListViewItem with the content ": {text} " styled in light blue and with a font size of 15, where {text} is the input parameter.
        public ListViewItem topic_item(string text)
        {
            ListViewItem topic_item = new ListViewItem();
            topic_item.Content = new TextBlock
            {
                Text = $": {text} ",
                TextWrapping = TextWrapping.Wrap,
                Width = 800,
                Foreground = Brushes.LightBlue,
                FontSize = 15,
            };
            return topic_item;

        }
        // This method creates a ListViewItem with the content "{name}" styled in white and with a font size of 15, where {name} is the input parameter.
        public ListViewItem user_name(string name)
        {
            ListViewItem Name_item = new ListViewItem();
            Name_item.Content = new TextBlock
            {
                Text = $"{name}",
                Foreground = Brushes.White,
                FontSize = 15,
            };
            return Name_item;
        }
        // This method creates a ListViewItem with the content ": {text}" styled in yellow and with a font size of 15, where {text} is the input parameter.
        public ListViewItem message_input(string text)
        {
            ListViewItem Message_item = new ListViewItem();
            Message_item.Content = new TextBlock
            {
                Text = $": {text}",
                Foreground = Brushes.Yellow,
                FontSize = 15
            };
            return Message_item;
        }
        // This method creates a ListViewItem with the content ": {text}" styled in red and with a font size of 15, where {text} is the input parameter. This is used to indicate that no information was found for the given topic.
        public ListViewItem No_Info(string text)
        {
            ListViewItem no_topic_found = new ListViewItem();
            no_topic_found.Content = new TextBlock
            {
                Text = $": {text}",
                Foreground = Brushes.Red,
                FontSize = 15
            };
           
            return no_topic_found;
        }
        public ListViewItem welcome_user(string text)
        {
            ListViewItem welcome_item = new ListViewItem();
            welcome_item.Content = new TextBlock()
            {

                Text = text,
                Foreground = Brushes.LightBlue,
                FontSize = 15,

            };
            return welcome_item;
        }
        public ListViewItem return_sentiment_support_and_tip(string sentiment, string tip)
        {
          
            ListViewItem topic_item = new ListViewItem();
            topic_item.Content = new TextBlock
            {
                Text = $": {sentiment} \n {tip} ",
                TextWrapping = TextWrapping.Wrap,
                Width = 800,
                Foreground = Brushes.LightBlue,
                FontSize = 15,
            };
            return topic_item;

        }

    }
    
}
