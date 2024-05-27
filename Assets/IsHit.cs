using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsHit : MonoBehaviour
{
    private Animator _animator;
    private Transform ballTransform;
    private float waitTime = 3.55f;
    private float stand_time = 0.0f;
    private bool isHitBall = false;
    private Collider baseballCollider;
    private Baseball _baseball;
    
    // Start is called before the first frame update
    void Start()
    {
        _animator = GameObject.Find("Baseball Pitching").GetComponent<Animator>();
        ballTransform = GameObject.Find("Baseball").GetComponent<Transform>();
        baseballCollider = GameObject.Find("Baseball").GetComponent<Collider>();
        _baseball = GameObject.Find("Baseball").GetComponent<Baseball>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            Debug.Log("Hit the ball");
            isHitBall = true;
        }
    }

    private bool isFoul()
    {
        return _baseball.isFoul;
    }
    
    // Update is called once per frame
    void Update()
    {
        
        if (isHitBall)
        {
            stand_time = 0;
            stand_time += Time.deltaTime;
            _animator.SetInteger("IsThrow", 0);
            if (stand_time > 5)
            {
                stand_time = 0;
                isHitBall = false;
            }
            // 判断球是否出界（不出界：Home Run, Ground, 出界：Foul Ball）
            if (isFoul())
            {
                Debug.Log("Foul Ball!");
            }
            else
            {
                Debug.Log("Home Run, Ground");
            }
            // 判断球是否是全垒打（是：Home Run, 不是：Ground）
            
        }
        else
        {
            stand_time += Time.deltaTime;
            if (stand_time < waitTime)
            {
                _animator.SetInteger("IsThrow", 1);
            }
            else if (stand_time > waitTime && stand_time < waitTime + 3)
            {
                _animator.SetInteger("IsThrow", 0);
            }
            else if (stand_time > waitTime + 3)
            {
                stand_time = 0;
            }
        }
    }
}
