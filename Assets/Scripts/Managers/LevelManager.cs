using UnityEngine;
using UnityEngine.Events;

namespace Midterm
{
    public class LevelManager : MonoBehaviour
    {
        public UnityEvent OnLevelStart;
        public UnityEvent OnLevelEnd;

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
