# SQL Express Setup Script for Mynewapp

# Download SQL Express installer
Write-Host "Downloading SQL Server Express installer..." -ForegroundColor Yellow
 = "https://go.microsoft.com/fwlink/?linkid=866658"
 = "C:\Users\PRASHA~1\AppData\Local\Temp\SQL2019-SSEI-Expr.exe"
Invoke-WebRequest -Uri  -OutFile 

# Run the installer (Basic installation )
Write-Host "Installing SQL Server Express..." -ForegroundColor Yellow
Write-Host "This may take several minutes. Please wait..." -ForegroundColor Yellow
Start-Process -FilePath  -ArgumentList "/ACTION=Install", "/IACCEPTSQLSERVERLICENSETERMS", "/QUIET", "/INSTANCENAME=INSTANCE1" -Wait

# Verify installation
Write-Host "Verifying SQL Server installation..." -ForegroundColor Yellow
 = Get-Service -Name MSSQL*
if () {
    Write-Host "SQL Server Express installed successfully!" -ForegroundColor Green
     | Format-Table Name, DisplayName, Status
} else {
    Write-Host "SQL Server Express installation may have failed. Please check manually." -ForegroundColor Red
}

# Configure SQL Server to allow remote connections
Write-Host "Configuring SQL Server for remote connections..." -ForegroundColor Yellow
# Enable TCP/IP
 = [System.Reflection.Assembly]::LoadWithPartialName('Microsoft.SqlServer.SqlWmiManagement')
 = New-Object Microsoft.SqlServer.Management.Smo.Wmi.ManagedComputer
 = .GetSmoObject("ManagedComputer[@Name='IT-L14-02']/ServerInstance[@Name='INSTANCE1']/ServerProtocol[@Name='Tcp']")
.IsEnabled = True
.Alter()

# Restart SQL Server service
Write-Host "Restarting SQL Server service..." -ForegroundColor Yellow
Restart-Service -Name "MSSQL$INSTANCE1" -Force

Write-Host "SQL Server Express setup complete!" -ForegroundColor Green
