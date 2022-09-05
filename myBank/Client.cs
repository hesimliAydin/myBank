
class Client
{
	public string Name { get; set; } = default!;
	public string Surname { get; set; } = default!;
	public BankCard? Card { get; set; }
	public Notfication[]? Not { get; set; }
	public Credit? Credit { get; set; }

	public Client() { }

	public Client(string name, string surname, BankCard? card, Notfication[]? not, Credit? credit)
	{
		Name = name;
		Surname = surname;
		Card = card;
		Not = not;
		Credit = credit;
	}

	public override string ToString() => $"\nUSER\n {Name} {Surname}-> {Card.PAN} {Card.PIN}";

	public void Message(string message)
	{
		Notfication notfication = new Notfication(message, DateTime.Now);

		if (Not == null)
			Not = new Notfication[] { notfication };
		else
			Not = Not.Append<Notfication>(notfication).ToArray();
	}
}

