using System.Runtime.ConstrainedExecution;

class Bank
{
	public Guid Id { get; } = Guid.NewGuid();
	public string? Name { get; set; }
	public double Budget { get; set; }
	public Client[]? Clients { get; set; }
	public Credit[]? Credits { get; set; }

	public double CalculateProfit()
	{
		double profit = 0;

		if (Clients != null)
			foreach (var client in Clients)
				profit += Convert.ToDouble(client?.Credit?.Amount * client?.Credit?.Percent / 100.0);

		return profit;
	}

	public void ShowAllClientCredits(string name, string surname)
	{
		if (Clients != null)
			foreach (var client in Clients)
				if (client.Name == name && client.Surname == surname)
					Console.WriteLine(client?.Credit);
	}

	public void ShowAllCredits()
	{
		if (Clients != null)
			foreach (var client in Clients)
				Console.WriteLine(client?.Credit);
	}

	public void ShowAllClients()
	{
		if (Clients != null)
			foreach (var client in Clients)
				Console.WriteLine(client);
	}

	public Client? GetClient(string name, string surname)
	{
		if (Clients != null)
			foreach (var client in Clients)
				if (client.Name == name && client.Surname == surname)
					return client;

		return null;
	}

	public void PayCredit(Client clientIn, double money)
	{
		if (Clients != null)
			foreach (var client in Clients)
				if (clientIn == client)
					client.Credit.Payment -= money;
	}
}