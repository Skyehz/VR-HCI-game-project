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
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = this.GetComponent<Rigidbody>();
        _rigidbody.velocity = new Vector3(0, 0, 50);
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
            transform.position = new Vector3(
                0f,
                3.0f,
                -30
            );
            _rigidbody.velocity = new Vector3(0, 0, 50);
            _rigidbody.AddTorque(Vector3.up * 100);
        }
    }
}
