using Unity.Hierarchy.Editor;
using Unity.VisualScripting;
using UnityEngine;

namespace Midterm
{
    public class ShootInteractor : Interactor
    {
        [SerializeField] private Input _inputType;

        [Header("Shoot")]
        [SerializeField] private Rigidbody _bulletPrefab;
        [SerializeField] private float _shootVelocity;
        [SerializeField] private Transform _shootPoint;
        [SerializeField] private PlayerMovementBehaviour _playerMovementBehaviour;

        private float _finalShootVelocity;

        public override void Interact()
        {
            if (_inputType == Input.Primary && _input.primaryShootPressed || _inputType == Input.Secondary && _input.secondaryShootPressed)
            {
                Shoot();
            }
        }

        void Shoot()
        {
            _finalShootVelocity = _playerMovementBehaviour.GetForwardSpeed() + _shootVelocity;

            Rigidbody bullet = Instantiate(_bulletPrefab, _shootPoint.position, _shootPoint.rotation);
            bullet.linearVelocity = _shootPoint.forward * _finalShootVelocity;
            Destroy(bullet.gameObject,7f); //remove once object pooling is added
        }
    }

    public enum Input
    {
        Primary,
        Secondary
    }
}
