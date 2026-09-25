using TMPro;
using UnityEngine;
using UnityEngine.Playables;

namespace Midterm
{
    public class LevelTransition : MonoBehaviour
    {
        [SerializeField] string currentLevelName;
        [SerializeField] TextMeshProUGUI levelText;
        public PlayableDirector director;
        public LevelManager manager;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                GameManager.instance.currentLevel = manager;

                director.Play();

                Debug.Log("Player has entered the level transition");
                
                //Any other behaviour we need for this level transition

                if (CompareTag("LevelStart"))
                {
                    GameManager.instance.ChangeState(GameManager.GameState.LevelStart);
                    levelText.text = currentLevelName;
                    levelText.canvasRenderer.SetColor(Color.red);
                    levelText.transform.Translate(50,0,0);
                }
                else if (CompareTag("LevelEnd"))
                {
                    GameManager.instance.ChangeState(GameManager.GameState.LevelEnd);
                    levelText.text = currentLevelName + " Complete!";
                    levelText.canvasRenderer.SetColor(Color.green);
                    levelText.transform.Translate(-50,0,0);
                }
            }
        }
    }
}
