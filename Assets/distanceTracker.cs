using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;

public class distanceTracker : MonoBehaviour
{
    public TextMeshProUGUI distanceText; // Texte pour afficher la distance parcourue
    public TrailRenderer trailRenderer; // TrailRenderer pour la traînée de la balle
    private float distanceTraveled = 0f; // Distance parcourue par la sphère
    private Vector3 startPoint; // Point de départ
    private bool trackDistance = false; // Drapeau pour activer le suivi de la distance
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
        // Vérifie si le suivi de la distance est activé
        if (trackDistance)
        {
            // Calcule la distance parcourue depuis le point de départ
            distanceTraveled = Vector3.Distance(startPoint, transform.position);

            // Met à jour le texte pour afficher la distance parcourue
            distanceText.text = distanceTraveled.ToString("F2") + " m";
        }
    }

    public void ResetDistance()
    {
        distanceTraveled = 0f;
        trackDistance = false;
        distanceText.text = "0 m";
    }

    private void OnGrab(XRBaseInteractor interactor)
    {
        ResetDistance();
            trailRenderer.enabled = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == batObject)
        {
            ResetDistance();
            SetStartPoint(transform.position);
            trailRenderer.enabled = true;
        }
    }
}
