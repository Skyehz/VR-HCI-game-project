using System;
using System.Collections;
using System.Collections.Generic;
using rank;
using UnityEngine;
using System.IO; 
using TMPro;

public class open_rank : MonoBehaviour
{
    public List<Score> scores = new List<Score>();
    public RankItem[] rankItems;
    private string path = "/sdcard/Download/";

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
        string _filePath = Path.Combine(Application.persistentDataPath, fileName);
        //string _filePath = Path.Combine(path, fileName);
        string fileContent = File.ReadAllText(_filePath);  
  
        // TextAsset file = Resources.Load<TextAsset>(_filePath);
        if (!Directory.Exists(Application.persistentDataPath))
        {
            Directory.CreateDirectory(Application.persistentDataPath);
        }
        Debug.Log("文件路径：" + _filePath);
        
        string[] lines = fileContent.Split('\n');
        int index = 1;

        scores.Clear();
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
    
    // 添加并保存新分数的函数  
    public void AddAndSaveScore(string playerName, int playerScore, string fileName)  
    {  
        // 创建新分数  
        Score newScore = new Score(0, playerName, playerScore.ToString()); // 注意：这里假设rankIndex稍后会设置  
        
        // 加载现有分数  
        LoadScoresFromFile(fileName);  
  
        // 将新分数添加到列表  
        scores.Add(newScore);  
  
        // 根据分数排序  
        scores.Sort((s1, s2) => int.Parse(s2.score).CompareTo(int.Parse(s1.score))); // 降序排序  
  
        // 分配排名索引  
        for (int i = 0; i < scores.Count; i++)  
        {  
            scores[i].rankIndex = i + 1;  
        }  
  
        // 将排序后的分数写回文件  
        SaveScoresToFile(fileName);  
    }  
  
    // 将分数保存回文件的函数  
    private void SaveScoresToFile(string fileName)  
    {  
        string content = "";  
        foreach (var score in scores)  
        {  
            content += JsonUtility.ToJson(score) + "\n";  
        }  
        Debug.Log("写入文件的信息是：" + content);
  
        // 使用Unity的Application.persistentDataPath来确保文件在正确的位置  
        string filePath = Path.Combine(Application.persistentDataPath, fileName);  
        Debug.Log("写入文件路径：" + filePath);
        // 写入文件  
        File.WriteAllText(filePath, content);  
    }
    
    
}
