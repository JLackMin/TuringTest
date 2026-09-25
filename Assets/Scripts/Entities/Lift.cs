using System;
using UnityEngine;

namespace Midterm
{
    public class Lift : MonoBehaviour
    {
        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Invoke("LiftAnimation",1f);
            }
        }

        void LiftAnimation()
        {
            Debug.Log("Playing animation.");
            Animator animator = GetComponent<Animator>();
            animator.Play("Lift_Room2",0,Math.Clamp(animator.GetCurrentAnimatorStateInfo(0).normalizedTime,0f,1f));
            animator.SetFloat("Speed",1f);

        }
    }
}
