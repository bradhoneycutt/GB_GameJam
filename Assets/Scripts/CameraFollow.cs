using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject disc; 
    public float CameraXoffset = 0f;
    public float CameraYoffset = 0f;
    private Transform _cursor;
    private Camera _camera; 

    private void Start()
    {
        _cursor = GameObject.Find("Player").transform.GetChild(2);
        _camera = gameObject.GetComponent<Camera>();
    }


    // Update is called once per frame
    void Update()
    {
        if(disc != null)
        {
            CrossHairInView();
            Vector3 targetPos = disc.transform.position - new Vector3(CameraXoffset, CameraYoffset, 0);
            targetPos.z = transform.position.z;
            transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime);

        }        
    }

    void CrossHairInView()
    {
        Debug.Log(_cursor.localPosition.x + ", " + _cursor.localPosition.y);
        //aiming back
        if(_cursor.localPosition.y < 0)
        {
            CameraYoffset = 4f;
        }
        else
        {
            CameraYoffset = -3.5f;
        }
        //Vector3 screenPoint = _camera.WorldToViewportPoint(_cursor.position);
        //if (screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1)
        //{
        //    // Debug.Log("inView");
           
        //}
        //else
        //{
        //    //Debug.Log("Out of View");
            
        //}
    }
}
