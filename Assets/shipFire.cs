using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipFire : MonoBehaviour {

	public GameObject bullet;
	public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			GameObject bul = Instantiate (bullet, transform.position, transform.rotation) as GameObject;
			Rigidbody2D rb = bul.GetComponent <Rigidbody2D> ();
			rb.velocity = transform.TransformDirection (Vector2.up * speed);
		}
	}
}
