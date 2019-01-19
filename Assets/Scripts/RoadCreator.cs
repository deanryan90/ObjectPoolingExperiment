using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadCreator : MonoBehaviour
{
    private Vector3 _offset = new Vector3(0, 0, 0);

    public void BuildRoad()
    {
        // this rebuild the infinity scene with all the objects
        Destroy(GameObject.Find("Lanes"));
        GameObject lanes = Instantiate(Resources.Load(@"Prefabs\Lanes")) as GameObject;
        lanes.transform.position = new Vector3(0, 0, GameObject.Find("Player").transform.position.z);

        Destroy(GameObject.Find("OppositeLanes"));
        GameObject oppositeLanes = Instantiate(Resources.Load(@"Prefabs\OppositeLanes")) as GameObject;
        oppositeLanes.transform.position = new Vector3(-3.72f, 0, GameObject.Find("Player").transform.position.z);

        Destroy(GameObject.Find("Partitions"));
        GameObject partitions = Instantiate(Resources.Load(@"Prefabs\Partitions")) as GameObject;
        partitions.transform.position = new Vector3(-1.886f, 0.28f, GameObject.Find("Player").transform.position.z);

        lanes.name = "Lanes";
        oppositeLanes.name = "OppositeLanes";
        partitions.name = "Partitions";
    }
}