using UnityEngine;
using System.Collections;

namespace Midterm
{
    public class DoorTrigger : MonoBehaviour
    {
        [SerializeField] string openTag;
        [SerializeField] Animator animator;
        float delayTime = 3f;

        // Start is called once before the first execution of Update after the MonoBehaviour is created

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(openTag))
            {
                animator.SetBool("DoorOpen",true);
            }
            
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag(openTag))
            {
                StartCoroutine(TimeDelay());
            }
        }

        IEnumerator TimeDelay()
        {
            yield return new WaitForSeconds(delayTime);
            animator.SetBool("DoorOpen",false);
        }
    }
}
