using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private DataManager _dataMan;
    // Start is called before the first frame update
    void Start()
    {
        _dataMan = GameObject.Find("DataManager").GetComponent<DataManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire2"))
        {

            _dataMan.Strokes[0] = 0;
            _dataMan.Strokes[1] = 0;
            _dataMan.Strokes[2] = 0;

            _dataMan.StrokesToPar[0] = 0;
            _dataMan.StrokesToPar[1] = 0;
            _dataMan.StrokesToPar[2] = 0;

            SceneManager.LoadScene("Hole1");
        }
    }
}
