using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Midterm
{
    public class PlayerController : MonoBehaviour
    {
        [Header("PlayerMovement")]
        [SerializeField] float _moveSpeed = 5f;
        [SerializeField] float _turnSpeed = 10f;
        [SerializeField] Transform _cameraTransform;
        [SerializeField] bool _invertMouse;
        [SerializeField] float _gravity = -9.81f;
        [SerializeField] float _jumpVelocity = 5f;
        [SerializeField] float _sprintMultiplier = 2f;

        [Header("GroundChecks")]
        [SerializeField] Transform _groundCheck;
        [SerializeField] LayerMask _groundLayer;
        [SerializeField] float _groundCheckDistance;

        [Header("Shoot")]
        [SerializeField] Rigidbody _bulletPrefab;
        [SerializeField] float _shootForce;
        [SerializeField] Transform _shootPoint;

        //inputs
        Vector2 _moveInput;
        Vector2 _lookInput;
        float _camXrotation;
        bool _sprinting;
        bool _sprintPressed;
        bool _jumpPressed;
        bool _shootPressed;
        
        CharacterController _characterController;

        Vector3 _playerVelocity;
        bool _isGrounded;
        float _moveMultiplier = 1f;

        #region InputCallbacks

        public void OnMove(InputValue value)
        {
            _moveInput = value.Get<Vector2>();
        }

        public void OnLook(InputValue value)
        {
            _lookInput = value.Get<Vector2>();
        }

        public void OnSprint(InputValue value)
        {
            _sprintPressed = value.isPressed;
        }

        public void OnJump(InputValue value)
        {
            if (value.isPressed)
            {
                _jumpPressed = true;
            }
        }

        public void OnShoot(InputValue value)
        {
            if (value.isPressed)
            {
                _shootPressed = true;
            }
        }

        #endregion

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            _characterController = GetComponent<CharacterController>();

            CursorSetup();
        }

        void CursorSetup()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        // Update is called once per frame
        void Update()
        {
            RotatePlayer();
            GroundCheck();
            MovePlayer();

            if (_jumpPressed)
            {
                JumpCheck();
                _jumpPressed = false;
            }

            if (_shootPressed)
            {
                ShootBullet();
                _shootPressed = false;
            }
        }

        void RotatePlayer()
        {
            transform.Rotate(Vector3.up * _lookInput.x * _turnSpeed * Time.deltaTime);
            _camXrotation += _lookInput.y * _turnSpeed * Time.deltaTime * (_invertMouse? 1:-1);
            _camXrotation = Mathf.Clamp(_camXrotation,-85f,85);
            _cameraTransform.localRotation = Quaternion.Euler(_camXrotation,0,0);
        }

        void MovePlayer()
        {

            _moveMultiplier = _sprintPressed? _sprintMultiplier:1f; //If sprinting, give it the multiplier, if not, normal speed

            Vector3 move = transform.forward * _moveInput.y + transform.right * _moveInput.x;
            
            //forwards/backwards movement + left/right movement
            _characterController.Move(move * _moveSpeed * _moveMultiplier * Time.deltaTime);

            if (_isGrounded && _playerVelocity.y < 0)
            {
                _playerVelocity.y = -2f;
            }

            //gravity - No rigidbody on Character Controller, need to do gravity manually (Character Controller works well with slopes)
            _playerVelocity.y += _gravity * Time.deltaTime;

            _characterController.Move(_playerVelocity * Time.deltaTime);
        }

        void GroundCheck()
        {
            _isGrounded = Physics.CheckSphere(_groundCheck.position,_groundCheckDistance,_groundLayer);
        }

        void JumpCheck()
        {
            if (_isGrounded)
            {
                _playerVelocity.y = _jumpVelocity;
            }
        }

        void ShootBullet()
        {
            Rigidbody bullet = Instantiate(_bulletPrefab,_shootPoint.position,_shootPoint.rotation);
            bullet.AddForce(_shootPoint.forward * _shootForce,ForceMode.Impulse);
            Destroy(bullet.gameObject,5f); //later to be removed for object pooling
        }
    }
}