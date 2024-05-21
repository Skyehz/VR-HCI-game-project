using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBallController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float waitTime = 2.0f;
    private float time = 1.0f;
    Animator animator;
    private int move_var = 0;
    
    void Start()
    {
        animator = GetComponent<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {
        pitcherMove();
    }

    void pitcherMove()
    {
        if (time < waitTime && time >= 0)
        {
            time += Time.deltaTime;
            move_var = 0;
            animator.SetInteger("IsThrow", move_var);
        }
        else if(time < 0)
        {
            time += Time.deltaTime;
        }
        else
        {
            move_var = 1;
            animator.SetInteger("IsThrow", move_var);
            time = -2.0f;
        }
    }
}
