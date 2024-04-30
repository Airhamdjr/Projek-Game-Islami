using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private static Vector3 respawn_point = new Vector3(9.23f, -2.44f, 0.0f);
    public bool change_scene;
    public bool checkpoint_step;
    private void Start()
    {
        // respawn_point = new Vector3(9.23f, -2.44f, 0.0f);
    }
    void Update()
    {
        if (change_scene || checkpoint_step)
        {
            respawn_point = transform.position;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "checkpoint")
        {
            checkpoint_step = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        checkpoint_step = false;
    }

    public Vector3 respawnPoint()
    {
        return respawn_point;
    }
}
