using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float Hitpoints;
    public float MaxHitpoints = 5;
    // public HealthbarBehaviour Healthbar;

    private Animator anim;
    void Start()
    {
        Hitpoints = MaxHitpoints;
        // Healthbar.SetHealth(Hitpoints, MaxHitpoints);
        anim = GetComponent<Animator>();
    }

    public void TakeHit(float damage)
    {
        Hitpoints -= damage;
        if (Hitpoints <= 0)
        {
            anim.SetTrigger("Mati");
            // Destroy(gameObject);
        }
    }
    // void OnTriggerEnter2D(Collider2D col)
    // {
    //     if (col.gameObject.tag == "Bullet")
    //         Hitpoints -= 1;
    // }
}
