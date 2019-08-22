using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{

   
    /// <summary>
    /// Three holes for now...
    /// </summary>
    public int[] Strokes = new int[3];
    public int[] StrokesToPar = new int[3];

    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

}
