using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RoadManager : MonoBehaviour
{

    public GameObject roadPrefab;
    public float zSpawn = 0;
    public float roadLength = 30;
    public int numberOfRoads = 2;

    private List<GameObject> activeRoads = new List<GameObject>();

    public Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        for (int i=0; i<numberOfRoads; i++)
        {
            SpawnRoad();
        }
    }

    // Update is called once per frame
    void Update()
    {
        +
    }

    public void SpawnRoad()
    {
        GameObject go =  Instantiate(roadPrefab, transform.forward * zSpawn, transform.rotation);
        activeRoads.Add(go);
        zSpawn += roadLength;
    }

    private void DeleteRoad()
    {
        Destroy(activeRoads[0]);
        activeRoads.RemoveAt(0);
    }
}