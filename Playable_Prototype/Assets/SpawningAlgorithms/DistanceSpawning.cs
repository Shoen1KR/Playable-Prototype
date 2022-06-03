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
            Spawn(player);
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

    public void Spawn(GameObject player)
    {
        Debug.Log("-1-12-12-12-12-12-12-12-");
        Debug.Log(player.transform.position);
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

        player.transform.position = filtered[Random.Range(0, filtered.Count)].transform.position;
        Debug.Log(player.transform.position);
    }
}