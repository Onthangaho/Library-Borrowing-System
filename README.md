# Library-Borrowing-System
A C# console app that manages books, members, and borrowing history using collections, LINQ, and business rules to ensure valid borrowing decisions.

# Overview
This console application models a library borrowing system using C# domain-driven design principles.

The system tracks books, members, and borrowing history while enforcing business rules consistently.

## Features
- Track books and members
- Borrow books with validation
- Prevent borrowing unavailable or reference-only books
- Track borrowing history
- Query and group borrowings using LINQ

## Technologies Used
- .NET 8 SDK
- C#
- Console Application

## Installation
1. Install .NET 8 SDK
2. Create the project:
   dotnet new console
3. Run the application:
   dotnet run

## Business Rules
- A book cannot be borrowed if already active
- Reference-only books cannot be borrowed
- Borrowings must reference existing books and members
- Invalid actions fail fast

## Created by
- Onthangaho Magoro