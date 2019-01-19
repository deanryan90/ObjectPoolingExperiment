using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Master : MonoBehaviour
{
    private GameObject _scriptManagerGameObject;

    [SerializeField]
    public float _poolAmount = 20; // this is so the design team can change this before the game runs

    [SerializeField]
    public bool isExpanding = true;

    private void Awake()
    {
        // this is one focal point that intialised all the script that are need to run the game
        _scriptManagerGameObject = GameObject.Find("ScriptManager");
        DontDestroyOnLoad(this);
        _scriptManagerGameObject.AddComponent<UiController>();
        _scriptManagerGameObject.AddComponent<RoadCreator>();
        _scriptManagerGameObject.AddComponent<Scene>();
        GameObject.Find("Main Camera").AddComponent<CameraController>();
        _scriptManagerGameObject.AddComponent<ObjectPooling>();
        _scriptManagerGameObject.AddComponent<TrafficControl>();
        Destroy(_scriptManagerGameObject.GetComponent<UiController>());
    }
}