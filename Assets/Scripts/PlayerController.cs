using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject CrossHair; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveCrossHair();
    }

    private void MoveCrossHair()
    {

        Vector3 aim = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);

       


        if(aim.magnitude > 0.0f)
        {
            aim.Normalize();
            aim *= 3f;
                CrossHair.transform.localPosition = aim; 
        }
    }
}
