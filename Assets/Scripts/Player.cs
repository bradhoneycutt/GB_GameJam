using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject player;
    public float MaxSpeed = 100f;
    public float DiscSpeed = 10f;
    public float rotationSpeed = 500f;


    private bool hasShot = false;
    private float Speed;
    private float AngularV;
    private Rigidbody2D Disc;
    private Vector3 startScale;
    private float StartDistance;
    private float LastDistance;

    private Vector3 OldPosition; 

    private void Awake()
    {
        Disc = gameObject.GetComponent<Rigidbody2D>();
        startScale = transform.localScale;
        LastDistance = StartDistance;
    }

    private void Start()
    {
        //OldPosition = transform.position;
        //player.transform.position = Disc.position + new Vector2(2.0f, 2.0f);
    }


    private void Update()
    {
        Vector3 cursorPos = player.transform.position;
        var direction = (cursorPos - transform.position);
        if (Input.GetButtonDown("Fire1"))
        {
            {
                hasShot = true;
                Debug.Log("hasShot");
            }
            if (hasShot)
            {
                //player.SetActive(false);

                Disc.AddForce(direction * (MaxSpeed * DiscSpeed));

               

                Speed = Disc.velocity.sqrMagnitude;
                AngularV = Disc.velocity.sqrMagnitude; 
                Debug.Log(Disc.velocity.magnitude);

                //if (rigidbody.velocity.sqrMagnitude < .01  rigidbody.angularVelocity.sqrMagnitude < .01)
                if (!(Disc.velocity.magnitude > 0.0f))
                {
                    Disc.velocity = new Vector3(0, 0, 0);
                    hasShot = false;


                }



            }
        }

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        //currentDirection = Vector3.zero;
        Disc.velocity = Vector3.zero;
    }
    private bool IsMoving()
    {
        if(OldPosition != transform.position)
        {
            OldPosition = transform.position;
            return true;
        }
        else
        {
            return false;
        }
    }

}
