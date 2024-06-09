using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class remianController : MonoBehaviour
{
    private int remain_ball;
    public int num_per_round = 15;
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
        remain_ball = num_per_round - _isHit.getThrowTimes();
        text.text = "Remain: " + remain_ball;
    }
}
