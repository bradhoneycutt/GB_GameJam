using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    private CameraFollow camFollow;
    private Camera Camera;
    private float InitalCameraSize = 5f;

    private GameObject _disc;
    public float spriteBlinkingTimer = 0.0f;
    public float spriteBlinkingMiniDuration = 0.1f;
    public float spriteBlinkingTotalTimer = 0.0f;
    public float spriteBlinkingTotalDuration = 1.0f;
    public bool startBlinking = false;


    // Start is called before the first frame update
    void Start()
    {
        camFollow = gameObject.GetComponent<CameraFollow>();
        Camera = gameObject.GetComponent<Camera>();

        _disc = GameObject.Find("disc");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Jump"))
        {
            camFollow.enabled = false;
            transform.position = new Vector3(4.5f, -8.1f, -10f);
            Camera.orthographicSize = 20f;
            startBlinking = true;

        }
        if (Input.GetButtonUp("Jump"))
        {
            startBlinking = false;
            _disc.GetComponent<SpriteRenderer>().enabled = true;
            camFollow.enabled = true;
            Camera.orthographicSize = InitalCameraSize;
        }

        if (startBlinking)
        {
            SpriteBlinkingEffect();
        }


    }

    private void SpriteBlinkingEffect()
    {
        spriteBlinkingTotalTimer += Time.deltaTime;
        if (spriteBlinkingTotalTimer >= spriteBlinkingTotalDuration)
        {
            startBlinking = false;
            spriteBlinkingTotalTimer = 0.0f;
            _disc.GetComponent<SpriteRenderer>().enabled = true;   // according to 
                                                                             //your sprite
            return;
        }

        spriteBlinkingTimer += Time.deltaTime;
        if (spriteBlinkingTimer >= spriteBlinkingMiniDuration)
        {
            spriteBlinkingTimer = 0.0f;
            if (_disc.GetComponent<SpriteRenderer>().enabled == true)
            {
                _disc.GetComponent<SpriteRenderer>().enabled = false;  //make changes
            }
            else
            {
                _disc.GetComponent<SpriteRenderer>().enabled = true;   //make changes
            }
        }
    }
}
