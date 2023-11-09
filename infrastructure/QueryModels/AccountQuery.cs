using infrastructure.DataModels;

namespace infrastructure.QueryModels;

public class AccountQuery
{
    public int AccountId { get; set; }
    public string AccountName { get; set; }
    public string AccountEmail { get; set; }
    public string AccountPassword { get; set; }
    public AccountRank AccountRank { get; set; }
}