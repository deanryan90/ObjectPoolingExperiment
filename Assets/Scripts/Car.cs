using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    private float _currentSpeed = 0f;
    private float _maxSpeed = 10f;
    private float _accelerationTime = 60;
    private float _minSpeed;
    private float _timeGone;
    private System.Random _randomSeed = new System.Random();

    private int _randomCarSpeed;

    public float CurrentSpeed

    {
        get { return _currentSpeed; }
        set { _currentSpeed = value; }
    }

    public float MaxSpeed
    {
        get { return _maxSpeed; }
        set { _maxSpeed = value; }
    }

    public float AccelerationTime
    {
        get { return _accelerationTime; }
        set { _accelerationTime = value; }
    }

    public float MovementSpeed
    {
        get { return _minSpeed; }
        set { _minSpeed = value; }
    }

    public float MinSpeed
    {
        get { return _minSpeed; }
        set { _minSpeed = value; }
    }

    public float TimeGone
    {
        get { return _timeGone; }
        set { _timeGone = value; }
    }

    private void Awake()
    {
        //Set the random speed number between 2-20
        _randomCarSpeed = _randomSeed.Next(2, 20);
    }

    protected void Update()
    {
        Accelerate();
    }

    public void Accelerate()
    {
        //This sets a random speed for the opposing cars coming in the opposite direction
        transform.position += transform.forward * _randomCarSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        //This calls the trigger to disable the car object in the pool
        transform.gameObject.SetActive(false);
    }
}