# execute_sql_script.ps1
# This script executes the SQL script to create database tables

param(
    [string]$SqlInstance = "IT-L14-02\INSTANCE1",
    [string]$SqlDatabase = "Mynewapp-DB",
    [string]$ScriptPath = "$PSScriptRoot\setup_database.sql"
)

# Error handling to prevent window from closing on error
$ErrorActionPreference = "Stop"
trap {
    Write-Host "An error occurred: $_" -ForegroundColor Red
    Write-Host "Stack Trace: $($_.ScriptStackTrace)" -ForegroundColor Red
    Read-Host -Prompt "Press Enter to exit"
    exit 1
}

# Check if SqlServer module is available
if (-not (Get-Module -ListAvailable -Name SqlServer)) {
    Write-Host "SqlServer module not found. Installing..." -ForegroundColor Yellow
    Install-Module -Name SqlServer -Force -AllowClobber -Scope CurrentUser -ErrorAction Stop
    Write-Host "SqlServer module installed successfully" -ForegroundColor Green
}

# Import the module
Import-Module SqlServer -ErrorAction Stop

# Execute SQL script
try {
    Write-Host "Executing SQL script to create database tables..." -ForegroundColor Cyan
    Invoke-Sqlcmd -ServerInstance $SqlInstance -Database $SqlDatabase -InputFile $ScriptPath -TrustServerCertificate
    Write-Host "SQL script executed successfully" -ForegroundColor Green
}
catch {
    Write-Host "Error executing SQL script: $_" -ForegroundColor Red
    Read-Host -Prompt "Press Enter to exit"
    exit 1
}

Write-Host "Database setup completed successfully" -ForegroundColor Green
Read-Host -Prompt "Press Enter to exit"
