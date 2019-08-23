using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMan : MonoBehaviour
{
    public int HoleStrokes;
    public int HolePar;
    public int HoleNumber; 
    enum ScoreString { Ace=1, Birdie, Par, Bogey, Double_Bogey, Triple_Bogey, Good_Try};
    public Text scoreText;
    public Text parText;
    public Text scoreHoleText; 
    private string HoleScore = string.Empty;
    private DataManager _dataMan; 


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
    }

}


