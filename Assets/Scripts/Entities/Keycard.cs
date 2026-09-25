using UnityEngine;
using UnityEngine.Events;

namespace Midterm
{
    public class Keycard : MonoBehaviour, ISelectable
    {
        [SerializeField] private Material _default;
        [SerializeField] private Material _hoverColour;
        [SerializeField] private MeshRenderer _renderer;

        public UnityEvent _onPush;

        public void OnHoverEnter()
        {
            _renderer.material = _hoverColour;
        }

        public void OnHoverExit()
        {
            _renderer.material = _default;
        }

        public void OnSelect()
        {
            _onPush?.Invoke();
        }
    }
}
