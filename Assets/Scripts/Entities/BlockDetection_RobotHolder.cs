using System;
using UnityEngine;
using UnityEngine.Events;

namespace Midterm
{
    public class BlockDetection_RobotHolder : MonoBehaviour
    {
        string targetTag = "RobotHolder";
        [SerializeField] Animator animator;
        public UnityEvent onTrigger;
        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(targetTag))
            {
                onTrigger?.Invoke();
                Invoke("Animate",0.5f);
            }
        }

        void Animate()
        {
            Debug.Log("Block on plate.");
            animator.Play("RobotHolder",0,Math.Clamp(animator.GetCurrentAnimatorStateInfo(0).normalizedTime,0f,1f));
            animator.SetFloat("Speed",1f);
        }
    }
}
