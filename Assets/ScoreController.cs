using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    private int score;
    public Text text;
    public IsHit _isHit;
    
    // Start is called before the first frame update
    void Start()
    {
        // score = _isHit.getScore();
    }

    // Update is called once per frame
    void Update()
    {
        score = _isHit.getScore();
        text.text = "Score: " + score;
    }
}
