using UnityEngine;
using System.Collections;

public class agthoekscript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log ("HAllo Daar");
		rigidbody.WakeUp();
		rigidbody.useGravity = false;
		startTime = Time.time;

		lastPos = transform.position;
		lastRot = transform.localEulerAngles;
	}

	public float smooth =1;
	public float angle;
	public float startTime;
	private int side = 0;

	Vector3 curPos;
	Vector3 lastPos;
	Vector3 lastRot;
	float sideTime;
	private int finalside = 0;

	public int getside()
	{
		return finalside;
	}

	public void resetside()
	{
		finalside = 0;
		side = 0;

	}

	public void exitside(int side)
	{
		if (this.side == side) 
		{
			this.side = 0;
		}
	}
	public void enterside(int side)
	{
		this.side = side;
	}

	public bool bIsOnTheMove = true;

	void FixedUpdate()
	{
		rigidbody.AddForce(new Vector3(0,0.1f,0));

	}
	public int icount = 0;
	void Update() 
	{
		float x = Mathf.Abs(lastPos.x - transform.position.x) ;
		float y = Mathf.Abs(lastPos.y - transform.position.y) ;
		float z = Mathf.Abs(lastPos.z - transform.position.z) ;
		
		//Debug.Log ((x+y+z) + " " + x + " " +y + " " +z + " "  );
		//if (lastPos == transform.position ) 
		if ((x+y+z) < 0.001 ) 
		{
			if (icount > 20) 
			{					
					
				if(side == 0)
				{
					icount = 0;
					rigidbody.AddForce(new Vector3(0,-10,0));
					rigidbody.AddTorque(new Vector3(10,10,10));
				}else
				{
					finalside = side;
					//Debug.Log ("SIDE:: " + side);
				}
			} else 
			{
						icount++;
			}
		} else {


			icount = 0;
		}

		lastPos = transform.position;
		lastRot = transform.localEulerAngles;


		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			Debug.Log ("OP");


			rigidbody.AddForce(new Vector3(0,10,0));
		}
		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			Debug.Log ("AF");
			
			rigidbody.AddForce(new Vector3(0,-10,0));
		}

		if(Input.GetKeyDown(KeyCode.RightArrow)){
		

			//transform.position = Input.GetAxis("Vertical") * transform.forward;
			//rigidbody.AddTorque(new Vector3(10,10,10));
			Debug.Log ("REGS " + transform.localPosition.x + " " +transform.localPosition.y + " " +transform.localPosition.z);
			Debug.Log ("REGS " + transform.position.x + " " +transform.position.y + " " +transform.position.z);
		}else if(Input.GetKeyDown(KeyCode.LeftArrow)){

			rigidbody.AddTorque(new Vector3(-10,-10,-10));

			Debug.Log ("LINKS");
		}
	}
}
