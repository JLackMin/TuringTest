using System;
using System.Collections;
using Unity.Cinemachine;
using UnityEngine;
using UnityEditor;

namespace Midterm
{
    public class PlayCinematic : MonoBehaviour
    {
        [SerializeField] Animator animator;
        [SerializeField] Camera camera;
        [SerializeField] CinemachineCamera cinCam;
        [SerializeField] GameObject canvas;
        [SerializeField] GameObject levelCanvas;
        [SerializeField] GameObject blaster;
        public IEnumerator Play(float time)
        {
            blaster.SetActive(false);
            cinCam.gameObject.SetActive(true);
            canvas.SetActive(false);

            if (CompareTag("LevelStart") || CompareTag("LevelEnd"))
            {
                levelCanvas.SetActive(true);
            }

            animator.Play("Cinematic",0,Math.Clamp(animator.GetCurrentAnimatorStateInfo(0).normalizedTime,0f,1f));
            animator.SetFloat("Speed",1f);
            yield return new WaitForSeconds(time);

            if (CompareTag("Player"))
            {
                Application.Quit();

                #if UNITY_EDITOR
                    EditorApplication.isPlaying = false;
                #endif
            }

            blaster.SetActive(true);
            cinCam.gameObject.SetActive(false);
            canvas.SetActive(true);

            if (CompareTag("LevelStart") || CompareTag("LevelEnd"))
            {
                levelCanvas.SetActive(false);
            }

            gameObject.SetActive(false);
            camera.transform.SetLocalPositionAndRotation(new Vector3(0,0,0),Quaternion.identity);
            GameManager.instance.ChangeState(GameManager.GameState.GamePlaying);
        
            LevelTransition level = GetComponent<LevelTransition>();
            
            if (level != null)
            {
                if (level.currentLevelName.Equals("Level 5") && CompareTag("LevelEnd"))
                {
                    Application.Quit();

                    #if UNITY_EDITOR
                        EditorApplication.isPlaying = false;
                    #endif
                } 

            }
        }
    }
}
