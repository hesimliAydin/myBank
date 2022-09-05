class Notfication
{
	public string? NotMessage { get; set; }
	public DateTime Time { get; set; }

	public Notfication() { }

	public Notfication(string? notMessage, DateTime time)
	{
		NotMessage = notMessage;
		Time = time;
	}

	public override string ToString() => $"{NotMessage}->{Time.ToString()}";


}