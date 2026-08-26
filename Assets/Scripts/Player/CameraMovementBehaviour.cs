using Unity.VisualScripting;
using UnityEngine;

namespace Midterm
{
    [RequireComponent(typeof(Camera))]
    public class CameraMovementBehaviour : MonoBehaviour
    {
        [SerializeField] private PlayerInput _input;

        [Header("Player Turn")]
        [SerializeField] private float _turnSpeed;
        [SerializeField] private bool _invertedMouse;

        private float _camXRotation;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        // Update is called once per frame
        void Update()
        {
            RotateCamera();
        }

        void RotateCamera()
        {
            _camXRotation += Time.deltaTime * _input.mouseY * _turnSpeed * (_invertedMouse ? 1:-1);
            _camXRotation = Mathf.Clamp(_camXRotation,-85f,85f);

            transform.localRotation = Quaternion.Euler(_camXRotation,0,0);
        }
    }
}
