using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HapticInteractable : MonoBehaviour
{
    public Haptic hapticOnActivated;
    public AudioSource hitSound;

    public XRBaseController LeftRightController;
    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable interactable = GetComponent<XRGrabInteractable>();
        interactable.activated.AddListener(hapticOnActivated.TriggerHaptic);
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Ball"))
        {
            hapticOnActivated.TriggerHaptic(LeftRightController);
            hitSound.Play();
        }
    }
    
    [System.Serializable]
    public class Haptic
    {
        [Range(0, 1)]
        public float intensity;
        public float duration;
        
        public void TriggerHaptic(XRBaseController controller)
        {
            if (intensity > 0)
            {
                controller.SendHapticImpulse(intensity, duration);
            }
        }

        public void TriggerHaptic(BaseInteractionEventArgs eventArgs)
        {
            if (eventArgs.interactorObject is XRBaseControllerInteractor controllerInteractor)
            {
                TriggerHaptic(controllerInteractor.xrController);
            }
        }
    }
}