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
        // Désactive le TextMesh au départ
        distanceText.gameObject.SetActive(false);

        // Récupère le composant XRGrabInteractable
        grabInteractable = GetComponent<XRGrabInteractable>();

        // Abonnez-vous à l'événement de saisie
        grabInteractable.onSelectEntered.AddListener(OnGrab);

        // Désactive le TrailRenderer au départ
        trailRenderer.enabled = false;
    }

    public void SetStartPoint(Vector3 position)
    {
        // Définit la position donnée comme point de départ
        startPoint = position;
        // Réinitialise la distance parcourue à zéro
        distanceTraveled = 0f;
        // Active le suivi de la distance
        trackDistance = true;
        // Active le TextMesh
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
        // Réinitialise la distance parcourue à zéro
        distanceTraveled = 0f;
        // Désactive le suivi de la distance
        trackDistance = false;
        // Réinitialise le TextMesh à "0 m"
        distanceText.text = "0 m";
    }

    private void OnGrab(XRBaseInteractor interactor)
    {
        // Réinitialise la distance parcourue lorsque la balle est saisie
        ResetDistance();
        // Désactive le TrailRenderer lorsque la balle est saisie
            trailRenderer.enabled = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == batObject)
        {
            // Réinitialise la distance parcourue lorsque la balle est touchée par la batte
            ResetDistance();
            // Définit le point de départ à la position actuelle de la balle
            SetStartPoint(transform.position);
            // Active le TrailRenderer lorsque la balle est touchée par la batte
                trailRenderer.enabled = true;
        }
    }
}
