using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Effects;
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
                FontSize = 13,
            };
            return item;
        }
        // This method creates a ListViewItem with the content ": {text} " styled in light blue and with a font size of 15, where {text} is the input parameter.
        public ListViewItem topic_item(string text)
        {
            TextBlock textBlock = new TextBlock
            {
                Text = $": {text}",
                TextWrapping = TextWrapping.Wrap,
                Width = 650,
                Foreground = Brushes.Black,
                FontSize = 17,
                Margin = new Thickness(5)
               
            };

            Border border = new Border
            {
                CornerRadius = new CornerRadius(40),
                Background = Brushes.DarkCyan,
                BorderThickness = new Thickness(1.5),
                Padding = new Thickness(10),
                Child = textBlock,

                Effect = new DropShadowEffect
                {
                    BlurRadius = 10,
                    ShadowDepth = 2,
                    Color = Colors.Cyan,
                    Opacity = 0.25
                }
            };

            ListViewItem topic_item = new ListViewItem
            {
                Content = border,
                Background = Brushes.Transparent,
                BorderThickness = new Thickness(1)
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
                Foreground = Brushes.WhiteSmoke,
                FontSize = 13,
            };
            return Name_item;
        }
        // This method creates a ListViewItem with the content ": {text}" styled in yellow and with a font size of 15, where {text} is the input parameter.
        public  ListViewItem message_input(string text)
        {
            TextBlock textBlock = new TextBlock
            {
                Text = $": {text}",
                TextWrapping = TextWrapping.Wrap,
                HorizontalAlignment = HorizontalAlignment.Left,
                Foreground = Brushes.Yellow,
                FontSize = 17,
                Margin = new Thickness(5)
            };

            Border border = new Border()
            {
                CornerRadius = new CornerRadius(27),
                HorizontalAlignment = HorizontalAlignment.Left,
                Background = Brushes.DarkCyan,
                BorderThickness = new Thickness(1.5),
                Padding = new Thickness(10),
                Child = textBlock,

                Effect = new DropShadowEffect
                {
                    BlurRadius = 10,
                    ShadowDepth = 2,
                    Color = Colors.Cyan,
                    Opacity = 0.25
                }

            };

            ListViewItem Message_item = new ListViewItem()
            {
               Content = border,
               Background = Brushes.Transparent,
               BorderThickness = new Thickness(1)
            };
            return Message_item;
        }
        // This method creates a ListViewItem with the content ": {text}" styled in red and with a font size of 15, where {text} is the input parameter. This is used to indicate that no information was found for the given topic.
        public ListViewItem No_Info(string text)
        {
            TextBlock textBlock = new TextBlock
            {
                Text = $": {text}",
                TextWrapping = TextWrapping.Wrap,
                Foreground = Brushes.Red,
                FontSize = 17,
                Margin = new Thickness(5)
            };
        

            Border border = new Border()
            {
                CornerRadius = new CornerRadius(27),
                HorizontalAlignment = HorizontalAlignment.Left,
                Background = Brushes.DarkCyan,
                BorderThickness = new Thickness(1.5),
                Padding = new Thickness(10),
                Child = textBlock,

                Effect = new DropShadowEffect
                {
                    BlurRadius = 10,
                    ShadowDepth = 2,
                    Color = Colors.Cyan,
                    Opacity = 0.25
                }

            };
            ListViewItem no_topic_found = new ListViewItem()
            {
               Content = border,
               Background = Brushes.Transparent,
               BorderThickness = new Thickness(1)
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
                FontSize = 13,

            };
            return welcome_item;
        }
        public ListViewItem return_sentiment_support_and_tip(string sentiment, string tip)
        {
            TextBlock block = new TextBlock()
            {
                Text = $": {sentiment} \n {tip} ",
                TextWrapping = TextWrapping.Wrap,
                Foreground = Brushes.LightBlue,
                FontSize = 16,
                Margin = new Thickness(5)

            };

            Border border = new Border()
            {
                CornerRadius = new CornerRadius(27),
                Width = 650,
                Background = Brushes.DarkCyan,
                BorderThickness = new Thickness(1.5),
                Padding = new Thickness(10),
                Child = block,
                Effect = new DropShadowEffect
                {
                    BlurRadius = 10,
                    ShadowDepth = 2,
                    Color = Colors.Cyan,
                    Opacity = 0.25
                }
            };
            ListViewItem topic_item = new ListViewItem()
            {
                Content = border,
                Background = Brushes.Transparent,
                BorderThickness = new Thickness(1)
            };
            return topic_item;

        }
       

    }
    
}
