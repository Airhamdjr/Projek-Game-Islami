using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyLogic : MonoBehaviour
{
    public float hitPoints = 100f;
    public float turnSpeed = 15f;
    public Transform target;
    public float ChaseRange;
    public Slider healthBar;

    private NavMeshAgent agent;
    private float DistancetoTarget;
    private float DistancetoDefault;
    private Animator anim;
    Vector3 DefaultPosition;


    [Header("Enemy SFX")]
    public AudioClip GethitAudio;
    public AudioClip SteptAudio;
    public AudioClip AttackSwingAudio;
    public AudioClip AttackConnectAudio;
    public AudioClip DeathAudio;
    AudioSource EnemyAudio;

    public ParticleSystem mati;

    private void Start()
    {
        target = FindAnyObjectByType<PlayerLogic>().transform;
        agent = this.GetComponent<NavMeshAgent>();
        anim = this.GetComponentInChildren<Animator>();
        //anim.SetFloat("Hitpoint", hitPoints);
        EnemyAudio = this.GetComponent<AudioSource>();
        DefaultPosition = this.transform.position;
        mati.Pause();
    }

    public void TakeDamage(int damageAmount)
    {
        hitPoints -= damageAmount;
        EnemyAudio.clip = GethitAudio;
        EnemyAudio.Play();
        if (hitPoints <= 0)
        {
            anim.SetTrigger("die");
            EnemyAudio.clip = DeathAudio;
            EnemyAudio.Play();
            GetComponent<Collider>().enabled = false;
            mati.Play();
            Destroy(gameObject, 3f);
        }
        else
        {
            anim.SetTrigger("damage");
        }
    }

    private void Update()
    {
        DistancetoTarget = Vector3.Distance(target.position, transform.position);
        DistancetoDefault = Vector3.Distance(DefaultPosition, transform.position);

        if (DistancetoTarget <= ChaseRange && hitPoints != 0)
        {
            FaceTarget(target.position);
            if (DistancetoTarget > agent.stoppingDistance + 2f)
            {
                ChaseTarget();

            }
            else if (DistancetoTarget <= agent.stoppingDistance)
            {
                Attack();
            }
        }
        else if (DistancetoTarget >= ChaseRange * 3)
        {
            agent.SetDestination(DefaultPosition);
            FaceTarget(DefaultPosition);
            if (DistancetoDefault <= agent.stoppingDistance)
            {
                Debug.Log("Time to stop");
                anim.SetBool("Run", false);
                anim.SetBool("Attack", false);
            }
        }
        healthBar.value = hitPoints;
    }

    private void FaceTarget(Vector3 destination)
    {
        Vector3 direction = (destination - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    public void Attack()
    {
        Debug.Log("attack");
        anim.SetBool("Run", false);
        anim.SetBool("Attack", true);
    }

    public void ChaseTarget()
    {
        agent.SetDestination(target.position);
        anim.SetBool("Run", true);
        anim.SetBool("Attack", false);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, ChaseRange);
    }

    public void HitConnect()
    {
        EnemyAudio.clip = AttackSwingAudio;
        EnemyAudio.Play();
        if (DistancetoTarget <= agent.stoppingDistance)
        {
            EnemyAudio.clip = AttackConnectAudio;
            EnemyAudio.Play();
            target.GetComponent<PlayerLogic>().PlayerGetHit(20f);
        }
    }

    public void step()
    {
        EnemyAudio.clip = SteptAudio;
        EnemyAudio.Play();
    }
}