using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerMeter : MonoBehaviour
{
    public GameObject Bar;
    public float Power = 100;
    public float PowerBarSpeed;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            if(Power >= 100)
            {
                return;
            }
            Power += PowerBarSpeed * Time.deltaTime;
            DrawBar();
        }
        if(Input.GetKey(KeyCode.DownArrow))
        {
            if(Power <= 0)
            {
                return;
            }
            Power -= PowerBarSpeed * Time.deltaTime;
            DrawBar();
        }
    }

    void DrawBar()
    {
        Bar.transform.localScale = new Vector3(20, Power, 1);
    }
}
