using UnityEngine;
using System;

namespace Midterm
{
    public class Door_Level3 : MonoBehaviour
    {
        Animator animator;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        public void Animate()
        {
            animator.Play("OpenClose",0,Math.Clamp(animator.GetCurrentAnimatorStateInfo(0).normalizedTime,0f,1f));
            animator.SetFloat("Speed",1f);
        }
    }
}
