// See https://aka.ms/new-console-template for more information
using Bank.Domain.DomainModel;
using Bank.Domain.TransactionScripts;

Console.WriteLine("Hello, World!");

// Bank 
// 3-Tier architecture
// 1. Presentation Layer
// 2. Business Logic Layer
// 3. Data Access Layer

// Features
// 1. Create Account
// 2. Deposit
// 3. Withdraw
// 4. Transfer
// 5. View Transactions

var script = new CreateAccount("John Doe", 1000);
script.Execute();
var test = script.Output;

// new transaction script


// domain model
var model = AccountAR.NewAccount("John Doe", 1000);
model.Deposit(100);
model.Withdraw(50);


