using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public int score;
    public int highScore;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Add the "value" amount at the score 
    public void RiseScore(int value)
    {
        score += value;
    }

    //Display the score
    public void DisplayScore(Text text)
    {
        text.text = score.ToString("000");
    }
    
}
