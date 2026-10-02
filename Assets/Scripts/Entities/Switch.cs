using System;
using UnityEngine;
using UnityEngine.Events;

namespace Midterm
{
    public class Switch : MonoBehaviour, ISelectable
    {
        [SerializeField] private Material _default;
        [SerializeField] private Material _hoverColour;
        [SerializeField] private MeshRenderer _renderer;
        [SerializeField] private GameObject door;

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
            Animator animator = door.GetComponent<Animator>();
            Debug.Log(GameManager.instance.GetHasKeycard());

            if (GameManager.instance.GetHasKeycard())
            {
                _onPush?.Invoke();
                animator.Play("OpenClose",0,Math.Clamp(animator.GetCurrentAnimatorStateInfo(0).normalizedTime,0f,1f));
                animator.SetFloat("Speed",1f);
            }
        }
    }
}
