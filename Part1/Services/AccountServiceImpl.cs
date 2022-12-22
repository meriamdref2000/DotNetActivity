namespace AccountConsoleApp.Services;

public class AccountServiceImpl : AccountService
{
    Dictionary<int, Account> accounts= new Dictionary<int, Account>();
    
    public Account AddNewAccount(Account account)
    {
        accounts.Add(account.id, account);
        return account;
    }

    public List<Account> GetAllAccounts()
    {
        return accounts.Values.ToList();
    }

    public Account GetAccountById(int id)
    {
        return accounts[id];
    }

    public List<Account> GetDebitedAccounts()
    {
        return accounts.Values.Where(account => account.balance > 0).ToList();
        
    }

    public double GetBalanceAVG()
    {
        return accounts.Values.Average(a => a.balance);
    }
}