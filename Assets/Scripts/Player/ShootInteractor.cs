using Unity.VisualScripting;
using UnityEngine;

namespace Midterm
{
    public class ShootInteractor : Interactor
    {
        [SerializeField] Input _inputType;
        IWeaponBehaviour _currentShootStrategy;

        [Header("Shoot")]
        [SerializeField] Rigidbody _bulletPrefab;
        [SerializeField] float _shootVelocity;
        [SerializeField] Transform _shootPoint;
        [SerializeField] PlayerMovementBehaviour _playerMovementBehaviour;
        [SerializeField] PlayerWeapon playerWeapon;
        [SerializeField] MeshRenderer _gunRenderer;

        private float _finalShootVelocity;

        void Start()
        {
            SwitchWeapon(new BulletWeaponBehaviour(this));
        }

        public override void Interact()
        {
            if (_inputType == Input.Primary && PlayerInput.Instance.primaryShootPressed || _inputType == Input.Secondary && PlayerInput.Instance.secondaryShootPressed)
            {
                Shoot();
            }

            if (PlayerInput.Instance.alpha1Pressed)
            {
                SwitchWeapon(new BulletWeaponBehaviour(this));
            }
            if (PlayerInput.Instance.alpha2Pressed)
            {
                SwitchWeapon(new RocketWeaponBehaviour(this));
            }
        }

        void Shoot()
        {
            _finalShootVelocity = _playerMovementBehaviour.GetForwardSpeed() + _shootVelocity;
            _currentShootStrategy.FireWeapon();
        }

        public Transform GetShootPoint()
        {
            return _shootPoint;
        }

        public float GetShootVelocity()
        {
            return _shootVelocity;
        }

        public MeshRenderer GetWeaponRenderer()
        {
            return _gunRenderer;
        }

        public void SwitchWeapon(IWeaponBehaviour newWeapon)
        {
            _currentShootStrategy = newWeapon;
            Debug.Log("Switched weapon behaviour to: " + newWeapon.GetType().ToString());
        }
    }

    public enum Input
    {
        Primary,
        Secondary
    }
}
