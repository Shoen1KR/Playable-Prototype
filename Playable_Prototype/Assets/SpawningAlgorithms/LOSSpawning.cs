using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LOSSpawning : MonoBehaviour
{
    private GameObject[] players;
    private GameObject[] spawns;
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
        List<GameObject> filtered = new List<GameObject>(spawns);
        foreach(GameObject spawn in spawns)
        {
            foreach(GameObject p in players)
            {
                Vector3 view = p.transform.GetChild(0).GetComponent<Camera>().WorldToViewportPoint(spawn.transform.position);
                if(Vector3.Distance(spawn.transform.position, p.transform.position) < distance || view.x >= 0 && view.x <= 1 && view.y >= 0 && view.y <= 1 && view.z > 0)
                {
                    filtered.Remove(spawn);
                    Debug.Log("removed");
                    break;
                }
            }
        }

        return filtered[Random.Range(0, filtered.Count)].transform.position;
    }
}