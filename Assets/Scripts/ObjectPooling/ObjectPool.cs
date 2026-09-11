using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Midterm
{
    public class ObjectPool : MonoBehaviour
    {
        public static ObjectPool Instance;

        //Two lists for object pooling: one in use, one available
        public List<PooledObject> objectPool = new List<PooledObject>();
        public List<PooledObject> usedPool = new List<PooledObject>();

        [SerializeField] int numberOfObjects = 5;

        public GameObject objectToCreate;

        void Awake()
        {
            if (Instance != null)
            {
                Destroy(this.gameObject);
            }
            else if (Instance == null)
            {
                Instance = this;
            }

            Initialize();
        }

        public void Initialize()
        {
            for (int i = 0; i < numberOfObjects; i++)
            {
                AddNewObject();
            }
        }

        public void AddNewObject()
        {
            GameObject newObject = Instantiate(objectToCreate,transform.position,Quaternion.identity);
            
            //Set object pool reference so it can return itself when destroyed
            newObject.GetComponent<PooledObject>().SetObjectPool(this);
            newObject.SetActive(false);
            objectPool.Add(newObject.GetComponent<PooledObject>());
        }

        public PooledObject GetPooledObject()
        {
            if (objectPool.Count > 0)
            {
                //Grab first available object from the pool, add it to used pool
                usedPool.Add(objectPool[0]);

                //Remove object from availability pool
                objectPool.RemoveAt(0);

                //Activate object and return it to the caller
                usedPool[usedPool.Count - 1].gameObject.SetActive(true);
                return usedPool[usedPool.Count - 1];
            }
            else
            {
                Debug.Log("No pooled object.");
                return null;
            }
        }

        public void RestoreObject(PooledObject _pooledObject)
        {
            if (usedPool.Count > 0)
            {
                //Return object to available pool
                objectPool.Add(_pooledObject);

                //Remove object from used pool
                usedPool.Remove(_pooledObject);

                //Set object back to inactive
                _pooledObject.gameObject.SetActive(false);
            }
            else
            {
                Debug.Log("No used object.");
            }
        }
    }
}
