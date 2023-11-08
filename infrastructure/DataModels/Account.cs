﻿namespace infrastructure.DataModels;

public class Account
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public AccountRank Rank { get; set; }
    public int[] Fields { get; set; }
}