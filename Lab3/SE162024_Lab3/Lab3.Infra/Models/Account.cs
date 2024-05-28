namespace Lab3.Infra.Models;

public partial class Account
{
    public int Accountid { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public Role Role { get; set; }
}
