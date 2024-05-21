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
    private Vector3 startPoint; // Starting point
    private bool trackDistance = false; // Flag (boolean) to activate or not the track of the distance

    public GameObject batObject;
    public GameObject ballCamera; // Prefab for the new camera to follow the ball
    public float groundLevel = 0.0f; // The y-level that is considered the ground
    private bool isFollowingBall = false; // Flag to check if the camera is following the ball

    public Vector3 cameraOffset = new Vector3(0, 2, -5); // Offset for the camera position
    public float smoothTime = 0.3f; // SmoothDamp time

    private Vector3 velocity = Vector3.zero;

    private void Start()
    {
        distanceText.gameObject.SetActive(false);
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

        // If the camera is following the ball, update its position
        if (isFollowingBall && ballCamera.GetComponent<Camera>() != null)
        {
            Vector3 targetPosition = transform.position + cameraOffset;
            ballCamera.GetComponent<Camera>().transform.position = Vector3.SmoothDamp(ballCamera.GetComponent<Camera>().transform.position, targetPosition, ref velocity, smoothTime);
            ballCamera.GetComponent<Camera>().transform.LookAt(transform.position);
        }
    }

    public void StopFollowingBall()
    {
        if (ballCamera.GetComponent<Camera>() != null)
        {
            ballCamera.GetComponent<Camera>().gameObject.SetActive(false);
        }

        isFollowingBall = false;
        ResetDistance();
    }

    // Reset the distance and untrack the distance of the ball
    public void ResetDistance()
    {
        distanceTraveled = 0f;
        trackDistance = false;
        distanceText.text = "0 m";
    }

    // When grabbing the ball the distance is reset and the trail is removed
    private void OnGrab(XRBaseInteractor interactor)
    {
        StopFollowingBall();
        trailRenderer.enabled = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // When the ball hits the bat we start to track the distance of the ball
        if (collision.gameObject == batObject)
        {
            ResetDistance();
            SetStartPoint(transform.position);
            trailRenderer.enabled = true;
            StartFollowingBall();
        }
    }

    private void StartFollowingBall()
    {
        GameObject cameraObject = Instantiate(ballCamera);
        SetupBallFollowCamera(ballCamera.GetComponent<Camera>());
        ballCamera.GetComponent<Camera>().gameObject.SetActive(true);
        isFollowingBall = true;
    }

    private void SetupBallFollowCamera(Camera camera)
    {
        // Set the viewport rect to display the camera in the top-left corner
        camera.rect = new Rect(0.75f, 0.75f, 0.25f, 0.25f); // Adjust as necessary for position and size
    }
}
