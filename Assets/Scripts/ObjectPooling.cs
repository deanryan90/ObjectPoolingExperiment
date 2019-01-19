using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public static ObjectPooling Current;

    private List<GameObject> _pooledObjectsList;

    private Master _master;

    private UiManager _uiManager;

    private void Awake()
    {
        Current = this;
        _master = GameObject.Find("Master").GetComponent<Master>();
        _pooledObjectsList = new List<GameObject>();
    }

    private void Start()
    {
        // this sets up the pool objects of type car in the scene , pool amount can be changed by the design team Via the Master Script in the Editor
        for (int i = 0; i < _master._poolAmount; i++)
        {
            GameObject obj = Instantiate(Resources.Load(@"Prefabs\OppositeCar")) as GameObject;
            if (obj != null)
            {
                obj.name = "OppositeCar";
                obj.SetActive(false);
                _pooledObjectsList.Add(obj);
            }
        }
    }

    public GameObject GetPooledGameObject()
    {
        //Gets the pool object and send this one object to Traffic Control Script
        foreach (GameObject poolObject in _pooledObjectsList)
        {
            if (!poolObject.activeInHierarchy)
            {
                return poolObject;
            }
        }
        if (_master.isExpanding)// if you want the pool list to expand , this can be adjusted via the Master Script in the Editor for the design team
        {
            GameObject obj = Instantiate(Resources.Load(@"Prefabs\OppositeCar")) as GameObject;
            _pooledObjectsList.Add(obj);
            return obj;
        }
        return null;
    }
}