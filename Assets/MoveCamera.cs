using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    private Transform ballTransform;
    private Transform cameraTransform;
    private Vector3 offset;
    private Vector3 pos;
    private Vector3 distance;
    
    // Start is called before the first frame update
    void Start()
    {
        ballTransform = GameObject.Find("Baseball").transform;
        cameraTransform = this.GetComponent<Transform>();
        offset = new Vector3(0, 0, 10);
        distance = transform.position - ballTransform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, ballTransform.position + offset, Time.deltaTime * 2f);
        transform.LookAt(ballTransform.position);
    }
}
