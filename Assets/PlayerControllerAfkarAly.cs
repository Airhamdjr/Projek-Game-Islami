using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using System;
using System.IO;
using System.Linq;

public class PlayerControllerAfkarAly : MonoBehaviour
{
    public MateriID materiID;
    public PretestData pretest_alaly;
    public CompleteTest completeTest;
    public DataHandler data_handler;
    public GameObject save_manager;
    public static Checkpoint checkpoint;
    public DataConverter2 DataConverter2;
    public TimerController timerController;
    public MultiMoora multimoora;
    private Rigidbody2D rb;
    private Animator anim;
    private Collider2D coll;

    [SerializeField] private LayerMask rightAnswer;
    [SerializeField] private LayerMask wrongAnswer;

    // Player movement
    [SerializeField] private LayerMask ground;
    [SerializeField] private float speed = 7f;
    [SerializeField] private float jumpforce = 9.5f;
    [SerializeField] private float hurtforce = 5f;
    [SerializeField] private bool facingRight = true;


    [SerializeField] public PlayerInfo playerInfo;
    [SerializeField] private float respawnDelay;
    [SerializeField] private Vector3 respawn_point;
    [SerializeField] private Vector3 positionBefore;
    private enum State
    { idle, running, jumping, falling, hurt, squat, masuk }
    private State state = State.idle;

    // Players power
    [SerializeField] private PowerController powerController;

    // TIME
    private float timeDuration = 60;
    private float timer;

    // Time GUI
    [SerializeField] private TextMeshProUGUI firstMinute;
    [SerializeField] private TextMeshProUGUI secondMinute;
    [SerializeField] private TextMeshProUGUI separator;
    [SerializeField] private TextMeshProUGUI firstSecond;
    [SerializeField] private TextMeshProUGUI secondSecond;

    // private float flashTimer;
    // private float flashDuration = 1f;

    // Question Property
    [SerializeField] private LayerMask pipe;
    static private int stateBook = 0;
    private int jumlah_materi;
    private int status = 0;
    private static int materi_id = 0;
    static public bool stat;

    // Coin GUI
    [SerializeField] private TextMeshProUGUI arrowText;

    // Health
    [SerializeField] private GameObject lives;
    private static int liveCount = 3;
    [SerializeField] private TextMeshProUGUI liveText;

    // TOPSIS pre-test data
    private bool answer;
    [SerializeField]
    private float skor_before;
    [SerializeField]
    private float skor_converted;
    [SerializeField]
    private static int[] pengalaman;
    private int time_finish;
    private float time_finish_conv;
    [SerializeField]
    private int jumlah_soal;
    [SerializeField]
    private static float skor1, skor2, skor3, skor4;
    [SerializeField]
    private static float time1, time2, time3, time4;
    private int experience1, experience2, experience3, experience4;
    private float skor_mat1, skor_mat2, skor_mat3;
    private float time_mat1, time_mat2, time_mat3;
    private int totalBenar1, totalBenar2, totalBenar3, totalBenar4;
    [SerializeField]
    public bool pretest_stat;


    // TOPSIS Var
    private string[] alternatif;
    private static float[] score, time;
    private float[] times;
    private int[] experience;

    [SerializeField]
    private string c1_category, c2_category, c3_category;
    public static List<string> destroyed = new List<string>();

    void Awake()
    {

        // checkpoint = GetComponent<Checkpoint>();
    }
    void OnEnable()
    {
        if (SceneManager.GetActiveScene().name == "Mini Bros Afkar Al-Aly")
        {
            checkpoint = GetComponent<Checkpoint>();
            transform.position = checkpoint.respawnPoint();

        }
        if (SceneManager.GetActiveScene().name == "Mini Bros Afkar Al-Aly")
        {
            checkpoint = GetComponent<Checkpoint>();
            transform.position = checkpoint.respawnPoint();
            data_handler = save_manager.GetComponent<DataHandler>();
        }
    }
    private void Start()
    {
        // Instantiate(this.gameObject, checkpoint.respawn_point, transform.rotation);
        if (destroyed.Count > 0)
        {
            for (int i = 0; i < destroyed.Count; i++)
            {
                Destroy(GameObject.Find(destroyed[i]));

            }
        }

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
        liveText.text = liveCount.ToString();

        powerController = GetComponent<PowerController>();
        timerController = GetComponent<TimerController>();
        DataConverter2 = GetComponent<DataConverter2>();
        multimoora = GetComponent<MultiMoora>();


        jumlah_materi = 4;
        pengalaman = new int[4] { 1, 2, 3, 3 };

        // foreach (var item in pengalaman)
        // {
        //     // print(item);
        // }
        // pretest_alaly.experience = pengalaman;
        // print(checkpoint.respawnPoint());
        // print(playerInfo.checkpoint);
        // respawn_point = transform.position;
        // transform.position = playerInfo.checkpoint;
        // print(checkpoint.respawn_point());

    }


    private void Update()
    {
        // if (Input.GetButtonDown("test1"))
        // {
        //     SceneManager.LoadScene("MainPretest");
        //     transform.position = respawn_point;
        // }
        if (state != State.hurt)
        {
            Movement();
        }
        AnimationState();
        anim.SetInteger("state", (int)state);

        if (liveCount == 0)
        {
            transform.position = checkpoint.respawnPoint();
            liveCount = 3;
        }
        if (state == State.hurt)
        {
            // print("state hurt");
        }

        if (Input.GetButtonDown("Submit") && stateBook == 1 && coll.IsTouchingLayers(rightAnswer))
        {
            // cek completed book
            /*completeTest.GetBookDone[completeTest.indexBook++] = 1;*/
            answer = true;
            // print("answer " + answer);
            int time_before = (int)timerController.getTimeValue();
            time_finish = DataConverter2.TimeCalculate(time_before);
            skor_converted = DataConverter2.ScoreCalculate(answer);
            if (skor_converted != 0)
            {
                switch (materi_id)
                {
                    case 1:
                        skor1 += skor_converted;
                        time1 += time_finish;
                        pretest_alaly.answer1[pretest_alaly.indexAnswer1++] = answer;
                        break;
                    case 2:
                        skor2 += skor_converted;
                        time2 += time_finish;
                        pretest_alaly.answer2[pretest_alaly.indexAnswer2++] = answer;
                        break;
                    case 3:
                        skor3 += skor_converted;
                        time3 += time_finish;
                        pretest_alaly.answer3[pretest_alaly.indexAnswer3++] = answer;
                        break;
                    case 4:
                        skor4 += skor_converted;
                        time4 += time_finish;
                        pretest_alaly.answer4[pretest_alaly.indexAnswer4++] = answer;
                        break;
                    default:
                        break;
                }

            }

            arrowText.text = (powerController.getWeapon(true)).ToString();
            liveCount += 1;
            liveText.text = liveCount.ToString();

            // SceneManager.LoadScene("scene1lv1");
            SceneManager.LoadScene("Mini Bros Afkar Al-Aly");
        }
        if (Input.GetButtonDown("Submit") && stateBook == 1 && coll.IsTouchingLayers(wrongAnswer))
        {
            // cek completed book
            completeTest.GetBookDone[completeTest.indexBook++] = 1;
            answer = false;
            // print("answer " + answer);
            int time_before = (int)timerController.getTimeValue();
            print(time_before);
            time_finish = DataConverter2.TimeCalculate(time_before);
            skor_converted = DataConverter2.ScoreCalculate(answer);

            switch (materi_id)
            {
                case 1:
                    skor1 += skor_converted;
                    time1 += time_finish;
                    pretest_alaly.answer1[pretest_alaly.indexAnswer1++] = answer;
                    break;
                case 2:
                    skor2 += skor_converted;
                    time2 += time_finish;
                    pretest_alaly.answer2[pretest_alaly.indexAnswer2++] = answer;
                    break;
                case 3:
                    skor3 += skor_converted;
                    time3 += time_finish;
                    pretest_alaly.answer3[pretest_alaly.indexAnswer3++] = answer;
                    break;
                case 4:
                    skor4 += skor_converted;
                    time4 += time_finish;
                    pretest_alaly.answer4[pretest_alaly.indexAnswer4++] = answer;
                    break;
                default:
                    break;

            }

            // SceneManager.LoadScene("scene1lv1");
            SceneManager.LoadScene("Mini Bros Afkar Al-Aly");
        }
        if (pretest_stat == true)
        {
            // if (completeTest.CheckComplete())
            // {
            pretest_stat = false;
            /*float[] final_score = new float[] { skor1, skor2, skor3, skor4 };
            float[] final_time = new float[] { time1, time2, time3, time4 };*/
            float[] final_score = new float[] { 6f, 6f, 6f, 6f };
            float[] final_time = new float[] { 12f, 6f, 6f, 9f };
            int[] final_exp = new int[4] { 9, 3, 6, 9 };


            // int[] final_exp = new int[4] { experience1, experience2, experience3, experience4 };

            for (int i = 0; i < final_score.Length; i++)
            {
                pretest_alaly.scores[i] = final_score[i];
                pretest_alaly.times[i] = final_time[i];
                pretest_alaly.experience[i] = final_exp[i];
            }
            print("skor1: " + skor1);
            print("skor2: " + skor2);
            print("skor3: " + skor3);
            print("skor4: " + skor4);
            print("time1: " + time1);
            print("time2: " + time2);
            print("time3: " + time3);
            print("time4: " + time4);
            data_handler.mainDataHandler();

            multimoora.HitungMoora();

            // }

            // else
            // {
            //     Debug.Log("Belum selesai dik.");
            // }
        }
    }

    private void Movement()
    {
        float hDirection = Input.GetAxis("Horizontal");

        if (hDirection != 0)
        {
            rb.velocity = new Vector2(hDirection * speed, rb.velocity.y);

        }
        if (hDirection < 0 && facingRight)
        {
            flip();
        }

        else if (hDirection > 0 && !facingRight)
        {
            flip();
        }

        if (Input.GetButtonDown("Jump") && (coll.IsTouchingLayers(ground) || coll.IsTouchingLayers(pipe) || coll.IsTouchingLayers(rightAnswer) || coll.IsTouchingLayers(wrongAnswer)))
        {
            Jump();
        }
        if (Input.GetButtonDown("Down"))
        {
            rb.velocity = new Vector2(rb.velocity.x, .1f);
            state = State.squat;
        }
    }

    void flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;

        transform.Rotate(0f, 180f, 0f);

        facingRight = !facingRight;
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpforce);
        state = State.jumping;
    }

    private void AnimationState()
    {
        if (state == State.jumping)
        {
            if (rb.velocity.y < .1f)
            {
                state = State.falling;
            }
        }
        else if (state == State.falling)
        {
            if (coll.IsTouchingLayers(ground) || coll.IsTouchingLayers(rightAnswer) || coll.IsTouchingLayers(wrongAnswer))
            {
                state = State.idle;
            }
        }
        else if (state == State.hurt)
        {
            if (Mathf.Abs(rb.velocity.x) < .1f)
            {
                state = State.idle;
            }
        }
        else if (Mathf.Abs(rb.velocity.x) > 2f)
        {
            state = State.running;
        }
        else if (state == State.squat)
        {
            if (rb.velocity.y < .1f)
            {
                state = State.idle;
            }
        }
        else
        {
            state = State.idle;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "book")
        {
            // checkpoint.respawn_point = transform.position;
            materi_id = 1;
            materiID.GetMateri_id = 1;
            stat = true;
            stateBook = 1;
            checkpoint.change_scene = true;
            destroying(collision.gameObject);

            SceneManager.LoadScene("QuestionScene Afkar Aly");
        }
        if (collision.tag == "book2")
        {
            // checkpoint.respawn_point = transform.position;
            materi_id = 2;
            materiID.GetMateri_id = 2;
            stat = true;
            stateBook = 1;
            checkpoint.change_scene = true;
            destroying(collision.gameObject);
            SceneManager.LoadScene("QuestionScene2 Afkar Aly");

        }
        if (collision.tag == "book3")
        {
            // checkpoint.respawn_point = transform.position;
            materi_id = 3;
            materiID.GetMateri_id = 3;
            stat = true;
            stateBook = 1;
            checkpoint.change_scene = true;
            destroying(collision.gameObject);
            SceneManager.LoadScene("QuestionScene3 Afkar Aly");
        }
        if (collision.tag == "book4")
        {
            // checkpoint.respawn_point = transform.position;
            materi_id = 4;
            materiID.GetMateri_id = 4;
            stat = true;
            stateBook = 1;
            checkpoint.change_scene = true;
            destroying(collision.gameObject);
            SceneManager.LoadScene("QuestionScene Afkar Aly");
        }

        if (collision.tag == "Collectable")
        {
            destroying(collision.gameObject);
        }
        // if (collision.tag == "checkpoint")
        // {
        //     respawn_point = transform.position;
        // }
        if (collision.tag == "finish")
        {
            // cek apakah semua soal sudah terjawab
            pretest_stat = true;
        }
    }
    void destroying(GameObject destroy_obj)
    {
        Destroy(destroy_obj.gameObject);
        destroyed.Add(destroy_obj.gameObject.name);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "trap")
        {
            // print("kena trap");
            // rb.velocity = new Vector2(rb.velocity.f, .- 1f);
            state = State.hurt;
            if (other.gameObject.transform.position.x < transform.position.x)
            {
                rb.velocity = new Vector2(hurtforce + 1, 5);
            }
            else
            {
                rb.velocity = new Vector2(-hurtforce - 2, 5);
            }
            liveCount -= 1;
            liveText.text = liveCount.ToString();
        }
    }

}