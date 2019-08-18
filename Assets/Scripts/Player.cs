using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject cursor;
    public float MaxSpeed = 100f;
    public float DiscSpeed = 10f;
    public float rotationSpeed = 500f;


    private bool hasShot = false;
    private float Speed;
    private float AngularV;
    private Rigidbody2D Disc; 

    private void Awake()
    {
        Disc = gameObject.GetComponent<Rigidbody2D>();
    }



    private void Update()
    {
        Vector3 cursorPos = cursor.transform.position;
        var direction = (cursorPos - transform.position);
        if (Input.GetButtonDown("Fire1"))
        {
            {
                hasShot = true;
                Debug.Log("hasShot");
            }
            if (hasShot)
            {
                
                Disc.AddForce(direction * (MaxSpeed * DiscSpeed));

                Speed = Disc.velocity.sqrMagnitude;
                AngularV = Disc.velocity.sqrMagnitude; 
                Debug.Log(Speed);

                //if (rigidbody.velocity.sqrMagnitude < .01  rigidbody.angularVelocity.sqrMagnitude < .01)
                if (Speed < .01 && AngularV < .01)
                {
                    Disc.velocity = new Vector3(0, 0, 0);
                    hasShot = false;
                }
            }
        }

        //Vector3 direction = cursor.transform.position - transform.position;
        //direction.Normalize(); //

        //float zAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;  //returns a radian -90 so Y is 0 axis which in unity is X axis 

        //Quaternion rot = Quaternion.Euler(0, 0, zAngle);

        //transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, rotationSpeed * Time.deltaTime);

        //Vector3 dir = cursor.transform.position - transform.position;
        //dir = transform.InverseTransformDirection(dir);

        //if (Input.GetButtonDown("Fire1"))
        //{
        //    hasShot = true;
        //    Debug.Log("hasShot");
        //}
        //if (hasShot)
        //{
        //    Vector3 posDelta = transform.position;
        //    Vector3 velocity = new Vector3(0, MaxSpeed * Time.deltaTime, 0);
        //    //Quaternon has to come  first
        //    posDelta += transform.rotation * velocity;
        //    Disc.AddForce(transform.up * MaxSpeed);
        //   // transform.position = Vector3.Lerp(transform.position, posDelta, Time.deltaTime * MaxSpeed); //posDelta;
        //    //Disc.MovePosition(new Vector2(dir.x * MaxSpeed, dir.y * MaxSpeed));
        //    Speed = Disc.velocity.magnitude;
        //    Debug.Log(Speed);
        //    if (Speed < 0.5)
        //    {
        //        Disc.velocity = new Vector3(0, 0, 0);
        //        hasShot = false;
        //    }

        //}
    }

    private void PointToCursor()
    {
        
    }

}
