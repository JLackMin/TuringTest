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

        [SerializeField] int numberOfObjects = 15;

        public GameObject bullet;
        public GameObject rocket;
        public GameObject laser;

        private int bulletCount;
        private int rocketCount;
        private int laserCount;

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
                if (i < numberOfObjects / 3)
                {
                    AddNewObject(bullet);
                    bulletCount += 1;
                }
                else if (i < 2 * numberOfObjects / 3)
                {
                    AddNewObject(rocket);
                    rocketCount += 1;
                }
                else if (i < numberOfObjects)
                {
                    AddNewObject(laser);
                    laserCount += 1;
                }
            }
        }

        public void AddNewObject(GameObject objectToCreate)
        {
            GameObject newObject = Instantiate(objectToCreate,transform.position,Quaternion.identity);
            
            //Set object pool reference so it can return itself when destroyed
            newObject.GetComponent<PooledObject>().SetObjectPool(this);
            newObject.SetActive(false);
            objectPool.Add(newObject.GetComponent<PooledObject>());
        }

        public PooledObject GetPooledBullet()
        {
            if (bulletCount > 0)
            {
                //Grab first available object from the pool, add it to used pool
                usedPool.Add(objectPool[0]);

                //Remove object from availability pool
                objectPool.RemoveAt(0);
                bulletCount -= 1;

                //Activate object and return it to the caller
                usedPool[usedPool.Count - 1].gameObject.SetActive(true);
                return usedPool[usedPool.Count - 1];
            }
            else
            {
                Debug.Log("No pooled bullet.");
                return null;
            }
        }

        public PooledObject GetPooledRocket()
        {
            if (rocketCount > 0)
            {
                //Grab first available object from the pool, add it to used pool
                usedPool.Add(objectPool[numberOfObjects/3]);

                //Remove object from availability pool
                objectPool.RemoveAt(numberOfObjects/3);
                rocketCount -= 1;

                //Activate object and return it to the caller
                usedPool[usedPool.Count - 1].gameObject.SetActive(true);
                return usedPool[usedPool.Count - 1];
            }
            else
            {
                Debug.Log("No pooled rocket.");
                return null;
            }
        }

        public PooledObject GetPooledLaser()
        {
            if (laserCount > 0)
            {
                //Grab first available object from the pool, add it to used pool
                usedPool.Add(objectPool[2*numberOfObjects/3]);

                //Remove object from availability pool
                objectPool.RemoveAt(2*numberOfObjects/3);
                laserCount -= 1;

                //Activate object and return it to the caller
                usedPool[usedPool.Count - 1].gameObject.SetActive(true);
                return usedPool[usedPool.Count - 1];
            }
            else
            {
                Debug.Log("No pooled laser.");
                return null;
            }
        }

        public void RestoreObject(PooledObject _pooledObject)
        {
            if (usedPool.Count > 0)
            {
                _pooledObject.transform.rotation = Quaternion.identity;
                
                if (_pooledObject.gameObject.CompareTag("Bullet"))
                {
                    bulletCount += 1;
                    objectPool.Insert(0,_pooledObject);
                }
                else if (_pooledObject.gameObject.CompareTag("Rocket"))
                {
                    rocketCount += 1;
                    objectPool.Insert(numberOfObjects/3,_pooledObject);
                }
                else
                {
                    laserCount += 1;
                    objectPool.Insert(2*numberOfObjects/3,_pooledObject);
                }
                

                //Remove object from used pool
                usedPool.Remove(_pooledObject);

                //Set object back to inactive
                _pooledObject.gameObject.SetActive(false);
            }
            else
            {
                Debug.Log("No used object.");
            }

            FixPoolSize(objectPool);
        }

        void FixPoolSize(List<PooledObject> pool)
        {
            if (bulletCount > numberOfObjects/3)
            {
                pool.RemoveAt(0);
                bulletCount -= 1;
            }
            if (rocketCount > numberOfObjects/3)
            {
                pool.RemoveAt(bulletCount);
                rocketCount -= 1;
            }
            if (laserCount > numberOfObjects / 3)
            {
                pool.RemoveAt(bulletCount+rocketCount);
                laserCount -= 1;
            }
        }
    }
}
