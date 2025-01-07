using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public GameObject instance;
    private int speed;
    void Awake()
    {
        if(transform.position.z == 0)
        {
            speed = 10;
        }
        else
        {
            speed = -10;
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(speed*Time.deltaTime,0,0);
        
        if(transform.position.x < -25 || transform.position.x >25)
            Destroy(instance);
    }
}
