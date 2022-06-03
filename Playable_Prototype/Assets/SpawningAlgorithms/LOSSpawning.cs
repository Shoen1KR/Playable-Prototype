using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LOSSpawning : MonoBehaviour
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

    public Vector3 Spawn(GameObject player)
    {
        Debug.Log("-1-12-12-12-12-12-12-12-");
        Debug.Log(player.transform.position);
        List<GameObject> filtered = new List<GameObject>(spawns);
        foreach(GameObject spawn in spawns)
        {
            foreach(GameObject p in players)
            {
                //if(Vector3.Distance(spawn.transform.position, p.transform.position) < distance)
                Vector3 view = p.GetComponent<Camera>().WorldToViewportPoint(spawn.transform.position);
                if (view.x >= 0 && view.x <= 1 && view.y >= 0 && view.y <= 1 && view.z > 0)
                {
                    filtered.Remove(spawn);
                    break;
                }
            }
        }

        return filtered[Random.Range(0, filtered.Count)].transform.position;
        Debug.Log(player.transform.position);
    }
}