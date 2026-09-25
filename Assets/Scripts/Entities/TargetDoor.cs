using System;
using UnityEngine;

namespace Midterm
{
    public class TargetDoor : MonoBehaviour
    {
        [SerializeField] Target[] targets;

        public void CheckDoor()
        {
            foreach (Target target in targets)
            {
                if (!target.isHit)
                {
                    return;
                }
            }

            OpenDoor();
        }

        void OpenDoor()
        {
            Animator animator = GetComponent<Animator>();
            animator.Play("OpenClose",0,Math.Clamp(animator.GetCurrentAnimatorStateInfo(0).normalizedTime,0f,1f));
            animator.SetFloat("Speed",1f);
        }

    }
}
