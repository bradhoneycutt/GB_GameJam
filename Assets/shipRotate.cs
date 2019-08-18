using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipRotate : MonoBehaviour {

	public float speed = 1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float r = Input.GetAxis ("Horizontal");
		var temp = transform.rotation;
		temp.z -= r * speed * Time.deltaTime;
		transform.rotation = temp;
	}
}
