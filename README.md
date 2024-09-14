Employment Hub - Dashboard Application
Description
Employment Hub is a web-based dashboard application designed to manage repair scheduling, requests, and appointment tracking. The dashboard provides an intuitive UI for users to schedule repairs, submit requests, and track their ongoing appointments. It leverages a React frontend with Ant Design components and a .NET backend API connected to a MySQL database.

Features
Dashboard Overview: Displays scheduled repairs and appointments.
Schedule Repair: Users can schedule repairs using a calendar interface.
Submit Request: Allows users to submit requests via a simple form.
Appointment Table: Displays all scheduled repairs and their statuses (Pending, In Progress, Completed).
User Authentication: The backend is secured via JWT-based authentication.
Technologies
Frontend: React.js, Ant Design, Axios
Backend: ASP.NET Core (.NET 6), Entity Framework Core, MySQL
Database: MySQL
Authentication: JWT (JSON Web Token)
Styling: Ant Design, Custom CSS
Deployment: Local development, Docker support (if applicable)
Getting Started
Prerequisites
To run this project locally, ensure you have the following installed:

Node.js (v16.x or higher)
npm (Comes with Node.js)
.NET SDK (v6.0 or higher)
MySQL (v8.x or higher)

Frontend code is contained in the demo-project update: use npm start to run
Run locally on port 3000
Backend code is in the backend folder: use dotnet run to start the server
Run locally on port 5235

Database Setup
Make sure MySQL is installed and running. The application is configured to connect to MySQL, and the database tables will be automatically created using Entity Framework Migrations.

Port: 3306 (default MySQL port)
Database Name: myappdb

Future improvements and adjustments are to come soon! 
