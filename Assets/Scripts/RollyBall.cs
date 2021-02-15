using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollyBall : MonoBehaviour
{
    private bool laneChange = false;

    public Swipe swiper;


    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0,0,3);
    }

    // Update is called once per frame
    void Update()
    {
        if(swiper.SwipeLeft && laneChange == false && transform.position.x > -.9f)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(-4, 0, 3);
            laneChange = true;
            StartCoroutine(StopLaneChange());
        }
        if(swiper.SwipeRight && laneChange == false && transform.position.x < .9f)
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
        if(-1.5 < transform.position.x && transform.position.x < -0.5)
        {
            transform.position = new Vector3(-1, transform.position.y, transform.position.z);
        }
        if(-.5 < transform.position.x && transform.position.x < 0.5)
        {
            transform.position = new Vector3(0, transform.position.y, transform.position.z);
        }
        if(.5 < transform.position.x && transform.position.x < 1.5)
        {
            transform.position = new Vector3(1, transform.position.y, transform.position.z);
        }
        // Debug.Log(GetComponent<Transform>().position);
    }


    private void OnTriggerEnter(Collider col)
    {
        if(col.tag == "obstacle")
        {
            FindObjectOfType<GameFlow>().EndGame();
        }
    }
}
