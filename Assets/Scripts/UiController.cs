using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiController : MonoBehaviour
{
    private GameObject _uiController;

    protected void Awake()
    {
        // create the UI Controller object so the UI Manager can be referenced in the scene
        _uiController = Instantiate(Resources.Load(@"Prefabs\Ui\UiController")) as GameObject;
        if (_uiController != null)
        {
            _uiController.AddComponent<UiManager>();
            _uiController.name = "UiController";
        }
    }
}