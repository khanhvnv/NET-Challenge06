# Starter app for Create a web UI with ASP.NET Core

Welcome! This is the homework for the Challenge 06:
- Start building Home Page: Category Menu, Featured Product (Hard-coded data)

## Completed version


## Contributing

This project welcomes contributions and suggestions.  

## Step-by-step guide to run the web app

Prerequisites
Ensure you have:
- Visual Studio Code installed
- NET SDK 8 (compatible with .NET MVC)

Step 1: Set Up Your Development Environment
1. Install .NET SDK: Ensure you have the latest .NET SDK installed. You can download it from the .NET download page.
2. Install an IDE: Use Visual Studio, Visual Studio Code, or any other preferred IDE.

Step 2: Set Up the Project for Entity Framework Core
1. Install Required NuGet Packages
You need to install the following NuGet packages for Entity Framework Core:
-	Microsoft.EntityFrameworkCore.SqlServer (for SQL Server database provider)
-	Microsoft.EntityFrameworkCore.Tools (for EF Core tools)
-	Microsoft.EntityFrameworkCore.Design (for design-time support)
Open your terminal and run the following commands in your project folder:
-	dotnet add package Microsoft.EntityFrameworkCore --version 8.0.2
-	dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 8.0.2
-	dotnet add package Microsoft.EntityFrameworkCore.Tools --version 8.0.2
These packages will allow us to interact with SQL Server and run migrations for creating the database schema.

Run the following command to install the Swagger package to use Swagger:
	dotnet add package Swashbuckle.AspNetCore
	This will add the Swashbuckle.AspNetCore package to your project, which includes the AddSwaggerGen method.

Step 3: Configure the Database Connection
- You need to update your connection string for your SQL Server instance (replace the Server name and Database name) in the appsettings.json file.
- Make sure that your SQL Server instance is running and you have a database named 'master' (or you can change the name in the connection string).

Step 4: Create and Apply Migrations
Entity Framework uses migrations to generate and update the database schema based on the models.
1. Add Initial Migration
Run the following commands in your terminal to create the first migration, which will generate the necessary SQL to create the Categories table in the database.
	dotnet ef migrations add InitialCreate
This command will generate migration files in the Migrations folder. It will also include the SQL code needed to create the Categories table.
- If you has an exisiting Categories table, please delete or change its name.
2. Apply the Migration to the Database
Next, apply the migration to create the Categories table in the SQL Server database.	
	dotnet ef database update
This will create the CategoryDb database (if it doesn’t already exist) and the Categories table.

Step 5: Trust the Development Certificate
In a terminal, run the following command to trust the .NET development certificate:
	dotnet dev-certs https --trust
Restart both projects after running this command.
	
Step 6: Verify the Home Page
	
	1. Run the Application: Launch CategoryProject.
		○ Open the terminal in CategoryProject project folder and run:	dotnet run
	2. Access the Home Page: Go to http://localhost:PORT (input the appropriate port for your CategoryProject project), and you should see:
		○ A Category Menu with static links.
		○ A Featured Product section (New Arrivals) displaying hard-coded products.
		
Notice:
Clear SSL Cache and Restart
Sometimes, SSL issues can be due to cached certificates. You can try restarting your machine to clear any cached SSL settings and ensure a fresh connection.