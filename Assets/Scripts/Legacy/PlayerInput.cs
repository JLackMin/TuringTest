using UnityEngine;
using UnityEngine.InputSystem;

namespace Midterm
{
    [DefaultExecutionOrder(-100)]

    public class PlayerInput : MonoBehaviour
    {
        public float horizontalInput {get; private set;}
        public float verticalInput {get; private set;}
        public float mouseX {get; private set;}
        public float mouseY {get; private set;}

        public bool sprintHeld {get; private set;}
        public bool jumpPressed {get; private set;}
        public bool activatePressed {get; private set;}
        public bool primaryShootPressed {get; private set;}
        public bool secondaryShootPressed {get; private set;}

        [Header("InputActions")]
        [SerializeField] InputActionReference moveAction;
        [SerializeField] InputActionReference lookAction;
        [SerializeField] InputActionReference sprintAction;
        [SerializeField] InputActionReference jumpAction;
        [SerializeField] InputActionReference activateAction;
        [SerializeField] InputActionReference primaryShootAction;
        [SerializeField] InputActionReference secondaryShootAction;

        private bool clear;

        private void OnEnable()
        {
            moveAction.action.Enable();
            lookAction.action.Enable();
            sprintAction.action.Enable();
            jumpAction.action.Enable();
            activateAction.action.Enable();
            primaryShootAction.action.Enable();
            secondaryShootAction.action.Enable();
        }

        private void OnDisable()
        {
            moveAction.action.Disable();
            lookAction.action.Disable();
            sprintAction.action.Disable();
            jumpAction.action.Disable();
            activateAction.action.Disable();
            primaryShootAction.action.Disable();
            secondaryShootAction.action.Disable();
        }

        private void Update()
        {
            ClearInputs();
            ProcessInputs();
        }

        private void LateUpdate()
        {
            clear = true;
        }

        private void ProcessInputs()
        {
            Vector2 move = moveAction.action.ReadValue<Vector2>();
            Vector2 look = lookAction.action.ReadValue<Vector2>();

            horizontalInput = move.x;
            verticalInput = move.y;

            mouseX = look.x;
            mouseY = look.y;

            sprintHeld = sprintAction.action.IsPressed();

            jumpPressed |= jumpAction.action.WasPressedThisFrame();
            activatePressed |= activateAction.action.WasPressedThisFrame();

            primaryShootPressed |= primaryShootAction.action.WasPressedThisFrame();
            secondaryShootPressed |= secondaryShootAction.action.WasPressedThisFrame();
        }

        private void ClearInputs()
        {
            if (!clear)
            {
                return;
            }
            horizontalInput = 0;
            verticalInput = 0;
            mouseX = 0;
            mouseY = 0;

            sprintHeld = false;
            jumpPressed = false;
            activatePressed = false;

            primaryShootPressed = false;
            secondaryShootPressed = false;

            clear = false;
        }
    }
}
