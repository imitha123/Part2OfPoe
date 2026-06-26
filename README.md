# Smart Task Assistant Chatbot

## Overview

The Smart Task Assistant Chatbot is a desktop application developed in **C# using WPF**. It combines task management with an interactive chatbot interface, allowing users to manage their daily activities using natural language commands instead of traditional buttons and menus.

The chatbot can understand various user commands, maintain an activity log, manage reminders, and provide an educational mini quiz to improve user engagement.

---

## Features

### Task Management

- Add new tasks
- View all tasks
- Mark tasks as completed
- Delete tasks
- Display completed tasks
- Store task information in a SQL Server database

### Reminder System

- Set reminders for tasks
- Support reminders with optional dates and times
- Store reminder information in the database

### Natural Language Processing (NLP)

The chatbot recognizes multiple ways of asking the same question using keyword detection.

Examples include:

- "add task"
- "create task"
- "new task"
- "show completed tasks"
- "view activity log"
- "help"

This allows users to interact with the chatbot more naturally.

### Activity Log

The chatbot records important user actions such as:

- Quiz started
- Task completed
- Task added
- Task deleted

Users can request their activity history at any time.

### Mini Quiz

The chatbot includes an educational multiple-choice quiz.

Features include:

- Random question generation
- Answer validation
- Explanations after correct answers
- Quiz scoring
- Prevention of duplicate questions during a quiz session
- Ability to exit the quiz at any time

---

## Technologies Used

- C#
- WPF (Windows Presentation Foundation)
- .NET
- SQL Server
- ADO.NET
- Visual Studio

---

## Project Structure

```
SmartTaskAssistant/
│
├── Database/
│   └── SQL scripts
│
├── Repository/
│   └── Database operations
│
├── NLP/
│   └── Keyword detection
│
├── Dictionary/
│   └── Quiz questions
│   └── Quiz answers
│   └── Quiz explanations
│
├── UI/
│   └── WPF interface
│
└── MainWindow.xaml.cs
```

---

## Database

The application stores task information inside SQL Server.

Example fields include:

- Task ID
- Task Title
- Description
- Reminder Time
- Completion Status (`is_completed`)

---

## Example Commands

### Tasks

```
add task
create task
show tasks
view tasks
complete task 3
delete task 5
show completed tasks
```

### Quiz

```
mini quiz
answer: A
answer: C
exit quiz
```

### Activity Log

```
show activity log
view activity log
show history
show key actions
```

### Help

```
help
commands
what can you do
```

---

## Learning Outcomes

This project demonstrates:

- Object-Oriented Programming
- WPF application development
- SQL Server integration
- CRUD operations
- Event-driven programming
- Collections (Lists, Dictionaries)
- Randomized algorithms
- Natural Language Processing using keyword matching
- Exception handling
- Software design and application architecture

---

## Future Improvements

Potential enhancements include:

- Smarter NLP using sentence analysis instead of keyword matching
- User accounts and authentication
- Task categories and priorities
- Reminder notifications
- Data visualisation for completed tasks
- AI-powered conversational responses
- Export tasks to PDF or Excel
- Cloud database integration

---

## Author

**Imitha Maneli**

Software Development Student

---

## License

This project was developed for educational purposes.
