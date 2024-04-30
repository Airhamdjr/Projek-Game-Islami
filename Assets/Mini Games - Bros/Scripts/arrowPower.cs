using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowPower : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10f;
    public Rigidbody2D rb = new Rigidbody2D();
    public int hitPower;
    private Enemy GetEnemy;


    void Start()
    {
        // play arc animation then release arrow
        // StartCoroutine(Shooting());
        rb.velocity = transform.right * speed;
    }
    void Awake()
    {

        hitPower = 10;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {

        GetEnemy = hitInfo.GetComponent<Enemy>();

        if (GetEnemy != null)
        {
            GetEnemy.beingHit(hitPower);
        }

        Debug.Log(hitInfo.name);

        if (hitInfo.tag != "Player")
        {
            Destroy(this.gameObject);
        }
        // destroy the arrow

        // get the type of Enemy component in object collision

    }
    // IEnumerator Shooting()
    // {
    //     // yield return new WaitForSeconds(0.24f);
    //     // rb.velocity = transform.right * speed;
    // }
}
