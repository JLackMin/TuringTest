using Unity.VisualScripting;
using UnityEngine;

namespace Midterm
{
    public class PickupInteractor : Interactor
    {
        [SerializeField] private Camera _cam;
        [SerializeField] private LayerMask _pickupLayer;
        [SerializeField] private float _pickupDistance;
        [SerializeField] private Transform _attachTransform;

        private bool isPicked = false;
        private RaycastHit _raycastHit;
        private IPickable _pickable;

        public override void Interact()
        {
            Ray ray = _cam.ScreenPointToRay(new Vector3(Screen.width/2,Screen.height/2,0));

            if (Physics.Raycast(ray, out _raycastHit, _pickupDistance, _pickupLayer))
            {
                if (_input.activatePressed && !isPicked)
                {
                    _pickable = _raycastHit.transform.GetComponent<IPickable>();

                    if (_pickable == null) return;

                    _pickable.OnPicked(_attachTransform);
                    isPicked = true;
                    return;
                }
            }

            if (_input.activatePressed && isPicked && _pickable != null)
            {
                _pickable.OnDropped();
                isPicked = false;
            }
        }
    }
}
