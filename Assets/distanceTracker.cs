using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;

public class distanceTracker : MonoBehaviour
{
    public TextMeshProUGUI distanceText; // Text to show the distance traveled
    public TrailRenderer trailRenderer; // TrailRenderer for the trail of the ball
    private float distanceTraveled = 0f; // Distance traveled by the ball
    private Vector3 startPoint; // Startitng point
   private bool trackDistance = false; // Flag (boolean) to activate or not the track of the distance
    private XRGrabInteractable grabInteractable;

    public GameObject batObject;

    private void Start()
    {
        distanceText.gameObject.SetActive(false);
        grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.onSelectEntered.AddListener(OnGrab);
        trailRenderer.enabled = false;
    }

    public void SetStartPoint(Vector3 position)
    {
        startPoint = position;
        distanceTraveled = 0f;
        trackDistance = true;
        distanceText.gameObject.SetActive(true);
    }

    private void Update()
    {
        // Verify if the distance tracker is activated
        if (trackDistance)
        {
            // Calculate the distance traveled from the starting point 
            distanceTraveled = Vector3.Distance(startPoint, transform.position);

            // Update the text to show the distance traveled
            distanceText.text = distanceTraveled.ToString("F2") + " m";
        }
    }

    // Reset the distance and un track the Distance of the ball
    public void ResetDistance()
    {
        distanceTraveled = 0f;
        trackDistance = false;
        distanceText.text = "0 m";
    }

    // When grabbing the ball the distance is reseted and the trail is removed
    private void OnGrab(XRBaseInteractor interactor)
    {
        ResetDistance();
        trailRenderer.enabled = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // When the ball hit the Bat we start to track the distance of the ball
        if (collision.gameObject == batObject)
        {
            ResetDistance();
            SetStartPoint(transform.position);
            trailRenderer.enabled = true;
        }
    }
}
