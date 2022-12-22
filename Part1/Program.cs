// See https://aka.ms/new-console-template for more information

using AccountConsoleApp.Services;

Console.WriteLine("Hello, World!");

Account account1 = new Account(1, "MAD", 7000);
Account account2 = new Account(2, "MAD", 7000);
Account account3 = new Account(3, "MAD", 7000);

Console.WriteLine(account1.ToString());

AccountService service = new AccountServiceImpl();
service.AddNewAccount(account1);
service.AddNewAccount(account2);
service.AddNewAccount(account3);

List<Account> all = service.GetAllAccounts();

Console.WriteLine(all[0].ToString());

Console.WriteLine("Get By ID :");
Console.WriteLine(service.GetAccountById(3).ToString());

Console.WriteLine("Calculate averge of balances:");

Console.WriteLine(service.GetBalanceAVG());