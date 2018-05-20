using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoPlayBird : MonoBehaviour
{
    private bool flag = true;
    public bool dead = false;
    public float uForce = 200f;
    public Rigidbody2D rb2d;
    public Animator anim;
    public int jumps;
    public float nextJumpTime ;
    public float nextBetweenJump ;
    public float jumpInterval ;
    public float betweenJump;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (jumps > 0&&!dead&&Time.time>nextJumpTime)
        {
            anim.SetTrigger("Flap");
            //...zero out the birds current y velocity before...
            rb2d.velocity = Vector2.zero;
            //  new Vector2(rb2d.velocity.x, 0);
            //..giving the bird some upward force.
            rb2d.AddForce(new Vector2(0, uForce));
            jumps--;
            nextJumpTime = Time.time + jumpInterval;

        }
        if (jumps > 0 && !dead && Time.time > nextBetweenJump)
        {
            anim.SetTrigger("Flap");
            //...zero out the birds current y velocity before...
            rb2d.velocity = Vector2.zero;
            //  new Vector2(rb2d.velocity.x, 0);
            //..giving the bird some upward force.
            rb2d.AddForce(new Vector2(0, uForce));
            jumps--;
            nextBetweenJump = nextJumpTime+betweenJump;

        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            jumps = 2;
        }


    }


    public void changeOfDificulty(float dificulty)
    {
        if(flag)
        {
            uForce = uForce * dificulty;
            jumpInterval = jumpInterval * (1 / dificulty);
        
        }
        else
        {
            flag = true;
        }
    }
    public void kill()
    {

        dead = true;
        anim.SetTrigger("Dead");

    }
   





}
