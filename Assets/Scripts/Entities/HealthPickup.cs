using UnityEngine;
using UnityEngine.Events;

namespace Midterm
{
    public class HealthPickup : MonoBehaviour, ISelectable
    {
        public UnityEvent _onInteract;
        [SerializeField] Material defaultMaterial;
        [SerializeField] Material hoverMaterial;
        [SerializeField] MeshRenderer renderer;

        public void OnHoverEnter()
        {
            renderer.material = hoverMaterial;
        }

        public void OnHoverExit()
        {
           renderer.material = defaultMaterial;
        }

        public void OnSelect()
        {
            _onInteract?.Invoke();
        }
    }
}
