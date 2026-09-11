using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

namespace Midterm
{
    public class SimpleInteractor : Interactor
    {
        [Header("Interact")]
        [SerializeField] private Camera _cam;
        [SerializeField] private LayerMask _interactionLayer;
        [SerializeField] private float _interactDistance;

        private RaycastHit _raycastHit;
        private ISelectable _selectable;

        public override void Interact()
        {
            // cast a ray
            Ray ray = _cam.ScreenPointToRay(new Vector3(Screen.width/2,Screen.height/2,0));

            if (Physics.Raycast(ray,out _raycastHit,_interactDistance,_interactionLayer))
            {
                _selectable = _raycastHit.transform.GetComponent<ISelectable>();

                if (_selectable != null)
                {
                    _selectable.OnHoverEnter();

                    if (PlayerInput.Instance.activatePressed)
                    {
                        _selectable.OnSelect();
                    }
                }
            }

            if (_raycastHit.transform == null && _selectable != null)
            {
                _selectable.OnHoverExit();
                _selectable = null;
            }

            Debug.DrawRay(_cam.transform.position, _cam.transform.forward * _interactDistance, Color.green);
        }
    }
}
