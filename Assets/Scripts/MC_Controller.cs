using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MC_Controller : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private SpriteRenderer mySpriteRenderer;

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        if(moveHorizontal < 0)
        {
            animator.SetInteger("DirectionX", -1);
            mySpriteRenderer.flipX = true;

        } 
        else if(moveHorizontal > 0)
        {
            animator.SetInteger("DirectionX", 1);
            mySpriteRenderer.flipX = false;

        } 
        else 
        {
            animator.SetInteger("DirectionX", 0);
        }
        
        if (Input.GetKeyDown("w"))
        {
            animator.SetTrigger("attacking");
        }

        this.transform.Translate(speed * moveHorizontal*Time.deltaTime,0,0);
    }



}
