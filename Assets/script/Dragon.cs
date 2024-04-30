using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Dragon : MonoBehaviour
{
    public Transform target;
    private float DistancetoTarget;
    private int HP = 100;
    public Slider healthBar;
    public Animator animator;
    private NavMeshAgent agent;
    public void TakeDamage(int damageAmount)
    {
        HP -= damageAmount;
        if (HP <= 0)
        {
            animator.SetTrigger("die");
            GetComponent<Collider>().enabled = false;
            Destroy(gameObject, 3f);
        }
        else
        {
            animator.SetTrigger("damage");
        }
    }
    void Start()
    {
        // Inisialisasi agent di sini
        agent = GetComponent<NavMeshAgent>();
    }
    public void HitConnect()
    {
        if (DistancetoTarget <= agent.stoppingDistance)
        {
            target.GetComponent<PlayerLogic>().PlayerGetHit(50f);
        }
    }

    private void Update()
    {
        healthBar.value = HP;
    }

}
