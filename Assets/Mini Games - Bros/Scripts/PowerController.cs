using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerController : MonoBehaviour
{
    public Transform bulletPoint;
    public Transform arcPoint;
    public GameObject weaponPrefab;
    public GameObject arcPrefab;
    public Animator weapon_anim;


    [SerializeField] private static int arrow = 0;


    void Start()
    {
        // playerController = GetComponent<PlayerController>();
    }
    // Update is called once per frame
    void Update()
    {
        // arrowAmount = playerController.getArrow();
        if (arrow > 0)
        {
            if (Input.GetButtonDown("Shoot"))
            {
                // play animation arc, then shoot
                Instantiate(arcPrefab, arcPoint.position, arcPoint.rotation);
                Shoot();
            }
        }
    }
    public int getWeapon(bool answer)
    {
        // print("weapon");
        if (answer)
        {
            arrow += 1;
            // print(arrow);
        }
        return arrow;
    }
    void Shoot()
    {
        arrow -= 1;
        Instantiate(weaponPrefab, bulletPoint.position, bulletPoint.rotation);
    }


}
