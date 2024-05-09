using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class onHityBat : MonoBehaviour
{
    public TrailRenderer trailRenderer; 
    public GameObject batObject;
     public distanceTracker distanceTracker; // Référence au script de suivi de distance
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == batObject)
        {
            distanceTracker.ResetDistance();
            distanceTracker.SetStartPoint(transform.position);
            trailRenderer.enabled = true;
        }
    }
    
}
