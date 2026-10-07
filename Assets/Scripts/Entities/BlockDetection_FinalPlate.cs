using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Midterm
{
    public class BlockDetection_FinalPlate : MonoBehaviour
    {
        string targetTag = "RobotGood";
        public UnityEvent onTrigger;
        [SerializeField] Animator animator;
        [SerializeField] TextMeshProUGUI buttonText;
        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(targetTag))
            {
                Invoke("Cinematic",1f);
                Invoke("BlockUnlocked",3f);
                Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
                rb.detectCollisions = false;
            }
        }

        void BlockUnlocked()
        {
            onTrigger?.Invoke();
        }

        void Cinematic()
        {
            PlayCinematic cinematic = GetComponent<PlayCinematic>();
            StartCoroutine(cinematic.Play(3f));
            Invoke("ButtonText",3f);
        }

        void ButtonText()
        {
            buttonText.gameObject.SetActive(true);
            Invoke("RemoveButtonText",3f);
        }

        void RemoveButtonText()
        {
            buttonText.gameObject.SetActive(false);
        }

    }
}
