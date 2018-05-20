using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {
    public bool dead = false;
    public float uForce = 200f;
    public Rigidbody2D rb2d;
    public Animator anim;
    public int jumps ;
	// Use this for initialization
	void Start () {
		
	}
	    
	// Update is called once per frame
	void Update () {
        if (!dead)
        {
            if (Input.GetKeyDown(KeyCode.Space)&&jumps>0)
            {
                anim.SetTrigger("Flap");
                //...zero out the birds current y velocity before...
                rb2d.velocity = Vector2.zero;
                //  new Vector2(rb2d.velocity.x, 0);
                //..giving the bird some upward force.
                rb2d.AddForce(new Vector2(0, uForce));
                jumps--;
            }
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
        uForce = uForce * dificulty;
    }
    public void kill()
    {
       
            dead = true;
            anim.SetTrigger("Dead");
       
    }
}
