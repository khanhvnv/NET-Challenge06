# Starter app for Create a web UI with ASP.NET Core

Welcome! This is the homework for the Challenge 05:
- Create class library project
- Create CategoryDto in class library
- add reference class library project to API and .Net MVC
- Use the CategoryDto from class library instead of creating separately in both API and .Net MVC

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
	
Step 6: Run Both Projects and Verify the Results
	
	1. Run the Minimal API (CategoryApi) project on its assigned port.
		○ Open the terminal in CategoryApi project folder and run:	dotnet run
		○ Open a browser and navigate to http://localhost:5000/categories (or the appropriate port for your API project).
		
	2. Run the MVC Project (CategoryProject) and navigate to the Category page.
		○ Open the terminal in CategoryProject project folder and run:	dotnet run
		○ Open a browser and navigate to http://localhost:5001/Category (or the appropriate port for your MVC project).

Verification
- The Category page should now retrieve and display category data from the API using CategoryDto from the shared library.
- With these steps, both projects will utilize CategoryDto from the shared library, ensuring consistency across the solution.

Notice:
Clear SSL Cache and Restart
Sometimes, SSL issues can be due to cached certificates. You can try restarting your machine to clear any cached SSL settings and ensure a fresh connection.