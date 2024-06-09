using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;

public class StartGame : MonoBehaviour
{
    //public InputActionReference tirgger_Action;
    //public InputActionReference is_tracked;

    public void OnClick()
    {
        SceneManager.LoadScene(1);
    }
    private void Update()
    {
        /*if (tirgger_Action.action.WasPerformedThisFrame())
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if(is_tracked.action.WasPerformedThisFrame())
        {
            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }*/
    }
}