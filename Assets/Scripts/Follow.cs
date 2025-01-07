using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject MC;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float avg = MC.transform.position.x;
        if(avg > 14.7f)
            avg = 14.7f;
        else if (avg < -14.7f)
            avg = -14.7f;

        if(Mathf.Abs(avg - transform.position.x) > 5)
            this.transform.Translate((avg - transform.position.x)*Time.deltaTime,0,0);
    }
}
