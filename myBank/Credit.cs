class Credit
{
	public Guid Id { get; set; } = Guid.NewGuid();
	public double Amount { get; set; }
	public double Percent { get; set; }
	public int Months { get; set; }
	public double Payment { get; set; }

	public Credit() { }

	public Credit(double amount, double percent, int months, double payment)
	{
		Amount = amount;
		Percent = percent;
		Months = months;
		Payment = CalculatePercent(amount, percent);
	}

	public static double CalculatePercent(double amount, double percent)
		=> Convert.ToDouble(amount + (amount * percent / 100.0));

	public override string ToString()
		=> $"ID : {Id}\n\tAmount : {Amount} + {Percent}% => {Payment}";
}