using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject disc; 
    public float CameraXoffset = 0f;
    public float CameraYoffset = 0f; 

    // Update is called once per frame
    void Update()
    {
        if(disc != null)
        {

            Vector3 targetPos = disc.transform.position - new Vector3(CameraXoffset, CameraYoffset, 0);
            targetPos.z = transform.position.z;
            transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime);

        }        
    }
}
