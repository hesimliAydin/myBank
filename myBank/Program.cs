using Bogus;

partial class Program
{
	class BankException : ApplicationException
	{
		public BankException(string message = "Balance is not enough!") : base(message) { }
	}

	public static Credit FakerCredit()
	{
		Random random = new Random();

		Credit credit = new Credit()
		{
			Amount = (double)random.Next(500, 10000),
			Percent = (double)random.Next(1, 100),
			Months = (int)(random.Next(1, 13))
		};

		credit.Payment = Credit.CalculatePercent(credit.Amount, credit.Percent);

		return credit;
	}

	public static BankCard FakeCardGenerator()
	{
		BankCard card = new Faker<BankCard>()
			.RuleFor(card => card.PAN, bogus => bogus.Random.String(16, '0', '9'))
			.RuleFor(card => card.PIN, bogus => bogus.Random.String(4, '0', '9'))
			.RuleFor(card => card.Balance, bogus => bogus.Random.Double(0, 10000));

		return card;
	}

	public static Client FakeClientGenerator()
	{
		Client client = new Faker<Client>()
			.RuleFor(client => client.Name, bogus => bogus.Name.FirstName())
			.RuleFor(client => client.Surname, bogus => bogus.Name.LastName());
		client.Card = FakeCardGenerator();

		return client;
	}

	static void Main()
	{
		Admin? admin = new Admin("Aydin", "aydin123");

		Client? client = null;
		Client[] clients =
		{
			FakeClientGenerator(),
			FakeClientGenerator(),
			FakeClientGenerator(),
			FakeClientGenerator(),
			FakeClientGenerator()
		};

		string? username, password;

		while (true)
		{
			sbyte select = Convert.ToSByte(GetSelected("\t\tWELCOME\n", new string[] { "Admin", "Client", "Exit" }) + 1);
			if (select == 1)
			{
				while (true)
				{
					Console.Write("\nEnter username : ");
					username = Console.ReadLine();
					Console.Write("Enter password : ");
					password = Console.ReadLine();

					if (admin.Username == username && admin.Password == password)
					{
						Console.Clear();
						int choice = Convert.ToInt32(GetSelected("\nSechin\n", new string[] { "Cliente baxmaq", "Kredite baxmaq", "Chixish" }) + 1);
						Console.WriteLine();
						try
						{
							if (choice == 1)
							{
								foreach (var c in clients)
									Console.WriteLine(c);
							}
							else if (choice == 2)
							{
								Bank bank = new Bank();
								bank.ShowAllCredits();
							}
							else if (choice == 3)
								Environment.Exit(0);
						}
						catch (Exception ex)
						{
							Console.WriteLine(ex.Message);
						}
						finally
						{
							Console.WriteLine("\nPress any key to continue...");
						}
					}
					else if (admin.Username == username && admin.Password != password)
						Console.WriteLine("Password is incorrect !");
					else if (admin.Username != username && admin.Password == password)
						Console.WriteLine("Username is incorrect !");
					else
						Console.WriteLine("Username and Password is incorrect, Try Again !");
				}
			}
			else if (select == 2)
			{
				while (true)
				{
					foreach (var c in clients)
						Console.WriteLine(c);

					string start = "Please Select Any Account and Enter PIN Code : ";
					Console.WriteLine();
					Console.Write(start.PadLeft(70));

					string? inPIN = Console.ReadLine();
					if (inPIN?.Length != 4)
						continue;

					for (int i = 0; i < clients.Length; i++)
						if (clients[i].Card.PIN == inPIN)
						{
							client = clients[i];
							break;
						}
					if (client != null)
						break;
				}

				Console.Clear();
				client.Message("You entered system !");

				sbyte ss = Convert.ToSByte(GetSelected("Please, enter your selection\n", new string[] { "Odenish Cedveli", "Kredit Ode", "Mebleg", "Exit" }) + 1);

				if (ss == 1)
				{

				}
				else if (ss == 2)
				{

				}
				else if (ss == 3)
				{

				}
				else if (ss == 3)
					Environment.Exit(0);
			}
			else if (select == 3)
			{
				Environment.Exit(0);
				break;
			}
		}
	}
}
