using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    public GameObject[] players;
    public GameObject[] spawns;

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
        int spawn = Random.Range(0, spawns.Length);
        player.transform.position = spawns[spawn].transform.position;
    }
}
