using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IsStrike : MonoBehaviour
{
    private Transform baseballTransform;
    private Transform point;
    private Transform strikeZone;
    private Rigidbody _rigidbody;
    bool flag = true;
    
    // Start is called before the first frame update
    void Start()
    {
        baseballTransform = GameObject.Find("Baseball").transform;
        point = this.GetComponent<Transform>();
        strikeZone = GameObject.Find("StrikeZone").transform;
        _rigidbody = GameObject.Find("Baseball").GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (baseballTransform.position.z >= -1.013 && flag)
        {
            flag = false;
            point.position = new Vector3(baseballTransform.position.x, baseballTransform.position.y, -1.013f);
            Debug.Log("速度：" + _rigidbody.velocity.magnitude);
            // rectTransform.localPosition = new Vector3(
            //     (baseballTransform.position.x - strikeZone.position.x) * 100,
            //     (baseballTransform.position.y - strikeZone.position.y) * 100,
            //     0);
            // Debug.Log("baseball:" + baseballTransform.position);
        }
        
        if (baseballTransform.position.z < -1)
        {
            flag = true;
        }
    }
}
