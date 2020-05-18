using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTimerScript : MonoBehaviour
{
    public float timeOfLife = 6f;
    float startTime;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        //print(timeOfLife);
        if (Time.time - startTime >= timeOfLife) {
            //Destroy(gameObject);
            //gameObject.GetComponent<Rigidbody2D>().Sleep();
            //gameObject.GetComponent<Renderer>().enabled = false;
        }
    }
}
