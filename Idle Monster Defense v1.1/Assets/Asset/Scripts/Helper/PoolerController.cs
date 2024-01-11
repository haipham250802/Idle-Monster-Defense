using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class PoolerController : SerializedMonoBehaviour
{
    public static PoolerController Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            DestroyImmediate(Instance);

    }
    public class Pool
    {
        public List<PoolObject> activeList = new List<PoolObject>();
        public List<PoolObject> deactiveList = new List<PoolObject>();
        public string poolingKey;
    }
    public Dictionary<string, Pool> poolingDict;


    public void Init()
    {
        poolingDict ??= new Dictionary<string, Pool>();
    }

    public void CleanDict()
    {
        foreach (var data in poolingDict)
        {
            data.Value.activeList.Clear();
            data.Value.deactiveList.Clear();
        }
    }

    public PoolObject Spawn(PoolObject refPrefabs)
    {
        string key = refPrefabs.poolingKey;
        if (poolingDict.ContainsKey(key))
        {
            if (poolingDict[key].deactiveList.Count > 0)
            {
                PoolObject obj = poolingDict[key].deactiveList[0];
                poolingDict[key].deactiveList.RemoveAt(0);
                if (obj == null)
                {
                    obj = Instantiate(refPrefabs);
                }
                poolingDict[key].activeList.Add(obj);
                obj.gameObject.SetActive(true);
                return obj;
            }
            else
            {
                PoolObject obj = Instantiate(refPrefabs);
                poolingDict[key].activeList.Add(obj);
                return obj;
            }
        }
        else
        {
            Pool newPool = new Pool();
            newPool.poolingKey = key;
            PoolObject obj = Instantiate(refPrefabs);
            newPool.activeList.Add(obj);
            poolingDict.Add(key, newPool);
            return obj;
        }

    }
    public void Despawn(PoolObject obj)
    {
        string key = obj.poolingKey;
        if (poolingDict.ContainsKey(key))
        {
            if (poolingDict[key].activeList.Contains(obj))
                poolingDict[key].activeList.Remove(obj);
            poolingDict[key].deactiveList.Add(obj);
        }
        else
        {
            Pool newPool = new Pool();
            newPool.poolingKey = key;
            newPool.deactiveList.Add(obj);
            poolingDict.Add(key, newPool);
        }
    }
}
