using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public GameObject pooledObject;

    public int pooledAmount;

    List<GameObject> pooledObjects;

    // Start is called before the first frame update
    void Start()
    {
        pooledObjects = new List<GameObject>();

        for (int i = 0; i < pooledAmount; i++) // Create new int "i", when I < pooled amount run, After running add 1 to "i"
        {
            GameObject obj = (GameObject)Instantiate(pooledObject); // Uses casting
            obj.SetActive(false);
            pooledObjects.Add(obj); // Adding object to pooled Object List
        }
    }

    public GameObject GetPooledObject() 
    {
        for(int i = 0; i < pooledObjects.Count; i++)
        {
            if(!pooledObjects[i].activeInHierarchy) // go to position 0 in list
            {
                return pooledObjects[i];
            }
        }

        GameObject obj = (GameObject)Instantiate(pooledObject); // Uses casting
        obj.SetActive(false);
        pooledObjects.Add(obj); // Adding object to pooled Object List

        return obj;
    }
}