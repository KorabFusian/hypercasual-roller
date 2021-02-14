using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlow : MonoBehaviour
{

    public Transform tile1Obj;
    private Vector3 nextTileSpawn;
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
        Instantiate(tile1Obj, nextTileSpawn, tile1Obj.rotation);
        nextTileSpawn.z += 3;
        Instantiate(tile1Obj, nextTileSpawn, tile1Obj.rotation);
        nextTileSpawn.z += 3;
        StartCoroutine(spawnTile());
    }

}
