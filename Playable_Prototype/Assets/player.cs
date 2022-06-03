using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using DG.Tweening;

public class player : MonoBehaviour
{
    [SerializeField] GameObject playerObj;
    [SerializeField] Spawning spawnManager;
    [SerializeField] Transform target;
    [SerializeField] float timeToMoveAgain;
    [SerializeField] float timeToDie;

    public bool isDieing;
    float t1;
    float t2;
    // Start is called before the first frame update
    void Start()
    {
        t1 = Random.Range(0.0f,timeToMoveAgain);
        t2 = Random.Range(0.0f,timeToDie);

    }

    // Update is called once per frame
    void Update()
    {
        if(playerObj.transform.position.y < 0 && isDieing == false)//handles a weird bug of clipping under
        {
            playerObj.transform.position = new Vector3(playerObj.transform.position.x,1,playerObj.transform.position.z);
        }

        t1 += Time.deltaTime;
        if (t1 > timeToMoveAgain && isDieing == false)
        {
            changeDirection();
            t1= Random.Range(0.0f, 0.5f);
        }
        t2 += Time.deltaTime;
        if (t2 > timeToDie && isDieing == false)
        {
            isDieing = true;
            t2 = 0;
            die();
        }
    }
    void changeDirection()
    {
        target.transform.position = new Vector3(Random.Range(-14.0f,14.0f),1,Random.Range(-14.0f,14.0f));
    }
    void die()
    {
        //sink into the ground then once done spawn anew
        target.transform.position = playerObj.transform.position;
        StartCoroutine(dieing());
    }
    IEnumerator dieing()
    {
        Color OGColor = playerObj.GetComponent<MeshRenderer>().material.color;
        Tween myTween = playerObj.transform.DOMoveY(-1.2f, 2).SetRelative().SetEase(Ease.OutQuad);
        playerObj.GetComponent<MeshRenderer>().material.DOColor(Color.black,2);
        playerObj.GetComponent<Collider>().enabled = false;
        playerObj.GetComponent<AIPath>().enabled = false;
        yield return myTween.WaitForCompletion();
        playerObj.transform.position = new Vector3(playerObj.transform.position.x,1,playerObj.transform.position.z);
        playerObj.GetComponent<Collider>().enabled = true;
        playerObj.GetComponent<AIPath>().enabled = true;
        playerObj.GetComponent<MeshRenderer>().material.color = OGColor;

        playerObj.transform.rotation = Quaternion.Euler(0,0,0);
        isDieing = false;
        spawnManager.Spawn(playerObj);
    }
}
