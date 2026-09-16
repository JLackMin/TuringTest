using UnityEngine;

namespace Midterm
{
    public class LevelTransition : MonoBehaviour
    {
        [SerializeField] string nextLevelName;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Debug.Log("Player has entered the level transition");
                GameManager.instance.ChangeState(GameManager.GameState.LevelStart);
                
                //Any other behaviour we need for this level transition
                
                Debug.Log("Loading Level: " + nextLevelName);
                gameObject.SetActive(false);
            }
        }
    }
}
