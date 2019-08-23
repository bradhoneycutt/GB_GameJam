using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    private CameraFollow camFollow;
    private Camera Camera; 
    private float InitalCameraSize = 5f; 

    // Start is called before the first frame update
    void Start()
    {
        camFollow = gameObject.GetComponent<CameraFollow>();
        Camera = gameObject.GetComponent<Camera>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Jump"))
        { 
            camFollow.enabled = false;
            transform.position = new Vector3(4.5f, -8.1f, -10f);
            Camera.orthographicSize = 20f;

        }
        if (Input.GetButtonUp("Jump"))
        {
            camFollow.enabled = true;
            Camera.orthographicSize = InitalCameraSize;
        }


    }
}
