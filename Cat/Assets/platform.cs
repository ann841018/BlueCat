using UnityEngine;
using System.Collections;

public class platform : MonoBehaviour 
{

	public bool isMoving;
	//public Transform target;
	public Transform [] target;
	public Vector3 velocity;
	private int index;

	// Use this for initialization
	void Start () 
	{
		isMoving = false;
		index = 1;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (isMoving == true) 
		{
			//this.transform.position = Vector3.SmoothDamp(this.transform.position,target.position,ref velocity,2.0f);
			this.transform.position = Vector3.SmoothDamp(this.transform.position,target[index].position,ref velocity,2.0f);
			//Debug.Log (velocity);
			if (Mathf.Abs (velocity.x) < 0.01f) //if(velocity.magnitude < 0.01f)
			{
				index = (index + 1) % 2;
			}
		}
	}

	void OnCollisionEnter2D( Collision2D other )
	{
		isMoving = true;
	}

	void OnCollisionStay2D( Collision2D other )
	{
		
	}
}
