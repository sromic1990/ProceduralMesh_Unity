using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Sourav.Utilities.Scripts
{
    /// <summary>
    /// Pool Utility for Gameobject or components of a gameobject.
    /// </summary>
	public class ObjectPool<T> : MonoBehaviour where T : MonoBehaviour 
	{
		private readonly List<T> _pool;
        private int amount;
        private readonly bool canGrow;
        private readonly int growthAmount;

        [HideInInspector]
        public readonly GameObject Holder;
        readonly GameObject objectToPool;
		
        /// <summary>
        /// <para>Initializes a new instance of the <see cref="T:Sourav.Utilities.Scripts.ObjectPool"/> class.</para>
        /// <para>Enter name of the Holder Gameobject in the inspector.</para>
        /// <para>Enter the GameObject that needs to be pooled containing the pooled Component.</para>
        /// <para>Enter the Amount of pooled objects you require.</para>
        /// <para>Can your pool grow dynamically?</para>
        /// <para>If your pool can grow, what amount of addition do you require per growth?</para>
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="obj">Object.</param>
        /// <param name="amount">Amount.</param>
        /// <param name="canGrow">If set to <c>true</c> can grow.</param>
        /// <param name="growthAmount">Growth amount.</param>
		public ObjectPool(string name, GameObject obj, int amount, bool canGrow = false, int growthAmount = 5)
		{
            //Initialize fields and member variables
            this.amount = amount;
            this.canGrow = canGrow;
            this.growthAmount = growthAmount;
            this.objectToPool = obj;

            //Initialize pool list
            _pool = new List<T>();
            Holder = new GameObject(name);

            AddObjectsToPool(amount);
		}
		
		public T GetPooledObject()
		{
			T t = null;
            bool found = false;
			
			for (int i = 0; i < _pool.Count; i++)
			{
				if(!_pool[i].gameObject.activeSelf)
				{
					t = _pool[i];
                    found = true;
					break;
				}
			}

            if (!found)
            {
				t = GrowPool();
            }
            return t;
		}
		
        public void AffectAllPooledObjects(string function)
        {
            for (int i = 0; i < _pool.Count; i++)
            {
                _pool[i].SendMessage(function, SendMessageOptions.DontRequireReceiver);
            }
        }

        public void AffectAllPooledObjects(string function, object[] param)
        {
            for (int i = 0; i < _pool.Count; i++)
            {
                _pool[i].SendMessage(function, param, SendMessageOptions.DontRequireReceiver);
            }
        }

		public void ReturnPooledObject(T obj)
		{
			obj.gameObject.SetActive(false);
            obj.transform.parent = Holder.transform;
            obj.transform.position = Vector3.zero;
		}

        public void ReturnAllPooledObjects()
        {
            for (int i = 0; i < _pool.Count; i++)
            {
                ReturnPooledObject(_pool[i]);
            }
        }

        public int GetCurrentPoolCount()
        {
            return amount;
        }

        public int GetCurrentActiveCount()
        {
            int currentActive = 0;

            for (int i = 0; i < _pool.Count; i++)
            {
                if(_pool[i].gameObject.activeSelf)
                {
                    currentActive++;
                }
            }

            return currentActive;
        }

        public List<T> GetAllActiveObjects()
        {
            List<T> allActiveObjects = new List<T>();

            for (int i = 0; i < _pool.Count; i++)
            {
                if(_pool[i].gameObject.activeSelf)
                {
                    allActiveObjects.Add(_pool[i]);
                }
            }

            return allActiveObjects;
        }

        //TODO return an exact number of pooled object as per asked
        public List<T> GetExactNumberOfPooledObjects(int number)
        {
            List<T> pooledList = new List<T>();

            for (int i = 0; i < number; i++)
            {
                
            }

            return pooledList;
        }

        public T GrowPool()
        {
            if (!canGrow)
                return null;

            AddObjectsToPool(growthAmount);
            T t = _pool[amount-1];

            this.amount += growthAmount;

            return t;
        }

        private void AddObjectsToPool(int amount)
        {

            for (int i = 1; i <= amount; i++)
            {
                GameObject pooledObject = (GameObject)Instantiate(objectToPool, Vector3.zero, Quaternion.identity);
                pooledObject.transform.parent = Holder.transform;
                pooledObject.SetActive(false);
                if (pooledObject.GetComponent<T>() != null)
                {
                    _pool.Add(pooledObject.GetComponent<T>());
                }
                else
                {
                    Debug.LogError("Object does not contain component");
                }
            }
        }

        //TODO Find a particular object according to given specs from _pool.
	}
}

