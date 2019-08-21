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
    public GameObject basket; 

    private bool hasShot = false;
    private float Speed;
    private float AngularV;
    private Rigidbody2D Disc;
    private Vector3 startScale;
    private GameMan _gameMan;
    private Vector3 OldPosition;

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
        if (Input.GetButtonDown("Fire1") && !hasShot)
        {
            Vector3 cursorPos = Crosshair.position;
            var direction = (cursorPos - transform.position);
            // transform.localScale = transform.localScale * 2; 
            _gameMan.HoleStrokes++;

            Disc.AddForce(direction * MaxSpeed * DiscSpeed);
            hasShot = true;
            player.SetActive(false);
            player.transform.position = Disc.position;

        }

    }
    void OnCollisionEnter2D(Collision2D col)
    {

        //currentDirection = Vector3.zero;
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

    private void IsMoving()
    {
        if (!(Disc.velocity.magnitude > 0.0f) && hasShot)
        {
            // transform.localScale = startScale;
            Disc.velocity = new Vector3(0, 0, 0);
            hasShot = false;
            player.transform.position = Disc.position;
            player.SetActive(true);
        }
    }

}
