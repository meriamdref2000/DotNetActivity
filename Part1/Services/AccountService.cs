namespace AccountConsoleApp.Services;

public interface AccountService
{
    Account AddNewAccount(Account account);
    List<Account> GetAllAccounts();
    Account GetAccountById(int id);
    List<Account> GetDebitedAccounts();
    double GetBalanceAVG();
}