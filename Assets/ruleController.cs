using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ruleController : MonoBehaviour
{
    public GameObject rule_menu;
    
    public void OnClick()
    {
        rule_menu.SetActive(true);
    }

    public void Exit()
    {
        rule_menu.SetActive(false);
    }
    
}
