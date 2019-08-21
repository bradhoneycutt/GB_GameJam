using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject player;
    public float MaxSpeed = 100f;
    public float DiscSpeed = 10f;
    public float rotationSpeed = 500f;
    public Transform Crosshair; 

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

    }

    private void Start()
    {
        Disc = gameObject.GetComponent<Rigidbody2D>();
        startScale = transform.localScale;
        LastDistance = StartDistance;
        Crosshair = player.transform.GetChild(2);


        //OldPosition = transform.position;
        //player.transform.position = Disc.position + new Vector2(2.0f, 2.0f);
    }


    private void Update()
    {
        IsMoving();
        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 cursorPos = Crosshair.position;
            var direction = (cursorPos - transform.position);
            

            Disc.AddForce(direction * MaxSpeed * DiscSpeed);
            player.SetActive(false);


            Speed = Disc.velocity.sqrMagnitude;
            AngularV = Disc.velocity.sqrMagnitude; 
            Debug.Log(Disc.velocity.magnitude);


            hasShot = true;

        }



        


    }
    void OnCollisionEnter2D(Collision2D col)
    {
        //currentDirection = Vector3.zero;
        Disc.velocity = Vector3.zero;
    }
    private void IsMoving()
    {
        if (!(Disc.velocity.magnitude > 0.0f) && hasShot)
        {
            Disc.velocity = new Vector3(0, 0, 0);
            hasShot = false;
            player.transform.position = Disc.position;
            player.SetActive(true);
        }
    }

}
