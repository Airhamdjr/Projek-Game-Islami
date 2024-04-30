using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public int damageAmount = 20;
    Collider arrowcollider;
    private void Start()
    {
        Destroy(gameObject, 3);
        arrowcollider = this.GetComponent<Collider>();
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(transform.GetComponent<Rigidbody>());
        if (other.tag == "Enemy")
        {
            Debug.Log("I hit this thing: " + tag);
            arrowcollider.enabled = false;
            transform.parent = other.transform;
            other.GetComponent<EnemyLogic>().TakeDamage(damageAmount);
        }
    }
}
