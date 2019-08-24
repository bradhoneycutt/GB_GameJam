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
    public GameObject gm;
    public float StabilityRating = 0.0f;
    public GameObject DropZone;  

    private Vector3 cursorPos; 
    private bool hasShot = false;
    private float Speed;
    private float AngularV;
    private Rigidbody2D Disc;
    private Vector3 startScale;
    private GameMan _gameMan;
    private Vector3 OldPosition;
    private bool IsWet = false; 

    private void Awake()
    {

    }

    private void Start()
    {
        Disc = gameObject.GetComponent<Rigidbody2D>();
        startScale = transform.localScale;
        Crosshair = player.transform.GetChild(2);
        _gameMan = gm.GetComponent<GameMan>();

        //OldPosition = transform.position;
        //player.transform.position = Disc.position + new Vector2(2.0f, 2.0f);
    }


    private void Update()
    {
        ///todo
        ///Spawing player is buggy and player can get stuck at previous location or very near it
        IsMoving();


    }

    private void FixedUpdate()
    {
        if (Input.GetButtonDown("Fire1") && !hasShot)
        {
            cursorPos = Crosshair.position;

            
            var direction = ((Vector2)cursorPos - Disc.position);
            direction = direction.normalized;

           // transform.localScale = transform.localScale * 2; 
            _gameMan.HoleStrokes++;
            
            Disc.AddForce(direction*(MaxSpeed * DiscSpeed));

            
            
            hasShot = true;
            player.SetActive(false);
            player.transform.position = Disc.position;

        }
       
        if (hasShot)
        {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
            transform.localScale = Vector3.Lerp(startScale, transform.localScale * 2f, Time.deltaTime* Time.deltaTime);

        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Disc.velocity = Vector3.zero;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.name == "Basket")
        {
            gameObject.SetActive(false);
            player.SetActive(false);

            _gameMan.ScoreHole(); 

        }


    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Water")
        {
            Debug.Log("In Water");
            IsWet = true;

        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Water")
        {
            Debug.Log("Exit Water");
            IsWet = false;
        }
    }

    private void IsMoving()
    {
        if (!(Disc.velocity.magnitude > 0.01f) && hasShot)
        {
            transform.localScale = startScale;
            Disc.velocity = new Vector3(0, 0, 0);
            hasShot = false;

            if (IsWet)
            {
                gameObject.SetActive(false);
                player.SetActive(false);
                Debug.Log("Water");

                _gameMan.HoleStrokes += 1;
                _gameMan.Ob();
              


                transform.position = DropZone.transform.position;
                player.transform.position = DropZone.transform.position;
                gameObject.SetActive(true);
                

            }


            player.transform.position = Disc.position;
            player.SetActive(true);


        }



    }




}
