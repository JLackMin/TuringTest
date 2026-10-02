using System;
using UnityEngine;

namespace Midterm
{
    public class Button_FinalDoor : MonoBehaviour, ISelectable
    {
        [SerializeField] private Material _default;
        [SerializeField] private Material _hoverColour;
        [SerializeField] private MeshRenderer _renderer;
        [SerializeField] Animator animator;

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
            animator.Play("OpenClose",0,Math.Clamp(animator.GetCurrentAnimatorStateInfo(0).normalizedTime,0f,1f));
            animator.SetFloat("Speed",1f);
        }
    }
}
