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
    public float lastJump;
    public float betweenJump;
    public bool jumping=false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (jumps >1&&!dead&&jumping)
        {
            anim.SetTrigger("Flap");
            //...zero out the birds current y velocity before...
            rb2d.velocity = Vector2.zero;
            //  new Vector2(rb2d.velocity.x, 0);
            //..giving the bird some upward force.
            rb2d.AddForce(new Vector2(0, uForce));
            jumps--;
            lastJump = Time.time;

        }
        if (jumps > 0 && !dead && Time.time >lastJump+betweenJump&&jumping )
        {
            anim.SetTrigger("Flap");
            //...zero out the birds current y velocity before...
            rb2d.velocity = Vector2.zero;
            //  new Vector2(rb2d.velocity.x, 0);
            //..giving the bird some upward force.
            rb2d.AddForce(new Vector2(0, uForce));
            jumps--;
            jumping = false;

        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            jumps = 2;
            rb2d.velocity = Vector2.zero;
        }


    }


    public void changeOfDificulty(float dificulty)
    {
        
            uForce = uForce * dificulty;
            betweenJump = betweenJump / dificulty;
    
    }
    public void kill()
    {

        dead = true;
        anim.SetTrigger("Dead");

    }
    public void jump()
    {
        jumping = true;
    }
   





}
