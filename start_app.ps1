# start_app.ps1
# This script starts both the frontend and backend applications

param(
    [string]$ProjectPath = "C:\Projects\Mynewapp"
)

# Error handling to prevent window from closing on error
$ErrorActionPreference = "Stop"
trap {
    Write-Host "An error occurred: $_" -ForegroundColor Red
    Write-Host "Stack Trace: $($_.ScriptStackTrace)" -ForegroundColor Red
    Read-Host -Prompt "Press Enter to exit"
    exit 1
}

# Function to check if a process is running on a port
function Test-PortInUse {
    param(
        [int]$Port
    )
    
    $connections = netstat -ano | findstr ":$Port "
    return $connections.Length -gt 0
}

# Start backend server
function Start-Backend {
    Write-Host "Starting backend server..." -ForegroundColor Cyan
    
    # Check if port 3001 is already in use
    if (Test-PortInUse -Port 3001) {
        Write-Host "Port 3001 is already in use. Please stop the process using this port and try again." -ForegroundColor Yellow
        return
    }
    
    # Navigate to backend directory
    Set-Location "$ProjectPath\backend"
    
    # Build TypeScript
    Write-Host "Building TypeScript..." -ForegroundColor Cyan
    npm run build
    
    # Start backend server
    Start-Process -FilePath "cmd.exe" -ArgumentList "/c npm run dev" -WindowStyle Normal
    
    Write-Host "Backend server started on http://localhost:3001" -ForegroundColor Green
}

# Start frontend server
function Start-Frontend {
    Write-Host "Starting frontend server..." -ForegroundColor Cyan
    
    # Check if port 3000 is already in use
    if (Test-PortInUse -Port 3000) {
        Write-Host "Port 3000 is already in use. Please stop the process using this port and try again." -ForegroundColor Yellow
        return
    }
    
    # Navigate to frontend directory
    Set-Location "$ProjectPath\frontend"
    
    # Start frontend server
    Start-Process -FilePath "cmd.exe" -ArgumentList "/c npm start" -WindowStyle Normal
    
    Write-Host "Frontend server started on http://localhost:3000" -ForegroundColor Green
}

# Start both servers
Start-Backend
Start-Frontend

Write-Host "Both servers are now running." -ForegroundColor Green
Write-Host "Frontend: http://localhost:3000" -ForegroundColor Green
Write-Host "Backend: http://localhost:3001" -ForegroundColor Green
Write-Host "Press Ctrl+C to stop the servers." -ForegroundColor Yellow

# Keep the script running
try {
    while ($true) {
        Start-Sleep -Seconds 10
    }
}
catch {
    Write-Host "Stopping servers..." -ForegroundColor Cyan
}
