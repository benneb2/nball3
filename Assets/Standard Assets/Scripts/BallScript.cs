using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {

	Transform origTransform;
	// Use this for initialization
	void Start () {
		origTransform = transform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ResetAll()
	{
//		transform = origTransform;
	}

	private float rotationZ = 0f;
	private float sensitivityZ = 2f;
	
	void lockedRotation()
	{
		rotationZ += Input.GetAxis("Mouse X") * sensitivityZ;
		rotationZ = Mathf.Clamp (rotationZ, -90, 90);
		
		transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, -rotationZ);
	}
}
