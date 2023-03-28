using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    
    int score;
    public TextMeshProUGUI ScoreText;

    // Start is called before the first frame update
    void Start()
    {
        ScoreText = GetComponent<TextMeshProUGUI>();
        ScoreText.text = score.ToString();
    }

    // Update is called once per frame
    public void Scorehit(int scoreincrease)
    {
        score = score + scoreincrease;
        ScoreText.text = score.ToString();
    }
}
