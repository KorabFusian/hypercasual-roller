using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollyBall : MonoBehaviour
{
    private bool laneChange = false;


    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0,0,3);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("a") && laneChange == false && transform.position.x > -.9f)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(-4, 0, 3);
            laneChange = true;
            StartCoroutine(StopLaneChange());
        }
        if(Input.GetKey("d") && laneChange == false && transform.position.x < .9f)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(4, 0, 3);
            laneChange = true;
            StartCoroutine(StopLaneChange());
        }
    }

    IEnumerator StopLaneChange() 
    {
        yield return new WaitForSeconds(.25f);
        laneChange = false;
        GetComponent<Rigidbody>().velocity = new Vector3(0,0,3);
        Debug.Log(GetComponent<Transform>().position);
    }


    private void OnTriggerEnter(Collider col)
    {
        if(col.tag == "obstacle")
        {
            Debug.Log("okoko");
        }
    }
}
