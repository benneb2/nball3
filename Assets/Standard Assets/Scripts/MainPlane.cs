using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainPlane : MonoBehaviour {

	private Camera camera;
	private Vector3 screenPoint;
	private Vector3 offset;

	List<GameClass> Games;

	private GameObject newgame;
	// Use this for initialization
	void Start () {

		newgame = GameObject.Find ("NewGame");
		camera = (Camera)GameObject.Find ("Main Camera").GetComponent<Camera> ();
		//rigidbody.inertiaTensor = new Vector3(1, 1, 1);
	}
	
	// Update is called once per frame
	void Update () {
	

		if (transform.position.z <= -23) 
		{
			momentum = false;
			Vector3 pos = new Vector3(transform.position.x,transform.position.y,transform.position.z);
			pos.z = -23.0f;
			transform.position = pos;
			momentum = false;

		} else 
		{
			if(Games.Count > 4)
			{
				if(transform.position.z  >= (-23 + (Games.Count - 4)*10))
				{
					Vector3 pos = new Vector3(transform.position.x,transform.position.y,transform.position.z);
					pos.z = (-23 + (Games.Count - 4)*10);
					transform.position = pos;
					momentum=false;
				}
			}
		}

		if (momentum) 
		{
			//Debug.Log("MOMENTUM " + momentum_val);
			Vector3 pos = new Vector3(transform.position.x,transform.position.y,transform.position.z);
			pos.z = transform.position.z + (momentum_val * (Time.time - momentum_time ));
			transform.position = pos;
			momentum_time = Time.time;
		}
	}

	float momentum_time ;
	bool momentum;
	Vector3 curScreenPoint;
	float momentum_val;
	Vector3 curScreenPoint_now;

	public void addGames(List<GameClass> Games)
	{
		this.Games = Games;
		int i = 0;
		foreach (GameClass game in Games.ToArray()) 
		{

			Debug.Log(game.getHome() + " " + game.getAway() + " " + game.getMargin());
			//GameObject newmesh = (GameObject)Instantiate(newgame, Vector3(i++ * 2.0, 0, 0), Quaternion.identity);
			Vector3 pos = newgame.transform.position;
			pos.z = pos.z - (++i * 8);
			Quaternion rot = newgame.transform.rotation;
			GameObject instance = Instantiate(newgame,pos , rot) as GameObject;
			instance.transform.parent = transform;
			instance.transform.localScale = newgame.transform.localScale;
			TextMesh mesjie = (TextMesh)instance.GetComponent<TextMesh> ();
			mesjie.text = game.getHome() + " vs\n" + game.getAway();

			NewGame newscript = (NewGame) instance.GetComponent<NewGame>();
			newscript.setGame(new GameClass(game.getHome(),game.getAway(),game.getMargin()));
		}

	}

	void OnMouseDown()
	{
		momentum = false;
		Debug.Log ("OnMouseDown");
		screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);		
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
	}


	void OnMouseDrag()
	{
		//Debug.Log ("OnMouseDrag ");

		momentum_time = Time.time;

		curScreenPoint_now = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		curScreenPoint_now = curScreenPoint_now - curScreenPoint;

		Debug.Log ("OnMouseDragY " + curScreenPoint_now.y + " " + momentum_time);

		curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		//Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) &#43, offset;
		//transform.position = curPosition;

		Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
		curPosition.x = transform.position.x;
		curPosition.y = transform.position.y;
		if (curPosition.z > -23) 
		{
			if(Games.Count > 4)
			{
				if(curPosition.z < (-23 + (Games.Count - 4)*10))
				{
					transform.position = curPosition;
				}else
				{
					curPosition.z = (-23 + (Games.Count - 4)*10);
					transform.position = curPosition;
				}
			}
		} else 
		{
			curPosition.z = -23.0f;
			transform.position = curPosition;
		}
	}

	void OnMouseUp()
	{
		Debug.Log ("OnMouseUp");


		momentum = true;
		momentum_val = curScreenPoint_now.y /(Time.time - momentum_time);
		momentum_time = Time.time;

		//Rigidbody rigidb = GameObject.Find ("Cube").GetComponent<Rigidbody>();

   		//rigidb.isKinematic = false;
//		collider.enabled = true;
//		
		//rigidb.AddForce (new Vector3 (0, 0, 10 * Input.GetAxis("Mouse X")), ForceMode.Impulse);
		//rigidb.AddForce(transform.right * Input.GetAxis("Mouse X") * 10f, ForceMode.Impulse);
		//rigidb.AddForce(transform.up * Input.GetAxis("Mouse Y") * 10f, ForceMode.Impulse);
	}
} 
