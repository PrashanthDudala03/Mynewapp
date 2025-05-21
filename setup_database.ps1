# setup_database.ps1
# This script creates and applies database migrations

param(
    [string]$ProjectName = "Mynewapp",
    [string]$ProjectPath = "C:\Projects\Mynewapp\Mynewapp"
)

# Error handling to prevent window from closing on error
$ErrorActionPreference = "Stop"
trap {
    Write-Host "An error occurred: $_" -ForegroundColor Red
    Write-Host "Stack Trace: $($_.ScriptStackTrace)" -ForegroundColor Red
    Read-Host -Prompt "Press Enter to exit"
    exit 1
}

# Create timestamp for logging
$timestamp = Get-Date -Format "yyyy-MM-dd HH:mm:ss"
$logFile = "$ProjectPath\migration_log.txt"

# Function to log messages
function Write-Log {
    param([string]$Message)
    $logMessage = "[$timestamp] $Message"
    Write-Host $logMessage
    Add-Content -Path $logFile -Value $logMessage
}

# Navigate to project directory
Set-Location $ProjectPath
Write-Log "Current directory: $(Get-Location)"

# Add initial migration
Write-Log "Adding initial migration"
try {
    dotnet ef migrations add InitialCreate
    if ($LASTEXITCODE -ne 0) {
        throw "dotnet ef migrations add command failed with exit code $LASTEXITCODE"
    }
}
catch {
    Write-Log "Error adding migration: $_"
    Write-Log "Make sure you have installed the EF Core tools: dotnet tool install --global dotnet-ef"
    Read-Host -Prompt "Press Enter to exit"
    exit 1
}

# Apply migration to database
Write-Log "Applying migration to database"
try {
    dotnet ef database update
    if ($LASTEXITCODE -ne 0) {
        throw "dotnet ef database update command failed with exit code $LASTEXITCODE"
    }
}
catch {
    Write-Log "Error applying migration: $_"
    Read-Host -Prompt "Press Enter to exit"
    exit 1
}

Write-Log "Database migration completed successfully"
Read-Host -Prompt "Press Enter to exit"
