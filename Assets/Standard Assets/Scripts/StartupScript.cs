using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;


public class StartupScript : MonoBehaviour {
	private TextMesh side1;
	private TextMesh side2;
	private TextMesh side3;
	private TextMesh side4;
	private TextMesh side5;
	private TextMesh side6;
	private TextMesh side7;
	private TextMesh side8;

	private Transform[] sides;
	private string[] sideV;

	private TextMesh Speech;
	private MeshRenderer SpeechMesh;
	private MeshFilter  SpeechBubble;
	private MeshRenderer  SpeechMeshBubble;

	private int appstate = 0;
	private Camera camera;
	private MeshFilter  NaasHomself;

	public static float timewait = 5f;
	public float countdown = timewait;
	public bool lerping = false;
	// Use this for initialization

	Vector3 startMarker;
	Vector3 endMarker;
	Vector3 NaasstartMarker;
	Vector3 NaasendMarker;
	private float speed = 10.0f;
	private float startTime;
	private float journeyLength;	
	
	//private string url = "http://10.0.0.12/games.php";
	//private string url = "http://10.15.1.235/games.php";
	private string url = "http://192.168.1.102/games.php";
	private List<GameClass> GameList;
	agthoekscript cubescript;
	IEnumerator WaitForRequest(WWW www)
	{
		yield return www;
			
			// check for errors
		if (www.error == null)
		{
			Debug.Log("WWW Ok! - result: " + www.data);
			GameList = new List<GameClass>();
			string[] games = www.data.Split('\n');
			foreach(string game in games)
			{
				string[] game_data = game.Split(';');
				if(game_data.Length == 3)
				{
					//Debug.Log("Game between:Home " + game_data[0] + " and " + game_data[1] + " margin is " + game_data[2]);
					GameClass tempgame = new GameClass(game_data[0],game_data[1], int.Parse(game_data[2]));
					GameList.Add(tempgame);
				}
			}
			MainPlane mainplane = (MainPlane) GameObject.Find ("PlaneMain").GetComponent<MainPlane>();
			mainplane.addGames(GameList);

		} else {
			Debug.Log("WWW Error: "+ www.error);
		}    
	}

	void Start () {

		WWW w = new WWW(url);
		StartCoroutine(WaitForRequest(w));

		NaasHomself = (MeshFilter)GameObject.Find ("Naas").GetComponent<MeshFilter >();

		Speech = (TextMesh)GameObject.Find ("DebugTxt").GetComponent<TextMesh> ();
		SpeechMesh = (MeshRenderer)GameObject.Find ("DebugTxt").GetComponent<MeshRenderer> ();

		SpeechBubble = (MeshFilter)GameObject.Find ("speech").GetComponent<MeshFilter> ();
		SpeechMeshBubble = (MeshRenderer)GameObject.Find ("speech").GetComponent<MeshRenderer> ();

		SpeechMesh.enabled = false;
		SpeechMeshBubble.enabled = false;
		Speech.text = "";

		camera = (Camera)GameObject.Find ("Main Camera").GetComponent<Camera> ();
		cubescript = (agthoekscript) GameObject.Find ("8hoek").GetComponent<agthoekscript>();

		startMarker = new Vector3 (0.0f,25.0f,-20.843f);
		endMarker = new Vector3 (-0.5f,9f,-20.843f);

		NaasstartMarker = new Vector3 (-2.433045f,0.5729523f,7.510696f);
		NaasendMarker = new Vector3 (-2.433045f,0.5729523f,-3.650318f);

		sides = new Transform[8];
		sideV = new string[8];

		side1 = (TextMesh)GameObject.Find ("side1").GetComponent<TextMesh> ();
		side2 = (TextMesh)GameObject.Find ("side2").GetComponent<TextMesh> ();
		side3 = (TextMesh)GameObject.Find ("side3").GetComponent<TextMesh> ();
		side4 = (TextMesh)GameObject.Find ("side4").GetComponent<TextMesh> ();
		side5 = (TextMesh)GameObject.Find ("side5").GetComponent<TextMesh> ();
		side6 = (TextMesh)GameObject.Find ("side6").GetComponent<TextMesh> ();
		side7 = (TextMesh)GameObject.Find ("side7").GetComponent<TextMesh> ();
		side8 = (TextMesh)GameObject.Find ("side8").GetComponent<TextMesh> ();


		sides [0] = GameObject.Find ("side1").transform;
		sides [1] = GameObject.Find ("side2").transform;
		sides [2] = GameObject.Find ("side3").transform;
		sides [3] = GameObject.Find ("side4").transform;
		sides [4] = GameObject.Find ("side5").transform;
		sides [5] = GameObject.Find ("side6").transform;
		sides [6] = GameObject.Find ("side7").transform;
		sides [7] = GameObject.Find ("side8").transform;


		side1.alignment = TextAlignment.Center;
		side2.alignment = TextAlignment.Center;
		side3.alignment = TextAlignment.Center;
		side4.alignment = TextAlignment.Center;
		side5.alignment = TextAlignment.Center;
		side6.alignment = TextAlignment.Center;
		side7.alignment = TextAlignment.Center;
		side8.alignment = TextAlignment.Center;


	}

	public void setstate(int i)
	{
		appstate = i;
	}

	public int getstate()
	{
		return appstate;
	}

	public void ResetCamera()
	{
		Vector3 pos = new Vector3 (50f, 25f, -20.843f);
		camera.transform.position = pos;
	}

	public void setText(GameClass game)
	{
		Debug.Log ("SETTEXT " + game.getHome() + " " + game.getAway() );
		int val = Random.Range (game.getMargin() - 10, game.getMargin() + 10);
		side1.text = game.getHome() + "\n" +  val;
		val = Random.Range (game.getMargin() - 10, game.getMargin() + 10);
		side2.text = game.getHome() + "\n" +  val;
		val = Random.Range (game.getMargin() - 10, game.getMargin() + 10);
		side3.text = game.getHome() + "\n" + val;
		val = Random.Range (game.getMargin() - 10, game.getMargin() + 10);
		side4.text = game.getHome() + "\n" + val;
		val = Random.Range (game.getMargin() - 10, game.getMargin() + 10);
		side5.text = game.getHome() + "\n" + val;
		val = Random.Range (game.getMargin() - 10, game.getMargin() + 10);
		side6.text = game.getHome() + "\n" + val;
		val = Random.Range (game.getMargin() - 10, game.getMargin() + 10);
		side7.text = game.getHome() + "\n" + val;
		val = Random.Range (game.getMargin() - 10, game.getMargin() + 10);
		side8.text = game.getHome() + "\n" +  val;


//		int k = 1;
//		side1.text = "side " + k++;
//		side2.text = "side " + k++;
//		side3.text = "side " + k++;
//		side4.text = "side " + k++;
//		side5.text = "side " + k++;
//		side6.text = "side " + k++;
//		side7.text = "side " + k++;
//		side8.text = "side " + k++;

		sideV [0] = side1.text;
		sideV [1] = side2.text;
		sideV [2] = side3.text;
		sideV [3] = side4.text;
		sideV [4] = side5.text;
		sideV [5] = side6.text;
		sideV [6] = side7.text;
		sideV [7] = side8.text;


	}

	bool foundside;
	public void ResetBall()
	{
		foundside = false;
		cubescript.resetside ();
		countdown = timewait;
		lerping = false;

		NaasHomself.transform.position = NaasstartMarker;
		SpeechMesh.enabled = false;
		SpeechMeshBubble.enabled = false;
		Speech.text = "";

		appstate = 1;
		float yrand = Random.Range (0f, 360f);
		Vector3 ballpos = new Vector3 (-0.5f, 12.87798f, -23.87474f);
		//Vector3 ballrot = new Vector3 (66.04859f, yrand, 290.4945f);
		Vector3 ballrot = new Vector3 (62.95085f, 0.0f, 270f);
		if (yrand > 180) 
		{
			//ballrot = new Vector3 (66.04859f, 110.8218f, 290.4945f); //Kort ander shit soos pos en so om cube te hou.
		}

		Vector3 cubepos = new Vector3 (-0.5953757f,14.81717f, -25.18492f);
		Vector3 cuberot = new Vector3 (334.7018f, 187.5875f, 10.37373f);
		
		GameObject.Find ("ballv5").rigidbody.useGravity = true;
		GameObject.Find ("ballv5").transform.position = ballpos;
		GameObject.Find ("ballv5").transform.localEulerAngles = ballrot;
		GameObject.Find ("ballv5").rigidbody.velocity = Vector3.zero;
		GameObject.Find ("ballv5").rigidbody.angularVelocity = Vector3.zero;
//		GameObject.Find ("ballv5").transform.rotation = Quaternion.AngleAxis(angle, new Vector3(0 ,90f, 0));
		//Vector3 pivot = new Vector3 (0, 0, 0);
		//GameObject.Find ("ballv5").transform.RotateAround(pivot, Vector3.up, yrand);
		GameObject.Find ("8hoek").transform.position = cubepos;
		GameObject.Find ("8hoek").transform.localEulerAngles = cuberot;
		GameObject.Find ("8hoek").rigidbody.velocity = Vector3.zero;
		GameObject.Find ("8hoek").rigidbody.angularVelocity = Vector3.zero;
		
		Vector3 pos = new Vector3 (0f, 25f, -20.843f);
		camera.transform.position = pos;
	}

	int speechcount = 0;
	float speechstart = 0;
	// Update is called once per frame
	void Update () 
	{
	
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			if(appstate > 0)
			{
				ResetCamera();
				appstate = 0;
			}else if(appstate == 0)
			{
				Debug.Log("Application.Quit()");
				Application.Quit();
			}
		}

		if (appstate == 1) 
		{
			countdown -= Time.deltaTime;
			if(lerping == false)
			{
				if (countdown <= 0.0f) 
				{
					countdown = timewait;
					lerping = true;
					startTime = Time.time;					
					journeyLength = Vector3.Distance(startMarker, endMarker);				
				}
			}else
			{
				float distCovered = (Time.time - startTime) * speed;				
				float fracJourney = distCovered / journeyLength;
				camera.transform.position = Vector3.Lerp(startMarker, endMarker, fracJourney);

				if(foundside == false)
				{
					int side = cubescript.getside();
					if(side != 0)
					{
						foundside = true;
						appstate = 2;
						countdown = 1f;
						lerping = false;
						Debug.Log("cube side = " + side);
					}
				}
			}


		}else if (appstate == 2) 
		{
			countdown -= Time.deltaTime;
			if(lerping == false)
			{
				if (countdown <= 0.0f) 
				{
					countdown = 1f;
					lerping = true;
					startTime = Time.time;					
					journeyLength = Vector3.Distance(endMarker,startMarker);				
				}
			}else
			{
				float distCovered = (Time.time - startTime) * speed;				
				float fracJourney = distCovered / journeyLength;
				camera.transform.position = Vector3.Lerp(endMarker,startMarker,fracJourney);
			}

			if(camera.transform.position == startMarker)
			{
				appstate = 3;
				countdown = 0f;
				lerping = false;
			}
		}else if (appstate == 3) 
		{
			countdown -= Time.deltaTime;
			if(lerping == false)
			{
				if (countdown <= 0.0f) 
				{
					countdown = 1f;
					lerping = true;
					startTime = Time.time;					
					journeyLength = Vector3.Distance(NaasendMarker,NaasstartMarker);				
				}
			}else
			{
				float distCovered = (Time.time - startTime) * speed;				
				float fracJourney = distCovered / journeyLength;
				NaasHomself.transform.position = Vector3.Lerp(NaasstartMarker,NaasendMarker,fracJourney);
			}

			if(NaasHomself.transform.position == NaasendMarker)
			{
				appstate = 4;
				speechstart = Time.time;
				speechcount = 0;
			}

		}else if (appstate == 4) 
		{
			SpeechMesh.enabled = true;
			SpeechMeshBubble.enabled = true;

			if(Time.time - speechstart > 0.15 )
			{
				speechstart = Time.time;
				if(speechcount < sideV[cubescript.getside()-1].Length)
				{
					Speech.text = Speech.text + sideV[cubescript.getside()-1][speechcount++];
					Debug.Log(Speech.text);
				}
			}
		}
	}
}
