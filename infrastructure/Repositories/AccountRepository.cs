using Dapper;
using infrastructure.DataModels;
using infrastructure.QueryModels;
using Npgsql;

namespace infrastructure.Repositories;

public class AccountRepository
{
    private NpgsqlDataSource _dataSource;

    public AccountRepository(NpgsqlDataSource dataSource)
    {
        _dataSource = dataSource;
    }

    public IEnumerable<AccountQuery> GetAllAccounts()
    {
        string sql = $@"SELECT * FROM account";

        using (var conn = _dataSource.OpenConnection())
        {
            return conn.Query<AccountQuery>(sql);
        }
    }

    public bool CreateAccount(string accountName, string accountEmail, string accountPassword, AccountRank accountRank)
    {
        string sql = $@"UPDATE account SET name=@name, email=@email, password=@password, rank=@rank WHERE id=@id";

        using (var conn = _dataSource.OpenConnection())
        {
            conn.Execute(sql, new {
                Name = accountName,
                Email = accountEmail,
                Password = accountPassword,
                Rank = accountRank});
            return true;
        }
    }
    public bool UpdateAccount(AccountQuery account)
    {
        string sql = $@"UPDATE account SET name=@name, email=@email, password=@password, rank=@rank WHERE id=@id";

        using (var conn = _dataSource.OpenConnection())
        {
            conn.Execute(sql, new { //Protects against sql injection if used properly TODO: Ask to be sure
                Name = account.AccountName,
                Email = account.AccountEmail,
                Password = account.AccountPassword,
                Rank = account.AccountRank,
                Id = account.AccountId });
            return true;
        }
    }
    public bool DeleteAccount(int accountId)
    {
        string sql = $@"DELETE FROM account WHERE id=@id";

        using (var conn = _dataSource.OpenConnection())
        {
            conn.Execute(sql, new { id = accountId });
            return true;
        }
    }
}