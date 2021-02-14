﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlow : MonoBehaviour
{

    public Transform tile1Obj;
    private Vector3 nextTileSpawn;

    public Transform crateObj;
    private Vector3 nextCrateSpawn;

    public Transform DblCrateObj;
    private Vector3 nextDblCrateSpawn;

    public Transform coneObj;
    private Vector3 nextConeSpawn;

    private int randX;
    private int randChoice;

    // Start is called before the first frame update
    void Start()
    {
        nextTileSpawn.z = 21;
        StartCoroutine(spawnTile());
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator spawnTile()
    {
        yield return new WaitForSeconds(1);
        randX = Random.Range(-1, 2);
        nextCrateSpawn.z = nextTileSpawn.z;
        nextCrateSpawn.y = .1f;
        nextCrateSpawn.x = randX;
        Instantiate(tile1Obj, nextTileSpawn, tile1Obj.rotation);
        Instantiate(crateObj, nextCrateSpawn, crateObj.rotation);

        if(randX == 0)
            randX = -1;
        else if(randX == -1)
            randX = 1;
        else randX = 0;

        nextDblCrateSpawn.z = nextTileSpawn.z;
        nextDblCrateSpawn.y = .1f;
        nextDblCrateSpawn.x = randX;

        Instantiate(DblCrateObj, nextDblCrateSpawn, DblCrateObj.rotation);




        nextTileSpawn.z += 3;

        randX = Random.Range(-1, 2);
        nextConeSpawn.z = nextTileSpawn.z;
        nextConeSpawn.y = .46f;
        nextConeSpawn.x = randX;

        Instantiate(tile1Obj, nextTileSpawn, tile1Obj.rotation);
        Instantiate(coneObj, nextConeSpawn, coneObj.rotation);
        nextTileSpawn.z += 3;
        StartCoroutine(spawnTile());
    }

}
