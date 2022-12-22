using System.Text.Json;

namespace AccountConsoleApp.Services;

public class Account
{
    public int id { get; set; }
    public string curency { get; set; }
    public double balance { get; set; }

    public Account(int id, string curency, double balance)
    {
        this.id = id;
        this.curency = curency;
        this.balance = balance;
    }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}