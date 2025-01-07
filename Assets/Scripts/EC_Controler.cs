using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EC_Controler : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private SpriteRenderer mySpriteRenderer;
    private float VelocityX;
    public GameObject fireballPrefab;

    private bool attacking;

    void Start()
    {
        VelocityX = 0;
        attacking = false;
    }


    // Update is called once per frame
    void Update()
    {
        //rather than WASD, EC used IJKL
        //J -> left, L -> right
        //I -> attack
        
        float newVelocityX = 0;

        if (Input.GetKeyDown("i"))
        {
            animator.SetTrigger("attacking");
            if(!attacking)
            {
                attacking = true;
                StartCoroutine(spell());
            }
        }

        if(Input.GetKey(KeyCode.J))
        {
            newVelocityX = -speed;
            animator.SetInteger("DirectionX", -1);
            mySpriteRenderer.flipX = false;

        } 
        else if(Input.GetKey(KeyCode.L))
        {
            newVelocityX = speed;
            animator.SetInteger("DirectionX", 1);
            mySpriteRenderer.flipX = true;

        } 
        else 
        {
            animator.SetInteger("DirectionX", 0);
        }
        
        if(newVelocityX != VelocityX)
            VelocityX = newVelocityX;

        this.transform.Translate(VelocityX*Time.deltaTime,0,0);
    }

    private IEnumerator spell()
    {
        float delayFrames = 3f;
        yield return new WaitForSeconds(delayFrames/8f);
        if(!mySpriteRenderer.flipX)
        {
            GameObject fireball = Instantiate(fireballPrefab, new Vector3(transform.position.x -2f,-0.9f,1),Quaternion.identity);
        }
        else
        {
            GameObject fireball = Instantiate(fireballPrefab, new Vector3(transform.position.x +2f,-0.9f,0),Quaternion.identity);
        }
        yield return new WaitForSeconds((11f-delayFrames)/8f);
        attacking = false;
    }


}
