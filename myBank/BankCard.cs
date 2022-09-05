class BankCard
{
	public string PAN { get; set; } = default!;
	public string PIN { get; set; } = default!;
	public double Balance { get; set; }

	public BankCard() { }

	public BankCard(string pAN, string pIN, double balance)
	{
		PAN = pAN;
		PIN = pIN;
		Balance = balance;
	}
}
