using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollyBall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0,0,3);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("a"))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(-4, 0, 3);
            StartCoroutine(StopLaneChange());
        }
        if(Input.GetKey("d"))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(4, 0, 3);
            StartCoroutine(StopLaneChange());
        }
    }

    IEnumerator StopLaneChange() 
    {
        yield return new WaitForSeconds(.25f);
        GetComponent<Rigidbody>().velocity = new Vector3(0,0,3);
        Debug.Log(GetComponent<Transform>().position);
    }
}
