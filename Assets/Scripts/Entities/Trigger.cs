using UnityEngine;
using UnityEngine.Events;

namespace Midterm
{
    public class Trigger : MonoBehaviour, ISelectable
    {
        public UnityEvent _onInteract;

        public void OnHoverEnter()
        {
            return;
        }

        public void OnHoverExit()
        {
            return;
        }

        public void OnSelect()
        {
            _onInteract?.Invoke();
        }
    }
}
