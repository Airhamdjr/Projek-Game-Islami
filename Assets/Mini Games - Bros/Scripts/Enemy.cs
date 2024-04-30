using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected Animator anim;
    protected Rigidbody2D rb;
    // public int enemyHealth = 50;


    // Effect for the death
    // public GameObject deathEffect;
    //protected AudioSource death;

    protected virtual void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        //death = GetComponent<AudioSource>();
    }

    public void JumpedOn()
    {
        //death.Play();
        // anim.SetTrigger("death");
        Death();
        rb.velocity = Vector2.zero;
        rb.bodyType = RigidbodyType2D.Kinematic;
        GetComponent<Collider2D>().enabled = false;
    }
    public void beingHit(int damage)
    {
        Death();
    }
    public void Death()
    {
        Destroy(this.gameObject);
    }
}
