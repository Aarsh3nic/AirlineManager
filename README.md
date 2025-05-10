# Airline Management System

## Overview
The Airline Management System is a WPF-based desktop application designed to manage airline operations. It provides functionality to handle passengers, flights, airlines, and customers efficiently. The system uses various data structures like stacks, queues, and lists to manage data and offers a user-friendly graphical interface for navigation and operations.

## Features
- **Passenger Management**: Add, retrieve, and delete passenger records using a stack-based structure.
- **Flight Management**: Manage flight details, including departure and destination cities, dates, and flight times.
- **Airline Management**: Handle airline details such as airplane types, seat availability, and meal options using a queue-based structure.
- **Customer Management**: Manage customer information and link them to flights and passengers.
- **User Interface**: Navigate between pages like Flights, Airlines, Passengers, and Customers with a WPF-based GUI.

## Installation
1. **Prerequisites**:
   - Install [.NET Core 3.1 SDK](https://dotnet.microsoft.com/download/dotnet/3.1).
   - Install Visual Studio 2022 with the **.NET Desktop Development** workload.

2. **Clone the Repository**:
   
3. **Open the Project**:
   - Open the `Midterm_CS.sln` file in Visual Studio.

4. **Set the Startup Project**:
   - Right-click on the `Midterm_CS` project in the Solution Explorer and select __Set as Startup Project__.

5. **Run the Application**:
   - Press `F5` or click the __Start__ button in Visual Studio.

## Usage
- Navigate through the application using the menu or buttons on the home page.
- Perform CRUD operations on passengers, flights, airlines, and customers.
- Use the help page for guidance on using the application.

## Project Structure
- **Passenger.cs**: Manages passenger data using a stack.
- **Flights.cs**: Handles flight data using a list.
- **Airlines.cs**: Manages airline data using a queue.
- **HomePage.xaml.cs**: Acts as the main navigation hub.
- **HelpPage.xaml.cs**: Provides user assistance and documentation.

## License
This project is licensed under the MIT License. See the LICENSE file for details.
