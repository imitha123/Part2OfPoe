using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part2OfPoe
{
    public class my_dictionary
    {
        // method to return a dictionary of topics and their definitions
        public Dictionary<string, string[]> Topics()
        {

            Dictionary<string, string[]> topics = new Dictionary<string, string[]>()
        {
            { "phishing", new string[] { "Phishing is a cyber attack that uses disguised email as a weapon."
                ,"Phishing involves sending deceptive messages, often via email or text, that appear to come from legitimate sources."
                ,"Phishing is a form of social engineering that manipulates human psychology."
                ,"Phishers disguise themselves as banks, government agencies, online platforms, or even colleagues."
                ,"Phishing is not limited to email. It can occur through phone calls (vishing), text messages (smishing), social media, or fake websites." } },

            { "ransomware", new string[] { "Ransomware is a type of malicious software designed to block access to a computer system until a sum of money is paid."
                ,"Ransomware typically encrypts the victim's files, making them inaccessible until a ransom is paid."
            ,"Ransomware: A type of malware that locks and encrypts a victim's data, rendering it inaccessible until a ransom payment is made."
            ,"Ransomware is a cyberattack method in which hackers take control of a victim’s data or device and demand payment in exchange for restoring access."
            ,"Ransomware is malware designed to deny users access to their information or systems by locking or encrypting them, usually for financial extortion."} },

            { "malware", new string[] { "Malware, short for malicious software, refers to any software intentionally designed to cause damage to a computer, server, client, or computer network."
            ,"Malware is any software intentionally created to harm, exploit, disrupt, or gain unauthorized access to computer systems or networks."
            ,"Malware refers to malicious programs designed to damage devices, steal data, or interfere with normal computer operations."
            ,"Malware is a cybersecurity threat that infects computers or networks to perform unauthorized actions, often resulting in data loss, theft, or system damage."} },

            { "social engineering", new string[] { "Social engineering is the psychological manipulation of people into performing actions or divulging confidential information."
            ,"Social engineering is a manipulation technique used by attackers to trick people into revealing confidential information or performing actions that compromise security."
            ,"Social engineering refers to psychological methods used by cybercriminals to deceive individuals into giving access to systems, passwords, or sensitive data."
            ,"Social engineering is the practice of exploiting human behavior, emotions, or trust to obtain private information or influence someone into making security mistakes."} },

            { "firewall", new string[] { "A firewall is a network security device that monitors and filters incoming and outgoing network traffic based on an organization's previously established security policies."
            ,"A firewall acts as a barrier between a trusted internal network and an untrusted external network, such as the internet."
            ,"A firewall is a crucial component of network security, helping to prevent unauthorized access while allowing legitimate communication." } },

            { "encryption", new string[] { "Encryption is the process of converting information or data into a code to prevent unauthorized access."
            ,"Encryption is a method of protecting data by transforming it into a format that is unreadable without a decryption key."
            ,"Encryption is a fundamental technique in cybersecurity used to safeguard sensitive information from unauthorized disclosure."
            ,"Encryption ensures that even if data is intercepted, it remains unintelligible without the proper decryption keys." } },

                { "cybersecurity", new string[] { "Cybersecurity is the practice of protecting systems, networks, and programs from digital attacks."
                ,"Cybersecurity involves safeguarding sensitive information and maintaining the integrity, availability, and confidentiality of data."
                ,"Cybersecurity is essential in today's digital landscape to protect against evolving threats and ensure the safety of online activities." } }
        };

            return topics;

        }
        // method to return a random response when the chatbot doesn't have information about a topic
        public string[] random_responces()
        {
            string[] responses = new string[]
            {
                " I'm sorry, I don't have information about that .",
                " I don't have information on that, but I'm here to help with anything related to cybersecurity!.",
                " I'm not sure about that, but feel free to ask me anything else about cybersecurity!.",
                " Oops! I seem to have trouble with that. Can you ask something else about cybersecurity? "

            };

            return responses;
        }
        // method to return a random greeting when the chatbot is first started
        public string[] random_greeting()
        {
            string[] greetings = new string[]
            {
                "Hello! I'm your cybersecurity chatbot. How can I assist you today?",
                "Hi there! I'm here to help you with any cybersecurity questions you may have.",
                "Greetings! I'm your friendly cybersecurity chatbot. What can I do for you today?",
                "Welcome! I'm here to provide information and assistance on all things cybersecurity. How can I help you?"
            };
            return greetings;
        }

        //  method to return a random message when the users tells the chatbot their interesting topic and the chatbot tells the user that it will remember that topic 
        public string[] random_remembering_message()
        {
            string[] remembering_messages = new string[]
            {
                "Got it! I'll remember that topic for future conversations.",
                "Thanks for sharing! I'll keep that topic in mind for our future chats.",
                "Great! I'll make a note of that topic for next time we talk.",
                "Understood! I'll remember that topic and bring it up in our future discussions."
            };
            return remembering_messages;



        }
        // method to return a random message when the user asks for more information without first mentioning the topic
        public string[] random_more_info_query_without_topic()
        {
            string[] more_info_queries = new string[]
            {
                "Could you please specify the topic you're interested in?",
                "Sure! Which topic would you like more information about?",
                "I'd be happy to provide more information. Could you please tell me which topic you're referring to?",
                "Of course! To give you the best information, could you please specify the topic you're asking about?"
            };
            return more_info_queries;
        }
    }
}
