using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public GameObject[] prefabToSpawn;
    public int poolSize = 15;
    private List<GameObject> poolObj;
    private void Start()
    {
        
        poolObj = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            int number = i % prefabToSpawn.Length;
            GameObject obj = Instantiate(prefabToSpawn[number]);
            obj.SetActive(false);
            poolObj.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        foreach (GameObject obj in poolObj)
        {
            if (!obj.activeInHierarchy)
            {
                return obj;
            }
        }
        // chua co sinh them
        GameObject newObj = Instantiate(prefabToSpawn[Random.Range(0, prefabToSpawn.Length)]);
        newObj.SetActive(false);
        poolObj.Add(newObj);
        return newObj;
    }
    public GameObject SpawnFromPool(Vector3 position, Quaternion rotation, Transform parent)
    {
        GameObject obj = GetPooledObject();
        if (obj != null)
        {
            obj.SetActive(true);
            obj.transform.position = position;
            obj.transform.rotation = rotation;
            obj.transform.parent = parent;
        }
        return obj;
    }
}
