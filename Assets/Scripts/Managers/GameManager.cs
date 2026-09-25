using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

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
        private bool hasKeycard;

        public Camera mainCamera;
        public PlayableDirector sampleDirector;

        //Level managers
        public LevelManager currentLevel;

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
            currentLevel.LevelStart();
        }

        void OnLevelEnd()
        {
            Debug.Log("Level end state.");

            //When we finish a level / trigger level-ending cut scene
            currentLevel.LevelEnd();
        }

        void OnGamePaused()
        {
            Debug.Log("Game paused.");
            Time.timeScale = 0f;
        }

        public void CinematicStarted()
        {
            ChangeState(GameState.LevelStart);
        }

        public void CinematicEnded()
        {
            mainCamera.transform.localPosition = Vector3.zero;
            ChangeState(GameState.GamePlaying);
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

        public void SetHasKeycard(bool value)
        {
            hasKeycard = value;
        }

        public bool GetHasKeycard()
        {
            return hasKeycard;
        }
    }
}
