# Mynewapp

A modern web application with real-time updates, secure authentication, and advanced features.

## Features

- Secure Authentication with SHA-256 password hashing
- Real-time Updates using Socket.IO
- Modern UI with responsive design
- Role-based authorization
- Database integration with SQL Server Express

## Prerequisites

- Node.js (v14 or higher)
- npm (v6 or higher)
- SQL Server Express (instance: IT-L14-02\INSTANCE1)
- PowerShell 5.1 or higher

## Project Structure

- **frontend/**: React application with TypeScript
- **backend/**: Node.js/Express API with TypeScript
- **setup_database.sql**: SQL script to create database tables
- **execute_sql_script.ps1**: PowerShell script to execute SQL script
- **start_app.ps1**: PowerShell script to start both frontend and backend

## Setup Instructions

1. **Clone the repository**

2. **Set up the database**
   - Ensure SQL Server Express is running
   - Run the following PowerShell script to create database tables:
     `
     .\execute_sql_script.ps1
     `

3. **Install dependencies**
   - Frontend:
     `
     cd frontend
     npm install
     `
   - Backend:
     `
     cd backend
     npm install
     `

4. **Start the application**
   - Run the following PowerShell script to start both frontend and backend:
     `
     .\start_app.ps1
     `
   - Frontend will be available at: http://localhost:3000
   - Backend API will be available at: http://localhost:3001

## Default Admin Credentials

- Email: admin@example.com
- Password: Admin123!

## Development

- **Frontend**: React with TypeScript, Bootstrap, Redux, and Socket.IO
- **Backend**: Node.js/Express with TypeScript, SQL Server, and Socket.IO
- **Database**: SQL Server Express

## License

This project is licensed under the MIT License - see the LICENSE file for details.
