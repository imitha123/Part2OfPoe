using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part2OfPoe
{
    public class my_dictionary_and_arrays
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
        public string[] random_responces_if_no_info()
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
        // method to return a random message asking the user if they are interested in the topic they wanted more information about
        public string[] random_ask_user_if_they_are_interested_in_topic()
        {
            string[] ask_user_if_they_are_interested_in_topic = new string[]
            {
               "Oh, you're interested in that topic?",
                "I see you're curious about that topic! Are you interested in it?",
                "That topic is quite interesting! Are you interested in learning more about it?",
                "It seems like you want to know more about that topic! Are you interested in it?"
            };
            return ask_user_if_they_are_interested_in_topic;
        }
        // method to return a random message when the user is not interested in the topic they wanted more information about
        public string[] random_not_interested_in_topic()
        {
            string[] not_interested_messages = new string[]
            {
                "No worries! Is there anything else you'd like to know about cybersecurity?",
                "Understood! Would you like to explore a different topic related to cybersecurity?",
                "Got it! Do you have any other questions about cybersecurity?",
                "Alright! Feel free to ask about anything else related to cybersecurity."
            };
            return not_interested_messages;
        }
        // method to return a random message when the user's favorite topic is not found in the topics.txt file
        public string[] random_favorite_topic_not_found()
        {
            string[] favorite_topic_not_found_messages = new string[]
            {
              "I was not able to find your favorite topic in my database. " +
              "\nIf you'd like me to remember your favorite topic, just ask me about it again!" +
              "\nUsing Phrases like 'tell me more' or 'explain more'",

              "Your Favorite topic was not found!. " +
              "\nIf you'd like me to remember your favorite topic, just ask me about it again!" +
              "\nUsing Phrases like 'tell me more' or 'explain more'",

              "I am sorry but I don't know your favorite topic " +
              "\nIf you'd like me to remember your favorite topic, just ask me about it again!" +
              "\nUsing Phrases like 'tell me more' or 'explain more'"
            };
            return favorite_topic_not_found_messages;
        }
        public Dictionary<string, string[]> sentiment_detection()
        {
            Dictionary<string, string[]> sentiment_detec = new Dictionary<string, string[]>
            {
                {"worried", new string[] {"It's completely okay to feel worried. Scammers can be very convincing, but remember that legitimate organizations will never ask for sensitive information over the phone or via email.",
                                           "It's okay to feel that way. The internet can be a scary place, but remember to stay informed and vigilant.",
                                           "Don't worry, you're not alone in this. I can always help you navigate through these concerns." } },
                {"scared", new string[] {"It's normal to feel scared when dealing with potential scams. Just remember to stay calm and never share personal information with anyone you don't trust.",
                                         "It's understandable to feel that way. Just don't let fear control you.",
                                         "Online safety is important, and it's okay to be concerned about it" } },
                {"confused", new string[] {"Feeling confused is understandable, especially with the many types of scams out there. If you're unsure about something, it's always best to verify it through official channels.",
                                           "Confusion is what the scammers are counting on. So try not to get too caught up in the details.",
                                           "Take your time to understand the situation. It's important to be informed before making any decisions."} },
                {"angry", new string[] {"It's natural to feel angry when you encounter scams. Just remember that scammers thrive on fear and anger, so try to stay calm and report any suspicious activity to the authorities.",
                                        "It's okay to feel angry, but try not to let it cloud your judgment. Stay informed and seek help when needed.",
                                         "It's understandable to feel angry, but try to channel that energy into taking action."} },
                {"frustrated", new string[] {"Feeling frustrated is common when dealing with scams. Just remember that you're not alone, and there are resources available to help you protect yourself from scammers.",
                                             "It's okay to feel frustrated. Take a deep breath and focus on the steps you can take to protect yourself.",
                                             "You're not alone in this. There are people and resources available to help you navigate through these challenges."} }
            };
            return sentiment_detec;
        }
        public string[] user_tips()
        {
            string[] onlineSafetyTips =
                {
    "Here's a tip: \nUse strong and unique passwords - Strong passwords are harder to guess and unique passwords prevent multiple accounts from being hacked at once.",
    "Here's a tip: \nEnable two-factor authentication - This adds an extra layer of security by requiring a second verification step when logging in.",
    "Here's a tip: \nDo not click suspicious links - Unknown links may contain scams, viruses, or phishing websites designed to steal information.",
    "Here's a tip: \nKeep your software updated - Updates fix security weaknesses and protect your device from new threats.",
    "Here's a tip: \nAvoid sharing personal information online - Sharing sensitive details can expose you to identity theft and scams.",
    "Here's a tip: \nUse antivirus and firewall protection - These tools help detect, block, and remove harmful software.",
    "Here's a tip: \nBe careful when using public Wi-Fi - Public networks are less secure and hackers may intercept your information.",
    "Here's a tip: \nVerify websites before entering passwords - Fake websites can steal login information by pretending to be trusted sites.",
    "Here's a tip: \nDo not download unknown files - Untrusted downloads may contain malware or viruses that damage your device.",
    "Here's a tip: \nLog out of accounts on shared devices - Logging out prevents other users from accessing your personal accounts."
                };
            return onlineSafetyTips;
        }

        public Dictionary<string, string[]> quiz_question()
        {
            Dictionary<string, string[]> cybersecurityQuiz = new Dictionary<string, string[]>
{
    {
        "What is cybersecurity?",
        new string[]
        {
            "A. A type of computer hardware",
            "B. Protecting systems, networks, and data from digital attacks", // Correct
            "C. A software development language",
            "D. A process for increasing internet speed",
            "E. A method of building physical security fences"
        }
    },
    {
        "What is phishing?",
        new string[]
        {
            "A. A way to improve Wi-Fi signal strength",
            "B. A type of antivirus software",
            "C. A scam that tricks users into revealing sensitive information", // Correct
            "D. A method of backing up files",
            "E. A computer programming language"
        }
    },
    {
        "What is malware?",
        new string[]
        {
            "A. Software used for graphic design",
            "B. A secure operating system",
            "C. Malicious software designed to harm systems", // Correct
            "D. A type of computer monitor",
            "E. A database management tool"
        }
    },
    {
        "What does a firewall do?",
        new string[]
        {
            "A. Stores files online",
            "B. Repairs damaged hard drives",
            "C. Monitors and controls network traffic", // Correct
            "D. Creates passwords automatically",
            "E. Cools down computer hardware"
        }
    },
    {
        "Why should you use strong passwords?",
        new string[]
        {
            "A. They improve screen resolution",
            "B. They are harder for attackers to guess", // Correct
            "C. They reduce electricity usage",
            "D. They increase computer storage",
            "E. They make your internet faster"
        }
    },
    {
        "What is two-factor authentication (2FA)?",
        new string[]
        {
            "A. Creating two email accounts",
            "B. A second verification step for logging in", // Correct
            "C. Connecting to two Wi-Fi networks",
            "D. Having two antivirus programs",
            "E. Using two computers at once"
        }
    },
    {
        "What should you do with a suspicious email?",
        new string[]
        {
            "A. Reply with your password",
            "B. Disable your antivirus",
            "C. Open all attachments immediately",
            "D. Avoid clicking links and verify the sender", // Correct
            "E. Forward it to everyone"
        }
    },
    {
        "What is a computer virus?",
        new string[]
        {
            "A. A backup device",
            "B. A type of malware that can spread between systems", // Correct
            "C. A network cable",
            "D. A secure web browser",
            "E. A computer cooling system"
        }
    },
    {
        "Why are software updates important?",
        new string[]
        {
            "A. They improve keyboard durability",
            "B. They often fix security vulnerabilities", // Correct
            "C. They remove the need for passwords",
            "D. They permanently increase RAM",
            "E. They make all files smaller"
        }
    },
    {
        "What is an antivirus program?",
        new string[]
        {
            "A. A computer game",
            "B. A type of processor",
            "C. Software that detects and removes malware", // Correct
            "D. A cloud storage service",
            "E. A tool for creating websites"
        }
    }
};
            return cybersecurityQuiz;
        }

        public Dictionary<int, string> quiz_answers()
        {
            Dictionary<int, string> cybersecurityQuiz = new Dictionary<int, string>
    {
        { 0, "b" },
        { 1, "c" },
        { 2, "c" },
        { 3, "c" },
        { 4, "b" },
        { 5, "b" },
        { 6, "d" },
        { 7, "b" },
        { 8, "b" },
        { 9, "c" }
    };

            return cybersecurityQuiz;
        }

        public Dictionary<int, string> quiz_explanations()
        {
            Dictionary<int, string> quizExplanations = new Dictionary<int, string>
{
    {
        0,
        "Cybersecurity is the practice of protecting computers, networks, systems, and data from unauthorized access, attacks, and damage."
    },
    {
        1,
        "Phishing is a cyberattack where criminals impersonate trusted organizations or people to trick users into revealing passwords, banking details, or other sensitive information."
    },
    {
        2,
        "Malware is malicious software such as viruses, worms, ransomware, and spyware that is designed to damage or exploit computer systems."
    },
    {
        3,
        "A firewall acts as a security barrier by monitoring and filtering incoming and outgoing network traffic based on security rules."
    },
    {
        4,
        "Strong passwords are difficult for attackers to guess or crack, helping to protect accounts from unauthorized access."
    },
    {
        5,
        "Two-factor authentication (2FA) adds an extra layer of security by requiring a second form of verification in addition to a password."
    },
    {
        6,
        "Suspicious emails should never be trusted immediately. Avoid clicking links or attachments until you've confirmed the sender is legitimate."
    },
    {
        7,
        "A computer virus is a type of malware that can replicate itself and spread to other files or computers, often causing damage."
    },
    {
        8,
        "Software updates often contain security patches that fix vulnerabilities attackers could exploit."
    },
    {
        9,
        "Antivirus software scans for, detects, blocks, and removes malware to help keep a computer secure."
    }
};
            return quizExplanations;


        }
}
}
