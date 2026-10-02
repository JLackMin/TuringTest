using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;

namespace Midterm
{
    public class LevelManager : MonoBehaviour
    {
        public UnityEvent OnLevelStart;
        public UnityEvent OnLevelEnd;
        public PlayableDirector cinematic;

        public void LevelStart()
        {
            OnLevelStart?.Invoke();
        }

        public void LevelEnd()
        {
            OnLevelEnd?.Invoke();
        }
    }
}
