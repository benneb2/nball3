
public class GameClass  {
	private string home;
	private string away;
	private int margin;

	public GameClass(string Home,string Away,int Margin)
	{
		home = Home;
		away = Away;
		margin = Margin;
	}

	public string getHome()
	{
		return home;
	}

	public string getAway()
	{
		return away;
	}

	public int getMargin()
	{
		return margin;
	}

}
