using UnityEngine;
using System.Collections;

public class sideTrigger : MonoBehaviour {
	
	agthoekscript cubescript;
	// Use this for initialization
	void Start () {
		cubescript = (agthoekscript) GameObject.Find ("8hoek").GetComponent<agthoekscript>();
	}
	
	// Update is called once per frame
	void Update () {
	


	}

	public int faceValue = 0;
	
	void OnTriggerEnter(  Collider other ) {

		if(other.gameObject.name == "Glass")
			{
				cubescript.enterside(faceValue);
			//Debug.Log ("Enter "  + faceValue);
			}		
	}

	void OnTriggerExit(  Collider other ) 
	{
				if (other.gameObject.name == "Glass") 
				{
					//Debug.Log ("Exit "  + faceValue);
					cubescript.exitside(faceValue);
				}
	}
}
