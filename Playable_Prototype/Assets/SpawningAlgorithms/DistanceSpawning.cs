using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceSpawning : MonoBehaviour
{
    public GameObject[] players;
    public GameObject[] spawns;
    public int distance;

    void Awake()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        spawns = GameObject.FindGameObjectsWithTag("SpawnPoint");
        foreach (var player in players)
        {
            Vector3 pos = Spawn(player);
            player.transform.position = pos;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 Spawn(GameObject player)
    {
        List<GameObject> filtered = new List<GameObject>(spawns);
        foreach(GameObject spawn in spawns)
        {
            foreach(GameObject p in players)
            {
                if(Vector3.Distance(spawn.transform.position, p.transform.position) < distance)
                {
                    filtered.Remove(spawn);
                    break;
                }
            }
        }

        return filtered[Random.Range(0, filtered.Count)].transform.position;
    }
}