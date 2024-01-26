The database migration would need to be created. The project uses SQL Server DB. 
Please run the following commands on either powershell or Package Manager console within Visual Studio.

Add-Migration "InitialCreate"
Update-Database
