using UnityEngine;
using System.Collections;

public class woolen : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
	}

	void OnTriggerEnter2D( Collider2D playey)
	{
		Destroy(this.gameObject);
	}
}
