using Lab3.Infra.Models;

namespace Lab3.Infra.Data;
public class AccountRepository : GenericRepository<Account>
{
    public AccountRepository(Lab3Prn231Context context) : base(context)
    {
    }

    public async Task<Account?> GetAccountByUsernameAndPassword(string username, string password)
    {
        return (await GetAsync(a => a.Username == username && a.Password == password)).FirstOrDefault();
    }
}

