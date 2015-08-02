using UnityEngine;
using System.Collections;

public class NewGame : MonoBehaviour {
	private Camera camera;
	private StartupScript startscript;
	private GameObject ball;
	private GameClass Game;
	// Use this for initialization
	void Start () {
		camera = (Camera)GameObject.Find ("Main Camera").GetComponent<Camera> ();
		startscript = (StartupScript) GameObject.Find ("Main Camera").GetComponent<StartupScript>();
	}

	public void setGame(GameClass game)
	{
		Debug.Log ("setGameHERE " + game.getHome() + " " + game.getAway() );
		Game = new GameClass (game.getHome (), game.getAway (), game.getMargin ());
	}

	void OnMouseDown()
	{
		MouseClick ();
	}

	void OnMouseOver()
	{
		//MouseClick ();
	}
	// Update is called once per frame
	void Update () 
	{			
		//if (Input.GetMouseButtonDown (0))
		//	MouseClick ();
	}

	void OnMouseEnter()
	{
		
	}

	void MouseClick()
	{
		Debug.Log("MouseClick.");
		//startscript.setstate(1);
		Debug.Log ("MouseClick " + Game.getHome() + " " + Game.getAway() );
		startscript.setText(Game);
		startscript.ResetBall();
	}


}
