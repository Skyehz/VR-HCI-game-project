using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PopUpMenu : MonoBehaviour
{
    public IsHit _isHit;
    public TMP_InputField input_player_name;
    public open_rank _OpenRank;
    
    public void Start()
    {
    }

    public void Click()
    {
        gameObject.SetActive(true); 
    }

    public void CloseMenu()
    {
        gameObject.SetActive(false); 
    }

    public void Restart()
    {
        _isHit.ResetScore();
        gameObject.SetActive(false); 
    }

    public void Confirm()
    {
        // 获取输入
        Debug.Log(input_player_name.text);
        String playerName = input_player_name.text;
        int score = _isHit.getScore();
        _OpenRank.AddAndSaveScore(playerName, score, "scores");
        _isHit.ResetScore();
        gameObject.SetActive(false);
    }
    
    public void ReturntoMenu()
    {
        _isHit.ResetScore();
        gameObject.SetActive(false);
        SceneManager.LoadScene(0);
    }
}
