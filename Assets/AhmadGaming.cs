
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AhmadGaming : MonoBehaviour
{
    [Header("Player Setting")]
    private Rigidbody rb;
    public float walkspeed, runspeed, jumppower, fallspeed, airMultiplier, MaxHealth;
    public Transform PlayerOrientation;
    float horizontalInput;
    float verticalInput;
    Vector3 moveDirection;
    bool grounded = true;
    public Animator anim;
    public CameraLogic camlogic;
    public bool AimMode = false;
    public bool TPSMode = true;
    public float HitPoints = 100f;
    [Header("SFX")]
    public AudioClip ShootAudio;
    public AudioClip StepAudio;
    public AudioClip DeathAudio;
    public AudioClip AimAudio;
    AudioSource PlayerAudio;
    public GameObject arrowObject; // pastikan variabel ini di-set dengan prefab panah di Unity Editor
    public Transform arrowPoint;
    public UiGameplayLogic UiGameplay;
    public PopUp popup;


    // pastikan variabel ini di-set dengan transform yang diinginkan di Unity Editor


    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        //PlayerOrientation = this.GetComponent<Transform>();
        PlayerAudio = this.GetComponent<AudioSource>();
        MaxHealth = HitPoints;
        UiGameplay.UpdateHealthBar(HitPoints, MaxHealth);


    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        jump();
        AimModeAdjuster();
        ShootLogic();


    }
    public void step()
    {
        Debug.Log("step");
        PlayerAudio.clip = StepAudio;
        PlayerAudio.Play();
    }
    private void Movement()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        moveDirection = PlayerOrientation.forward * verticalInput + PlayerOrientation.right * horizontalInput;

        if (grounded && moveDirection != Vector3.zero)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                anim.SetBool("Run", true);
                anim.SetBool("Walk", false);

                if (AimMode)
                {
                    anim.SetBool("AimWalk", true);
                    anim.SetBool("Aiming", false);
                }

                rb.AddForce(moveDirection.normalized * runspeed * 10f, ForceMode.Force);
            }
            else
            {
                anim.SetBool("Walk", true);
                anim.SetBool("Run", false);

                if (AimMode)
                {
                    anim.SetBool("AimWalk", true);
                    anim.SetBool("Aiming", false);
                }

                rb.AddForce(moveDirection.normalized * walkspeed * 10f, ForceMode.Force);
            }
        }
        else
        {
            anim.SetBool("Walk", false);
            anim.SetBool("Run", false);
            anim.SetBool("AimWalk", false);

            if (AimMode && !grounded)
            {
                anim.SetBool("Aiming", true);
            }
        }
    }


    private void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rb.AddForce(transform.up * jumppower, ForceMode.Impulse);
            grounded = false;
            anim.SetBool("Jump", true);


        }
        else if (!grounded)
        {
            rb.AddForce(Vector3.down * fallspeed * rb.mass, ForceMode.Force);
        }
    }

    public void groundedchanger()
    {
        grounded = true;
        anim.SetBool("Jump", false);
    }


    public void AimModeAdjuster()
    {

        if (Input.GetKeyDown(KeyCode.Mouse1) && grounded)
        {
            if (AimMode)
            {
                TPSMode = true;
                AimMode = false;
                anim.SetBool("Aiming", false);
                // Set AimWalk to false when exiting AimMode
            }
            else if (TPSMode)
            {
                TPSMode = false;
                AimMode = true;
                anim.SetBool("Aiming", true);
                PlayerAudio.clip = AimAudio;
                PlayerAudio.Play();

            }
            camlogic.CameraModeChanger(TPSMode, AimMode);
        }
    }


    public void ShootLogic()
    {
        bool isAimModeActive = Input.GetKey(KeyCode.Mouse1) || AimMode;

        // Tambahkan kondisi !moveDirection untuk memastikan tidak sedang dalam kondisi bergerak
        if (Input.GetKeyDown(KeyCode.Mouse0) && isAimModeActive)
        {
            anim.SetBool("Shooting", true);
            GameObject arrow1 = Instantiate(arrowObject, arrowPoint.position, transform.rotation);
            arrow1.GetComponent<Rigidbody>().AddForce(transform.forward * 30f, ForceMode.Impulse);
            PlayerAudio.clip = ShootAudio;
            PlayerAudio.Play();
        }
        else
        {
            anim.SetBool("Shooting", false);
        }
        // Instantiate panah hanya jika sedang dalam mode Aim

        // Set flag isShooting kembali ke false setelah selesai menembak
    }

    public void PlayerGetHit(float damage)
    {
        Debug.Log("Player Receive Damage - " + damage);
        HitPoints = HitPoints - damage;
        UiGameplay.UpdateHealthBar(HitPoints, MaxHealth);
        //anim.SetTrigger("GetHit");


        if (HitPoints <= 0f)
        {
            PlayerAudio.clip = DeathAudio;
            PlayerAudio.Play();
            anim.SetBool("Death", true);



        }
        else
        {
            anim.SetTrigger("GetHit");
        }
    }
}