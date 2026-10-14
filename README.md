# Booking System – individual coding exam

A console application for managing meeting room bookings, built with C# and .NET 10. Users can create, search, view, and cancel bookings, with validation to ensure room capacity and booking times are respected.

## Features
- Create meetingroom bookings
- Show all booking that's not canceled
- Search for bookings by full name or partial name, case-insensitive
- Validation for booking details, room capacity, and times
- Prevent overlapping booking times for the same room
- Cancel bookings bookings
- Store bookings in a JSON file to preserve data between application runs

## Project structure
```bash
BookingSystemExam/
├── src/
│   └── BookingSystem/
│       ├── Models/
│       ├── Services/
│       ├── Repositories/
│       ├── ConsoleUI/
│       ├── data/
│       └── Program.cs
├── tests/
│   └── BookingSystem.Tests/
├── .gitignore
├── docs/
└── README.md
```

## Data storage
The application uses a repository to manage booking data. Bookings are stored in a JSON file, allowing data to persist between application runs.

## Technologies
- C#
- .Net 10
- xUnit

## Tests
The application uses xUnit for automated testing. Tests cover booking creation, input validation, room capacity, overlapping bookings, searching, and cancellation.

## Requirements

- .NET 10 SDK

## Getting started 

### Run the application

```bash
dotnet run --project src/BookingSystem
```

### Run the tests

```bash
dotnet test
```
## Debugging Documentation
See DEBUGGING.md for a description of a bug, its root cause, the implemented fix, and the tests used to verify the solution.
