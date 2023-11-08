using infrastructure.DataModels;

namespace Bees.TransferModel;

public class AccountDto
{
    public class Account
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public AccountRank Rank { get; set; }
        public int[] Fields { get; set; }
    }
}