using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Sourav.Utilities.Scripts
{
    public class CheckGameObjectsPresetInScene<T> where T : class
    {
        public GameObjectSerachResult CheckForGameObject()
        {
            GameObjectSerachResult result = new GameObjectSerachResult();

            var activeScene = SceneManager.GetActiveScene();
            foreach(var rootGameObject in activeScene.GetRootGameObjects())
            {
                if(rootGameObject.GetComponent<T>() != null || rootGameObject.GetComponentInChildren<T>() != null)
                {
                    if(rootGameObject.GetComponent<T>() != null)
                    {
                        result.foundGameObjects.Add(rootGameObject);
                        result.numberOfObjects++;
                    }
                    else
                    {
                        for (int i = 0; i < rootGameObject.transform.childCount; i++)
                        {
                            if(rootGameObject.transform.GetChild(i).GetComponent<T>() != null)
                            {
                                result.foundGameObjects.Add(rootGameObject.transform.GetChild(i).gameObject);
                                result.numberOfObjects++;
                            }
                        }
                    }
                }
            }

            return result;
        }
    }

    public class GameObjectSerachResult
    {
        public List<GameObject> foundGameObjects;
        public int numberOfObjects;

        public GameObjectSerachResult()
        {
            foundGameObjects = new List<GameObject>();
            numberOfObjects = 0;
        }
    }
    
}