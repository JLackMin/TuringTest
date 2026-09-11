using UnityEngine;

namespace Midterm
{
    public abstract class Interactor : MonoBehaviour
    {
        //Delete because we have singleton now
        //[SerializeField] protected PlayerInput _input;

        private void Update()
        {
            Interact();
        }

        public abstract void Interact();
    }
}
