using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    public Text Hole1Score;
    public Text Hole2Score;
    public Text Hole3Score;
   

    private DataManager _dataMan;



    // Start is called before the first frame update
    void Start()
    {
        _dataMan = GameObject.Find("DataManager").GetComponent<DataManager>();

        StartCoroutine("PauseCoroutine");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI()
    {
        var hole1 = _dataMan.Strokes[0] - _dataMan.StrokesToPar[0];
        var decorator = (_dataMan.Strokes[0] - _dataMan.StrokesToPar[0]) > 0 ? "+" : ""; 
        Hole1Score.text = decorator + hole1.ToString();

        var hole2 = _dataMan.Strokes[1] - _dataMan.StrokesToPar[1];
        decorator = (_dataMan.Strokes[1] - _dataMan.StrokesToPar[1]) > 0 ? "+" : "";
        Hole3Score.text = decorator + hole2.ToString();

        var hole3 = _dataMan.Strokes[2] - _dataMan.StrokesToPar[2];
        decorator = (_dataMan.Strokes[2] - _dataMan.StrokesToPar[2]) > 0 ? "+" : "";
        Hole3Score.text = decorator + hole3.ToString();

    }

    IEnumerator PauseCoroutine()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Hole" + _dataMan.nextHole);
    }

}
