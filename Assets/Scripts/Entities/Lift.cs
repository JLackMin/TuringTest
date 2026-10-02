using System;
using UnityEngine;

namespace Midterm
{
    public class Lift : MonoBehaviour, ISelectable
    {
        [SerializeField] GameObject player;
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
            player.transform.SetParent(transform);
            Invoke("LiftAnimation",1f);
        }

        void LiftAnimation()
        {
            Debug.Log("Playing animation.");
            Animator animator = GetComponent<Animator>();
            animator.Play("Lift",0,Math.Clamp(animator.GetCurrentAnimatorStateInfo(0).normalizedTime,0f,1f));
            animator.SetFloat("Speed",1f);
        }
    }
}
