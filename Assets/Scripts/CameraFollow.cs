using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject disc; 

    // Update is called once per frame
    void Update()
    {
        if(disc != null)
        {

            Vector3 targetPos = disc.transform.position;
            targetPos.z = transform.position.z;
            transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime);

        }        
    }
}
