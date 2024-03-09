// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class TileManager : MonoBehaviour
// {
//     // Start is called before the first frame update
//     public GameObject[] tilePrefabs;
//     public float zSpawn = 0f;
//     private float tileLength = 30;
//     void Start()
//     {   
//         SpawnTile(0);
//         for(int i=0;i<tilePrefabs.Length;i++)
//         {
//             SpawnTile(Random.Range(0, tilePrefabs.Length));
//         }
//     }

//     // Update is called once per frame
//     void Update()
//     {   
        
        
//     }
//     public void SpawnTile(int tileIndex)
//     {
//         Instantiate(tilePrefabs[tileIndex], transform.forward * zSpawn, transform.rotation);
//         zSpawn += tileLength;
//     }
// }
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    private List<GameObject> activeTiles = new List<GameObject>();
    public GameObject[] tilePrefabs;

    public float tileLength = 30;
    public int numberOfTiles = 3;
    public int totalNumOfTiles = 8;

    public float zSpawn = 0;

    public Transform playerTransform;

    private int previousIndex;

    void Start()
    {
        activeTiles = new List<GameObject>();
        for (int i = 0; i < numberOfTiles; i++)
        {
            if(i==0)
                SpawnTile();
            else
                SpawnTile(Random.Range(0, totalNumOfTiles));
        }

        // playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

    }
    void Update()
    {
        if(playerTransform.position.z - 35 > zSpawn - (numberOfTiles * tileLength))
        {
            int index = Random.Range(0, totalNumOfTiles);
            while(index == previousIndex)
                index = Random.Range(0, totalNumOfTiles);

            DeleteTile();
            SpawnTile(index);
        }
            
    }

    public void SpawnTile(int tileIndex = 0)
    {
        // GameObject tile = tilePrefabs[index];
        // if (tile.activeInHierarchy)
        //     tile = tilePrefabs[index + 8];

        // if(tile.activeInHierarchy)
        //     tile = tilePrefabs[index + 16];

        // tile.transform.position = Vector3.forward * zSpawn;
        // tile.transform.rotation = Quaternion.identity;
        // tile.SetActive(true);

        // activeTiles.Add(tile);
        // zSpawn += tileLength;
        // previousIndex = index;
        GameObject go = Instantiate(tilePrefabs[tileIndex], transform.forward * zSpawn, transform.rotation);
        activeTiles.Add(go);
        zSpawn += tileLength;
    }

    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        // activeTiles[0].SetActive(false);
        activeTiles.RemoveAt(0);
        // PlayerManager.score += 3;
    }
}