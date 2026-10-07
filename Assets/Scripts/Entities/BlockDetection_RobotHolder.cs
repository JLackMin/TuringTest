using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Midterm
{
    public class BlockDetection_RobotHolder : MonoBehaviour
    {
        string targetTag = "RobotHolder";
        [SerializeField] Animator animator;
        [SerializeField] TextMeshProUGUI robotText;
        public UnityEvent onTrigger;
        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(targetTag))
            {
                onTrigger?.Invoke();
                Invoke("Cinematic",0.5f);
                Invoke("Animate",1.5f);
            }
        }

        void Animate()
        {
            animator.Play("RobotHolder",0,Math.Clamp(animator.GetCurrentAnimatorStateInfo(0).normalizedTime,0f,1f));
            animator.SetFloat("Speed",1f);
        }

        void Cinematic()
        {
            PlayCinematic cinematic = GetComponent<PlayCinematic>();
            StartCoroutine(cinematic.Play(5f));
            Invoke("RobotText",5f);
        }

        void RobotText()
        {
            robotText.gameObject.SetActive(true);
            Invoke("RemoveRobotText",3f);
        }

        void RemoveRobotText()
        {
            robotText.gameObject.SetActive(false);
        }
    }
}
