using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMan : MonoBehaviour
{
    public int HoleStrokes;
    public int HolePar;
    public int HoleNumber;
    public Text ObText; 
    enum ScoreString { Ace=1, Birdie, Par, Bogey, Double_Bogey, Triple_Bogey, Good_Try};
    public Text scoreText;
    public Text parText;
    public Text scoreHoleText; 
    private string HoleScore = string.Empty;
    private DataManager _dataMan;
    private string ObString = ""; 


    // Start is called before the first frame update
    void Start()
    {
        _dataMan = GameObject.Find("DataManager").GetComponent<DataManager>();
    }

    // Update is called once per frame
    void Update()
    {
         
    }
    private void OnGUI()
    {
        scoreText.text = "Stroke: "+ HoleStrokes.ToString();
        parText.text = "Par: "+ HolePar.ToString();
        scoreHoleText.text = HoleScore;
        ObText.text = ObString; 
    }

    public void Ob()
    {
        Debug.Log("OB");
       
        StartCoroutine(ObStroke());
    }

    public void ScoreHole()
    {
        var ScoreStatus = new ScoreString();
        if (HoleStrokes > 7)
        {
            ScoreStatus = (ScoreString)7;
        }
        else
        {
            ScoreStatus = (ScoreString)HoleStrokes;
        }
        var decorator = "";
        if (HoleStrokes - HolePar > 0)
                decorator = "+";

        _dataMan.Strokes[HoleNumber-1] = HoleStrokes;
        _dataMan.StrokesToPar[HoleNumber - 1] = HolePar; 

        HoleScore = ScoreStatus.ToString().Replace('_',' ') + " "+ decorator + (HoleStrokes - HolePar).ToString();
        _dataMan.nextHole = HoleNumber + 1;
        StartCoroutine(PauseCoroutine());
    }

    public IEnumerator ObStroke()
    {
        ObString = "OB";
        yield return new WaitForSeconds(3f);
        ObString = "";
        Debug.Log("Coroutine Done");
    }

    IEnumerator PauseCoroutine()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("ScoreScreen");
    }


}


