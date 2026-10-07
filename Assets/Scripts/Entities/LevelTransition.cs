using System;
using TMPro;
using UnityEngine;

namespace Midterm
{
    public class LevelTransition : MonoBehaviour
    {
        public string currentLevelName;
        [SerializeField] TextMeshProUGUI levelText;
        [SerializeField] TextMeshProUGUI levelCompleteText;
        public LevelManager manager;

        private void OnTriggerEnter(Collider other)
        {
            GameManager.instance.currentLevel = manager;

            if (other.CompareTag("Player"))
            {
                if (CompareTag("LevelStart"))
                {
                    GameManager.instance.ChangeState(GameManager.GameState.LevelStart);
                    levelText.gameObject.SetActive(true);
                    levelCompleteText.gameObject.SetActive(false);
                    levelText.text = currentLevelName;
                    levelText.canvasRenderer.SetColor(Color.red);
                }
                else if (CompareTag("LevelEnd"))
                {
                    GameManager.instance.ChangeState(GameManager.GameState.LevelEnd);
                    levelText.gameObject.SetActive(false);
                    levelCompleteText.gameObject.SetActive(true);
                    levelCompleteText.text = currentLevelName + " Complete!";
                    levelCompleteText.canvasRenderer.SetColor(Color.green);
                }

                if (currentLevelName.Equals("Level 1"))
                {
                    manager.cinematic.Play();                    
                }
                else
                {
                    PlayCinematic cinematic = GetComponent<PlayCinematic>();
                    StartCoroutine(cinematic.Play(5f));
                }           
            }
        }
    }
}
