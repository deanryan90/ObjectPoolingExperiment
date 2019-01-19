﻿using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    //  This sets up all the UI elements the design team that can be changed at Runtime #Bonus Task #5
    private Toggle _playerConstantRateToggle;

    private Transform _playerConstantRateText;
    private InputField _constantRateInputField;
    private string _speed;

    private Transform _carAmountText;
    private InputField _carAmountInputField;
    private Text _carAmountValue;

    private Transform _carSpeedText;
    private InputField _minSpeedInputField;
    private InputField _maxSpeedInputField;
    private Text _minSpeedValue;
    private Text _maxSpeedValue;

    private Transform _carCountText;
    private Text _carCountValue;

    private Transform _mayhamMode;
    private bool _isMayhamMode;

    public Text CarCountValue
    {
        get
        {
            return _carCountValue;
        }
        set
        {
            _carCountValue = value;
        }
    }

    public Toggle PlayerConstantRateToggle
    {
        get { return _playerConstantRateToggle; }
    }

    public InputField ConstantRateInputField
    {
        get { return _constantRateInputField; }
    }

    public InputField MinSpeedInputField
    {
        get { return _minSpeedInputField; }
    }

    public InputField MaxSpeedInputField
    {
        get { return _maxSpeedInputField; }
    }

    public InputField CarAmountInputField
    {
        get { return _carAmountInputField; }
    }

    private void Awake()
    {
        //Sets up all the variables that the design team can easily change without hassle
        _playerConstantRateText = GameObject.Find("PlayerConstantRateText").transform;
        _playerConstantRateText.transform.GetChild(0).GetComponent<Toggle>().onValueChanged.AddListener(ConstantRateToggle);
        _playerConstantRateToggle = _playerConstantRateText.transform.GetChild(0).GetComponent<Toggle>();
        _constantRateInputField = _playerConstantRateText.GetChild(1).GetComponent<InputField>();

        _speed = _constantRateInputField.text;

        _carAmountText = GameObject.Find("CarAmountText").transform;
        _carAmountInputField = _carAmountText.GetChild(0).GetComponent<InputField>();
        _carAmountValue = _carAmountInputField.GetComponent<Text>();

        _carSpeedText = GameObject.Find("CarSpeedText").transform;
        _minSpeedInputField = _carSpeedText.GetChild(0).GetComponent<InputField>();
        _maxSpeedInputField = _carSpeedText.GetChild(1).GetComponent<InputField>();
        _minSpeedValue = _minSpeedInputField.GetComponent<Text>();
        _maxSpeedValue = _maxSpeedInputField.GetComponent<Text>();
        _carSpeedText.gameObject.SetActive(false);

        _carCountText = GameObject.Find("CarCountText").transform;
        _carCountValue = _carCountText.GetChild(0).GetComponent<Text>();

        _mayhamMode = GameObject.Find("MayhamMode").transform;
        _mayhamMode.GetChild(0).GetComponent<Toggle>().onValueChanged.AddListener(MayhamModeToggle);
        _isMayhamMode = _mayhamMode.GetChild(0).GetComponent<Toggle>().isOn;
    }

    private void MayhamModeToggle(bool value)
    {
        if (value == true)
        {
        }
        else
        {
        }
    }

    private void ConstantRateToggle(bool value)
    {
        if (value == true)
        {
            _constantRateInputField.gameObject.SetActive(true);
            _carSpeedText.gameObject.SetActive(false);
        }
        else
        {
            _carSpeedText.gameObject.SetActive(true);
            _constantRateInputField.gameObject.SetActive(false);
        }
    }
}