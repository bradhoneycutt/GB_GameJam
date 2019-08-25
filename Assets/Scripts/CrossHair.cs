using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHair : MonoBehaviour
{
    public GameObject CrossHairObject;
    public GameObject Basket;
    public GameObject Disc;
    public float CrossHairSweepSpeed;

    // Start is called before the first frame update
    void Start()
    {
        InitCrossHair();
    }

    public void InitCrossHair()
    {
        var toBasket = Basket.transform.position - Disc.transform.position;
        toBasket.Normalize();
        toBasket *= 3F;
        CrossHairObject.transform.localPosition = toBasket;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            CrossHairObject.transform.RotateAround(Disc.transform.localPosition, Vector3.forward, CrossHairSweepSpeed * Time.deltaTime);
            CrossHairObject.transform.rotation = Quaternion.AngleAxis(0, Vector3.forward);
        }
        if(Input.GetKey(KeyCode.RightArrow))
        {
            CrossHairObject.transform.RotateAround(Disc.transform.localPosition, Vector3.forward, -CrossHairSweepSpeed * Time.deltaTime);
            CrossHairObject.transform.rotation = Quaternion.AngleAxis(0, Vector3.forward);
        }
    }
}
