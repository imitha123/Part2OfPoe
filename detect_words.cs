using System.Collections.Generic;

namespace Part2OfPoe
{
    public class detect_words
    {
       public List<string> user_events = new List<string>();
        public string[] addTaskKeywords =
{
    "add task",
    "create a task",
    "new task",
    "make a task",
    "insert a task",
    "schedule a task"
};

        public string[] viewTaskKeywords =
        {
    "view task",
    "view tasks",
    "show tasks",
    "list tasks",
    "my tasks",
    "display tasks",
    "see tasks",
    "all tasks"
};

        public string[] completeTaskKeywords =
        {
    "complete task",
    "finish task",
    "mark task complete",
    "mark complete",
    "done task",
    "task completed"
};

        public string[] deleteTaskKeywords =
        {
    "delete task",
    "remove a task",
    "erase a task",
    "discard a task"
};

        public string[] reminderKeywords =
        {
    "reminder",
    "remind me",
    "set reminder",
    "remind",
    "notification",
    "alert"
};

       public string[] quizKeywords =
        {
    "quiz",
    "mini quiz",
    "mini game",
    "game",
    "play quiz",
    "play game",
    "start quiz",
    "start game"
};

       public string[] showActivityLogKeywords =
 {
    "activity log",
    "show my activity log",
    "view activity log",
    "display activity log",
    "open activity log",
    "see activity log",
    "my activity log",
    "show my activity log",
    "view my activity log",
    "display my activity log",
    "show activities",
    "view activities",
    "display activities",
    "show history",
    "view history",
    "activity history",
    "task history",
    "show task history",
    "view task history",
    "display task history",
    "show completed history",
    "recent activities",
    "show recent activities",
    "view recent activities",
    "what have i done",
    "what activities have i completed",
    "show my progress",
    "view progress",
    "show log",
    "view log"
};


        public bool ContainsKeyword(string message, string[] keywords)
        {
            message = message.ToLower();

            foreach (string keyword in keywords)
            {
                if (message.Contains(keyword))
                    return true;
            }

            return false;
        }

        public void save_events(string events)
        {
            user_events.Add(events);

        }

        public List<string> show_activitiwes()
        {

            return user_events;
        }
    }
}