using UnityEngine;
using System.Collections;

public class CamFollow : MonoBehaviour {

	public Transform MyTarget;
	public Vector2 myFocus;
	private Camera myCam;
	public float mySmoothTime;
	public Vector3 volocity;

	// Use this for initialization
	void Start () {
		myCam = GetComponent<Camera> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 pos = myCam.WorldToViewportPoint (MyTarget.position);//
		Vector3 distance = MyTarget.position-myCam.ViewportToWorldPoint(new Vector3 (myFocus.x, myFocus.y, pos.z));
		Debug.Log (distance);
		Vector3 moveto = transform.position = transform.position + distance;
		transform.position = Vector3.SmoothDamp (transform.position, moveto, ref volocity, mySmoothTime);
 
		/*if (MyTarget.transform.position.x > 4.5) //簡單的寫法
		{
			this.transform.position = new Vector3 (MyTarget.transform.position.x, this.transform.position.y, this.transform.position.z);
		} else 
		{
		}*/
	}
}
