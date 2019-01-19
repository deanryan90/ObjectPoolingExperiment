using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VechicleEnd : MonoBehaviour
{
    //UI Elements

    private UiManager _uiManager;

    private void Awake()
    {
        _uiManager = GameObject.Find("UiController").GetComponent<UiManager>();
    }

    private string _carCountText;

    // this Trigger check the car that has passed the Player in the scene Bonus Task #5
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "OppositeCar")
        {
            _carCountText = TrafficControl.CarCount.ToString();
            _uiManager.CarCountValue.text = _carCountText;
            TrafficControl.CarCount++;
        }
    }
}