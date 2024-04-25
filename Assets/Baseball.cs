using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baseball : MonoBehaviour
{
    
    public int speed = 1;
    private Rigidbody _rigidbody;
    private float acceleration = 0.005f;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = this.GetComponent<Rigidbody>();
        _rigidbody.velocity = -Vector3.forward * 40;
        _rigidbody.AddTorque(Vector3.up * 100);
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("恭喜你！打到球了");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < -5 || transform.position.y < 0)
        {
            transform.position = new Vector3(
                0.4f,
                3.0f,
                20
            );
            _rigidbody.velocity = -Vector3.forward * 40;
            _rigidbody.AddTorque(Vector3.up * 100);
        }
    }
}
