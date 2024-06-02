using System.Collections;
using System.Collections.Generic;
using rank;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RankItem : MonoBehaviour
{
    public TextMeshProUGUI indexText;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI scoreText;

    public void setItem(Score item)
    {
        indexText.text = item.rankIndex.ToString();
        nameText.text = item.name;
        scoreText.text = item.score;
    }
}
