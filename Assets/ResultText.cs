using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultText : MonoBehaviour
{
    // Start is called before the first frame update
    private Text m_ResultText;
    private Animation m_Animation;
    
    void Start()
    {
        m_ResultText = GetComponent<Text>();
        m_Animation = GetComponent<Animation>();
        m_ResultText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void DisplayResult(Result.ResultState state)
    {
        string anim_str = "HomeRunUI";
        switch (state)
        {
            case Result.ResultState.HR:
                m_ResultText.text = "HOMERUN!!";
                m_ResultText.color = Color.yellow;
                anim_str = "HomeRunUI";
                break;
            case Result.ResultState.Foul:
                m_ResultText.text = "FOUL";
                m_ResultText.color = Color.red;
                break;
            case Result.ResultState.StrikeOut:
                m_ResultText.text = "STRIKE";
                m_ResultText.color = Color.red;
                break;
            case Result.ResultState.Ground:
            default:
                m_ResultText.text = "GROUND BALL";
                m_ResultText.color = Color.green;
                break;
        }
        m_ResultText.enabled = true;
        m_Animation.Play(anim_str);
    }
    
    public void OnAnimationFinisehd(string str)
    {
        m_ResultText.enabled = false;
    }
}
