using UnityEngine;

namespace Midterm
{
    public class Target : MonoBehaviour
    {
        [SerializeField] TargetDoor door;
        public bool isHit;

        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Bullet") || collision.gameObject.CompareTag("Rocket"))
            {
                isHit = true;
                door.CheckDoor();
                gameObject.SetActive(false);
            }
        }
    }
}
