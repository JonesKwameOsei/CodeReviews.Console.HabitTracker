# 🚀 Habit Tracker Console App

A simple, robust C# console application for tracking habits, built with raw SQL
and SQLite. Log, update, and review your daily habits with ease!

---

> Note: For the best UI experience, run the App on a Unix based terminal or
> console (GitBash on Windows).

## 📑 Table of Contents

- [Overview](#overview)
- [Project Requirements](#project-requirements)
- [Features](#features)
- [Challenges](#challenges)
- [Skills Acquired](#skills-acquired)
- [Further Learning & Improvement](#further-learning--improvement)
- [Resources](#resources)

---

## 📝 Overview

This Habit Tracker is a C# console application designed to help users log and
manage their daily habits. It uses a local SQLite database (created
automatically) and interacts with it using only raw SQL commands. The app is
reliable, user-friendly, and crash-resistant.

---

## ⚙️ Project Requirements

The console app should: 👇

- Automatically create a SQLite database and table if not present.
- Log hours for your habits (insert, update, delete, view).
- Handles all errors gracefully—no crashes!
- Application exits only when the user enters `0`.
- All database operations use raw SQL (no ORMs like Entity Framework).
- Includes reporting capabilities for logged habits.

---

## ✨ Features

- 🛢️ The app uses a local SQLite for database operations <br>

  ![alt text](/images/image.png) <br>

- 📅 Log your daily habit hours <br> ![alt text](/images/habit.png)

  ![alt text](/images/watertracker.png) ![alt text](/images/walkingtracker.png)

- 👀 View all your habit logs ![view walking logs](/images/walklog.png)

  ![view water logs](/images/waterlog.png)

- 📝 Update or delete existing logs ![alt text](/images/update.png)
  ![alt text](/images/delete.png)

- 📊 Simple reporting on your progress ![alt text](/images/image4.png)
  ![alt text](/images/image-1.png) ![alt text](/images/image-2.png)
- 🛡️ Robust error handling for a smooth experience
  ![alt text](/images/image-3.png)

---

## 🧩 Challenges

Some of the challenges I faced were: 👇

- Ensuring coding style and practices adheres to the `SOLID` principles
- Managing all database operations with raw SQL
- Implementing comprehensive error handling
- Designing a user-friendly console interface but `Spectre Console` made this
  manageable

---

## 🛠️ Skills Acquired

- Working with SQLite in C#
- Writing and executing raw SQL queries with C#
- Error handling and defensive programming
- Structuring a modular C# console application

---

## 📚 Further Learning & Improvement

- Dive deeper into SOLID principles and OOP
- Practice more on SQL databases
- Add more habit types and categories
- Implement data export (CSV, JSON)
- Add Advanced analytics and visual reports
- Build a GUI or web interface
- Integrate authentication for multiple users

---

## 🔗 Resources

- [The CSharp Academy](https://www.thecsharpacademy.com/)
- [SQLite Documentation](https://www.sqlite.org/docs.html)
- [C# ADO.NET Guide](https://learn.microsoft.com/en-us/dotnet/framework/data/adonet/)
- [Spectre.Console for C#](https://spectreconsole.net/)
- [Raw SQL in C#](https://learn.microsoft.com/en-us/dotnet/framework/data/adonet/using-parameters-with-a-sqlcommand-and-a-sqlparameter)

---
