# Personal Finances App
App app allowing user to keep track of his incomes, expenditures and showing summary with the possibility of defining a date range
## Features
- CRUD operations on income/expense categories and transactions
- Showing edit form by clicking gearwheel icon on category card with options update or remove
- Adding new transaction by clicking plus icon on category card
- Showing history of transactions for the chosen category by double clicking category card
- Removing transaction from history by clicking trash icon
- Showing edit form for transaction by double clicking table row in transaction history table
- Displaying a summary of incomes and expenses on the summary page, with the ability to specify a date range


## Configuration
#### 1. Change your connection string in [appsettings.json](https://github.com/dtamon/Task6_PersonalFinance/blob/master/Task6_PersonalFinance.API/appsettings.json),
````json 
"ConnectionStrings": {
    "connection": "Server=localhost\\SQLEXPRESS;Database=Task6;Trusted_Connection=True;TrustServerCertificate=True;"
  },
````    
#### 2. Generate schema by running `update-database` command in Package Manager Console ![PMC](https://i.imgur.com/J02MJcO.png) 
#### 3. Database should be filled automatically with [DataSeeder](https://github.com/dtamon/Task6_PersonalFinance/blob/master/Task6_PersonalFinance.Core/Seeder/DataSeeder.cs), there is one defult user seeded
#### 4. The way I run the project is to open whole solution in Visual Studio and run `Task6_PersonalFinance.API` project there, open `Task6-PersonalFinance.Frontend` project in Visual Studio Code and start it with command `npm start` from terminal and going to https://localhost:3000/ address in the browser
#### 5. Before the first launch it may be required to install react libraries by running `npm install` or `npm i` in terminal



## Architecture

- Solution contains 4 layers Repository, Service, API and Frontend
- I used Entity Framework Core for easy communication with database
- Authorization is done with [JWT Bearer token](https://jwt.io/introduction)
- For validation purpose I used [Fluent Validation](https://docs.fluentvalidation.net/en/latest/) library
- For styling I used [Bootstrap](https://getbootstrap.com/) and [React-Bootstrap](https://react-bootstrap.github.io/)
- Controllers job is to handle requests from the Frontend
- Services do all logic like mapping DTOs using AutoMapper, calling repositories for Entity Models or getting authorized user properties.
- Repositories job is to get needed data from database using LINQ, each repository corresponds to a table from the database

## Database (MS SQL Server)
### Database schema
![Database Schema](https://i.imgur.com/0CmG6Nw.png)
