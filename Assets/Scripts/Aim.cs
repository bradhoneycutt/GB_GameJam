using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    public float MaxSpeed = 5;
    Rigidbody2D cursor; 
    // Start is called before the first frame update
    void Start()
    {
        cursor = gameObject.GetComponent<Rigidbody2D>();
    }

    
    void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical"); 
        var movement = new Vector2(moveX, moveY);

            // Debug.Log(move * MaxSpeed * Time.deltaTime);

            cursor.AddForce(movement * MaxSpeed * Time.deltaTime);
        

    }
}
