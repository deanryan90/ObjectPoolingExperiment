using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class TrafficControl : MonoBehaviour
{
    private List<GameObject> _spawnPoints;
    public static int CarCount = 1;

    private void Start()
    {
        _spawnPoints = new List<GameObject>();
        //Calls the pool object and sets up Car Object and Script
        InvokeRepeating("TrafficFlow", 0.1f, 0.5f);
    }

    private void TrafficFlow()
    {
        // Task #13 This uses object pooling to reuse car objects
        GameObject obj = ObjectPooling.Current.GetPooledGameObject();
        if (obj != null)
        {
            obj.transform.position = RandomSpawnsPoint().transform.position;
            Car car = obj.GetComponent<Car>();

            //Set Random colour to the shader for each car TASK #11
            Renderer rend = obj.transform.GetComponent<Renderer>();
            rend.material.shader = Shader.Find("Legacy Shaders/Diffuse");
            rend.material.SetColor("_Color", UnityEngine.Random.ColorHSV());
            obj.SetActive(true);
            _spawnPoints.Clear();
        }
    }

    public GameObject RandomSpawnsPoint()
    {
        //This set random spawn points for each car that is created this is robust the more spawn points/ lanes you add the function will adjust to this
        int spawnCount = 0;

        System.Random randomNumber = new System.Random();

        foreach (Transform parent in GameObject.Find("OppositeLanes").transform)
        {
            if (parent.gameObject.name.Contains("VehicleSpawn"))
            {
                spawnCount++;
                _spawnPoints.Add(parent.gameObject);
            }
            foreach (Transform child in parent)
            {
                if (child.name.Contains("VehicleSpawn"))
                {
                    spawnCount++;
                    _spawnPoints.Add(child.gameObject);
                }
            }
        }
        int randomSpawnPointNumber = randomNumber.Next(0, spawnCount);
        return _spawnPoints[randomSpawnPointNumber];
    }
}