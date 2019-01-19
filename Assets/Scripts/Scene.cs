using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene : MonoBehaviour
{
    private static GameObject _partitions;

    private static GameObject _playerLanes;

    public static GameObject OppositeLanes;

    private static GameObject _playerGameObject;

    private void Awake()
    {
        Build();
    }

    protected void Build()
    {
        // this builds the intial scene and objects for the game
        _partitions = Instantiate(Resources.Load(@"Prefabs\Partitions")) as GameObject;
        _partitions.name = "Partitions";
        _playerLanes = Instantiate(Resources.Load(@"Prefabs\Lanes")) as GameObject;
        _playerLanes.name = "Lanes";
        OppositeLanes = Instantiate(Resources.Load(@"Prefabs\OppositeLanes")) as GameObject;
        if (OppositeLanes != null) OppositeLanes.name = "OppositeLanes";
        _playerGameObject = Instantiate(Resources.Load(@"Prefabs\Car")) as GameObject;
        if (_playerGameObject != null)
        {
            _playerGameObject.AddComponent<Player>();
            _playerGameObject.name = "Player";
        }
        if (_playerLanes != null) _playerLanes.transform.position = Vector3.zero;
    }
}