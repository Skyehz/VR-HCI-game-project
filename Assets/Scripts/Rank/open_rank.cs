using System.Collections;
using System.Collections.Generic;
using rank;
using UnityEngine;

public class open_rank : MonoBehaviour
{
    public List<Score> scores = new List<Score>();
    public RankItem[] rankItems;
   
    //点击按钮，显示image
     public void Click()
    {
        gameObject.SetActive(true);
        for (int i = 0; i < 5; i++)
        {
            Debug.Log(rankItems[i].indexText.text);
        }
        LoadScoresFromFile("scores");
        for (int i = 0; i < 5; i++)
        {
            Debug.Log(rankItems[i].nameText.text);
        }
    }

    public void CloseRank()
    {
        gameObject.SetActive(false); 
    }
    
    
    void LoadScoresFromFile(string fileName)
    {
        TextAsset file = Resources.Load<TextAsset>(fileName);
        if (file == null)
        {
            Debug.LogError("File not found");
            return;
        }

        string[] lines = file.text.Split('\n');
        int index = 1;

        foreach (string line in lines)
        {
            if (!string.IsNullOrEmpty(line.Trim()))
            {
                Score score = JsonUtility.FromJson<Score>(line);
                score.rankIndex = index;
                rankItems[index-1].setItem(score);
                scores.Add(score);
                index++;
            }
        }
    }
    
    
}
