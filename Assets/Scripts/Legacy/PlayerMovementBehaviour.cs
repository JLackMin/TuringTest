using Unity.Hierarchy.Editor;
using Unity.VisualScripting;
using UnityEngine;

namespace Midterm
{
    [RequireComponent(typeof(CharacterController))]

    public class PlayerMovementBehaviour : MonoBehaviour
    {
        [SerializeField] private PlayerInput _input;

        [Header("PlayerMovement")]
        [SerializeField] private float _moveSpeed = 5f;
        [SerializeField] private float _gravity = -9.81f;
        [SerializeField] private float _sprintMultiplier = 1.5f;

        [Header("Ground Check")]
        [SerializeField] private Transform _groundCheck;
        [SerializeField] private LayerMask _groundMask;
        [SerializeField] private float _groundCheckDistance = 0.2f;

        private CharacterController _characterController;
        private Vector3 _playerVelocity;

        public bool isGrounded {get; private set;}

        private float _moveMultiplier = 1f;

        void Start()
        {
            _characterController = GetComponent<CharacterController>();
        }

        void Update()
        {
            GroundCheck();
            MovePlayer();
        }

        private void MovePlayer()
        {
            //sprint
            _moveMultiplier = _input.sprintHeld ? _sprintMultiplier : 1f;

            //movement
            Vector3 move = transform.forward * _input.verticalInput + transform.right * _input.horizontalInput;

            _characterController.Move(move * _moveSpeed * _moveMultiplier * Time.deltaTime);

            //keep Player grounded
            if (isGrounded && _playerVelocity.y < 0)
            {
                _playerVelocity.y = -2f;
            }

            //gravity
            _playerVelocity.y += _gravity * Time.deltaTime;

            //vertical movement
            _characterController.Move(_playerVelocity * Time.deltaTime);
        }

        private void GroundCheck()
        {
            isGrounded = Physics.CheckSphere(_groundCheck.position,_groundCheckDistance,_groundMask);
        }

        public void SetYVelocity(float value)
        {
            _playerVelocity.y = value;
        }

        public float GetForwardSpeed()
        {
            return _input.verticalInput * _moveSpeed * _moveMultiplier;
        }
    }
}
