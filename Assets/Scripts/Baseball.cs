using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class Baseball : MonoBehaviour
{
    
    public int speed = 1;
    private Rigidbody _rigidbody;
    public Slider _slider;
    public float baseballSpeed;
    public distanceTracker distanceTrackerScript;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = this.GetComponent<Rigidbody>();
        _rigidbody.velocity = new Vector3(0, 0, 80);
        _rigidbody.AddTorque(Vector3.up * 100);
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("恭喜你！打到球了");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 0)
        {
            distanceTrackerScript.ResetDistance();
            // Can set the score 
            ThrowFastball();
            
        }

        // if (transform.position.z == 0)
        // {
        //     Debug.Log("球的位置：" + transform.position);
        // }
    }

    Vector3 GetRandomThrowPoint()
    {
        // x:-0.8-0.8  y:2.2-2.6 
        System.Random random = new System.Random();  
        double x = random.NextDouble() * 1.6 - 0.8;  
        double y = random.NextDouble() * 0.4 + 2.2;  
        // Debug.Log("出手点随机x:" + x + " y:" + y);
        return new Vector3((float)x, (float)y, -30);
    }
    
    void ThrowFastball()  // 直球
    {
        System.Random random = new System.Random();  
        double x = random.NextDouble();  
        double y = random.NextDouble() + 2;  
        int z = random.Next(45, 75); 
        transform.position = GetRandomThrowPoint();
        _rigidbody.velocity = new Vector3((float)x, (float)y, z);
        _rigidbody.angularVelocity = new Vector3(-50, 0, 0);
    }

    void ThrowSliderball()
    {
        
    }
}