using UnityEngine;

namespace Midterm
{
    public class PooledObject : MonoBehaviour
    {
        //Reference to object pool that created this object
        ObjectPool poolReference;

        public void SetObjectPool(ObjectPool _pool)
        {
            //Sets the reference to the object pool
            poolReference = _pool;
        }

        public void DestroyWithTime(float time)
        {
            //Calls our reset object method after certain amount of time
            Invoke("ResetObject",time);
        }

        public void ResetObject()
        {
            //Returns object to available pool and sets it inactive
            poolReference.RestoreObject(this);
        }
    }
}
