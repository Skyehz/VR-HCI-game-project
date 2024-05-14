using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class SpeedChange : MonoBehaviour
{
    // Start is called before the first frame update
    private TextMeshProUGUI _speed;
    public Rigidbody baseball;
    bool flag = true;
    void Start()
    {
        baseball = GameObject.Find("Baseball").GetComponent<Rigidbody>();
        _speed = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (baseball.transform.position.z >= -1.013 && flag)
        {
            flag = false;
            _speed.text = baseball.velocity.magnitude.ToString("f1");
        }
        if (baseball.transform.position.z < -1)
        {
            flag = true;
        }
    }
}
