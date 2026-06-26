namespace Part2OfPoe
{
    public class detect_words
    {
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
    "delete a task",
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

        public string[] showCompletedActivitiesKeywords =
{
    "show me completed tasks",
    "view completed tasks",
    "completed tasks",
    "show completed activities",
    "view completed activities",
    "my completed tasks",
    "show activity log",
    "my completed activities",
    "display completed tasks",
    "display completed activities",
    "list completed tasks",
    "list completed activities",
    "what have i completed",
    "what did i complete",
    "tasks i completed",
    "activities i completed",
    "finished tasks",
    "finished activities",
    "done tasks",
    "done activities",
    "what is completed",
    "show me what i completed",
    "show what i've completed",
    "show me completed tasks",
    "show me completed activities"
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
    }
}