using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class Baseball : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public Slider _slider;
    private Animator _animator;
    private bool flag = true;
    private Vector3 right_hand_pos;
    [SerializeField]private double throw_time = 0.36;
    private Vector3 offset = new Vector3(-0.115f, -0.183f, 0.0f);
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = this.GetComponent<Rigidbody>();
        // _rigidbody.velocity = new Vector3(0, 0, 80);
        // _rigidbody.AddTorque(Vector3.up * 100);
        _rigidbody.transform.position = GameObject.Find("mixamorig5:RightHand").transform.position + offset;
        _animator = GameObject.Find("Baseball Pitching").GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Congratulations! You hit the ball.");
    }

    // Update is called once per frame
    void Update()
    {
        right_hand_pos = GameObject.Find("mixamorig5:RightHand").transform.position + offset;
        AnimatorStateInfo stateInfo = _animator.GetCurrentAnimatorStateInfo(0);
        Debug.Log(stateInfo.normalizedTime);
        if (stateInfo.normalizedTime > throw_time && flag && stateInfo.IsName("Pitched"))
        {
            ThrowFastball(right_hand_pos);
            flag = false;
        }
        else if (stateInfo.IsName("Pitched") && flag && stateInfo.normalizedTime <= throw_time)
        {
            _rigidbody.transform.position = right_hand_pos;
        }

        if (stateInfo.IsName("Stand"))
        {
            _rigidbody.transform.position = right_hand_pos;
            flag = true;
        }
    }

    Vector3 GetRandomThrowPoint()
    {
        // x:-0.8-0.8  y:2.2-2.6 
        System.Random random = new System.Random();
        double x = random.NextDouble() * 1.6 - 0.8;  
        double y = random.NextDouble() * 0.4 + 2.2;  
        Debug.Log("出手点随机x:" + x + " y:" + y);
        return new Vector3((float)x, (float)y, -30);
    }
    
    void ThrowFastball(Vector3 pos)  // 直球
    {
        System.Random random = new System.Random();  
        double x = random.NextDouble();  
        double y = random.NextDouble();  
        int z = random.Next(80, 100); 
        transform.position = GetRandomThrowPoint();
        _rigidbody.velocity = new Vector3((float)x, (float)y, z);
        _rigidbody.angularVelocity = new Vector3(-50, 0, 0);
    }

    void ThrowSliderball()
    {
        
    }
}