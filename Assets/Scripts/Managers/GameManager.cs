using System.Collections;
using UnityEngine;

namespace Midterm
{
    public class GameManager : MonoBehaviour
    {
        public enum GameState
        {
            Paused,
            GameIntro,
            GameStart,
            GamePlaying,
            GameOver,
            GameEnd,
            LevelStart,
            LevelEnd
        }

        public GameState currentGameState = GameState.GameIntro;

        public static GameManager instance = null;

        void Awake()
        {
            // Singleton pattern
            if (instance != null)
            {
                Destroy(this.gameObject);
            }
            else
            {
                instance = this;
            }
        }
        
        void Start()
        {
            ChangeState(GameState.GameStart);
        }

        void Update()
        {
            if (PlayerInput.Instance.escapePressed)
            {
                if (currentGameState == GameState.Paused)
                {
                    ChangeState(GameState.GamePlaying);
                }
                else if (currentGameState == GameState.GamePlaying)
                {
                    ChangeState(GameState.Paused);
                }
            }
        }
        
        public void ChangeState(GameState newState)
        {
            currentGameState = newState;

            switch (newState)
            {
                case GameState.GameIntro:
                    OnGameIntro();
                    break;
                case GameState.GameStart:
                    OnGameStart();
                    break;
                case GameState.GamePlaying:
                    OnGamePlaying();
                    break;
                case GameState.GameOver:
                    OnGameOver();
                    break;
                case GameState.GameEnd:
                    OnGameEnd();
                    break;
                case GameState.LevelStart:
                    OnLevelStart();
                    break;
                case GameState.LevelEnd:
                    OnLevelEnd();
                    break;
                case GameState.Paused:
                    OnGamePaused();
                    break;
            }
        }

        void OnGameIntro()
        {
            Debug.Log("Game intro state.");
        }
        
        void OnGameStart()
        {
            Debug.Log("Game start state.");

            //Initialize whatever I need to make game playable

            ChangeState(GameState.GamePlaying);
        }

        void OnGamePlaying()
        {
            Debug.Log("Game playing.");

            Time.timeScale = 1f;
        }

        private IEnumerator ChangeStateDelay(GameState newState, float delayTime)
        {
            yield return new WaitForSeconds(delayTime);
            ChangeState(newState);
        }

        void OnGameEnd()
        {
            Debug.Log("Game end state.");

            //Logic pertaining to overacrhing game experience
            //Calculating a score, determining if player won or last the game
            //Figuring out the next level
        }

        void OnGameOver()
        {
            Debug.Log("Game over state.");

            //Handles logic when player loses / dies
        }

        void OnLevelStart()
        {
            Debug.Log("Level start state.");

            //Start cinematics / instructions / tutorial

            StartCoroutine(ChangeStateDelay(GameState.GamePlaying,2f));
        }

        void OnLevelEnd()
        {
            Debug.Log("Level end state.");

            //When we finish a level / trigger level-ending cut scene
        }

        void OnGamePaused()
        {
            Debug.Log("Game paused.");

            Time.timeScale = 0f;
        }
    }
}
