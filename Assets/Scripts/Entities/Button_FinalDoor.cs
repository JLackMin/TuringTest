using System;
using UnityEngine;
using UnityEngine.Events;

namespace Midterm
{
    public class Button_FinalDoor : MonoBehaviour, ISelectable
    {
        public UnityEvent onSelect;
        [SerializeField] Animator animator;

        public void OnHoverEnter()
        {
            return;
        }

        public void OnHoverExit()
        {
            return;
        }

        public void OnSelect()
        {
            onSelect?.Invoke();
            animator.Play("OpenClose",0,Math.Clamp(animator.GetCurrentAnimatorStateInfo(0).normalizedTime,0f,1f));
            animator.SetFloat("Speed",1f);
        }
    }
}
