using Dapper;
using infrastructure.DataModels;
using infrastructure.QueryModels;
using Npgsql;

namespace infrastructure.Repositories;

public class AccountRepository : RepositoryBase
{
    private NpgsqlDataSource _dataSource;

    public AccountRepository(NpgsqlDataSource dataSource) : base(dataSource) { }

    public IEnumerable<AccountQuery> GetAllAccounts()
    {
        return GetAllItems<AccountQuery>("account");
    }

    public int CreateAccount(string accountName, string accountEmail, string accountPassword, AccountRank accountRank)
    {
        var parameters = new
        {
            name = accountName,
            email = accountEmail,
            password = accountPassword,
            rank = accountRank
        };

        return CreateItem<int>("account", parameters);//TODO: check if it works, fix if not
    }

    public bool UpdateAccount(AccountQuery account)
    {
        return UpdateEntity("account", account, "id");
    }

    public bool DeleteAccount(int accountId)
    {
        return DeleteItem("account", accountId);
    }

    //TODO: remove later, don't need it
    public AccountQuery GetAccountByName(string accountName)
    {
        const string sql = $@"SELECT * FROM account WHERE id = @accountId";

        using (var conn = _dataSource.OpenConnection())
        {
            return conn.QueryFirstOrDefault<AccountQuery>(sql, new { accountName }) ??
                   throw new Exception(
                       $"{accountName} not found"); //TODO: Change to GlobalExceptionHandler later, delete later
        }
    }
}