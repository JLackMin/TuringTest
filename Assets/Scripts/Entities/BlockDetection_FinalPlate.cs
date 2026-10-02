using UnityEngine;
using UnityEngine.Events;

namespace Midterm
{
    public class BlockDetection_FinalPlate : MonoBehaviour
    {
        string targetTag = "RobotGood";
        public UnityEvent onTrigger;
        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(targetTag))
            {
                Invoke("BlockUnlocked",2f);
                Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
                rb.detectCollisions = false;
            }
        }

        void BlockUnlocked()
        {
            Debug.Log("Trigger.");
            onTrigger?.Invoke();
        }
    }
}
