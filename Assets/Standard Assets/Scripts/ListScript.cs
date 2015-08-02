using UnityEngine;
using System.Collections;

public class ListScript : MonoBehaviour {

	private float hScrollBarValue;
	private string innerText = "Found Me!";

	Vector2 scrollViewVector = Vector2.zero;
	bool test = false;
	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		return;
		Vector3 pos = new Vector3 (0, 0, 0);
		transform.position = pos;
	}

	void OnGUI () 
	{
		return;
		// Begin the ScrollView
		scrollViewVector = GUI.BeginScrollView (new Rect (10, 10, Screen.width - 10, Screen.height - 10), scrollViewVector, new Rect (0, 0, Screen.width - 30, 1000),false,false);

		// Put something inside the ScrollView
		innerText = GUI.TextArea (new Rect (0, 0, 400, 400), innerText);

		// End the ScrollView
		GUI.EndScrollView ();
	}

}
