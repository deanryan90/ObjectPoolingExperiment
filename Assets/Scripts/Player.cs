using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Car
{
    private float _playerSpeed = 0;
    private float _constantSpeed = 0;
    private float _minSpeed = 1;
    private float _maxSpeed = 10;

    private GameObject _scriptManagerGameObject;

    private RoadCreator _roadCreator;

    private UiManager _uiManager;

    private void Awake()
    {
        _scriptManagerGameObject = GameObject.Find("ScriptManager");
        _roadCreator = _scriptManagerGameObject.GetComponent<RoadCreator>();
        _uiManager = GameObject.Find("UiController").GetComponent<UiManager>();
    }

    private void Update()
    {
        // this allows the user to access Ui elements directly and change them depending on circumstance
        Accelerate();
        _constantSpeed = int.Parse(_uiManager.ConstantRateInputField.text);
        _minSpeed = int.Parse(_uiManager.MinSpeedInputField.text);
        _maxSpeed = int.Parse(_uiManager.MaxSpeedInputField.text);
    }

    protected new void Accelerate()
    {
        // this checks if you want to use a constant speed and more realistic min.max speed this can be changed via the PLayer Constant Rate Toggle in UI elements in Game
        if (_uiManager.PlayerConstantRateToggle.isOn == false)
        {
            //Bonus Task #4 Curavble Speed that can be changed via the Ui Elements
            _playerSpeed = Mathf.SmoothStep(_minSpeed, _maxSpeed, base.TimeGone / base.AccelerationTime);
            transform.position += transform.forward * _playerSpeed * Time.deltaTime;
            base.TimeGone += Time.deltaTime;
        }
        else
        {
            //Task #3 this controls constant speed for player car
            transform.position += transform.forward * _constantSpeed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Trigger when to build next road section
        _roadCreator.BuildRoad();
    }
}