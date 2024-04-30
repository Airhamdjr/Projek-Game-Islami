using System.Collections.Generic;
using UnityEngine;
using System;

public class DataHandler : MonoBehaviour
{
    public GameObject player;
    public PretestData pretest_qqiraah;
    public PretestData pretest_qasasi;
    public PretestData pretest_aasasi;
    public PretestData pretest_aaly;
    public bool test;

    public LoginUser loginUser;

    [SerializeField] private string file_name;
    [SerializeField] private string user_info;
    [SerializeField] private int usn_index;
    [SerializeField] private string pw_info;

    public bool qqiraah_exp;
    public bool qqiraah_pretest;

    [SerializeField] private int qasasi_exp;
    [SerializeField] private int aasasi_exp;
    [SerializeField] private int aaly_exp;
    [SerializeField] private float[] qqiraah_scores;
    [SerializeField] private float[] qasasi_scores;
    [SerializeField] private float[] aasasi_scores;
    [SerializeField] private float[] aaly_scores;
    [SerializeField] private float[] qqiraah_times;
    [SerializeField] private float[] qasasi_times;
    [SerializeField] private float[] aasasi_times;
    [SerializeField] private float[] aaly_times;
    [SerializeField] private int[] aaly_right;
    [SerializeField] private int[] aasasi_right;
    [SerializeField] private int[] qqiraah_right;
    [SerializeField] private int[] qasasi_right;
    [SerializeField] private int[] aaly_wrong;
    [SerializeField] private int[] aasasi_wrong;
    [SerializeField] private int[] qqiraah_wrong;
    [SerializeField] private int[] qasasi_wrong;
    [SerializeField] private int[] aaly_experiences;
    [SerializeField] private int[] qqiraah_experiences;
    [SerializeField] private int[] qasasi_experiences;
    [SerializeField] private int[] aasasi_experiences;

    public List<PlayerDataInfo> entries = new List<PlayerDataInfo>();
    public List<PlayerDataInfo> check_usn = new List<PlayerDataInfo>();

    int index;
    bool toSave = false;

    void Awake()
    {
        entries = FileHandler.ReadFromJSON<PlayerDataInfo>("player_info.json");
        toSave = false;
    }
    private void OnEnable()
    {
        user_info = loginUser.login_username;
        
    }

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        foreach (var item in entries)
        {
           if(item.usn_info == user_info)
            {
                toSave = true;
                qqiraah_experiences = item.qqiraah_experiences;
                qqiraah_scores = item.qqiraah_scores;
                qqiraah_times = item.qqiraah_times;

                qasasi_experiences = item.qasasi_experiences;
                qasasi_scores = item.qasasi_scores;
                qasasi_times = item.qasasi_times;

                aaly_experiences = item.aaly_experiences;
                aaly_scores = item.aaly_scores;
                aaly_times = item.aaly_times;

                aasasi_experiences = item.aasasi_experiences;
                aasasi_scores = item.aasasi_scores;
                aasasi_times = item.aasasi_times;

                aaly_right = item.aaly_right;
                break;
            }
            /* }*/
        }

    }
    void Update()
    {
        // if ()
        // {

        // }
        // for testing only using test bool
        // if (playerController.pretest_stat)
        // {
        //     test = true;
        // }
        // if (test)
        // {
        //     mainDataHandler();
        // }

    }

    public void mainDataHandler()
    {
        user_info = loginUser.login_username;
        qqiraah_scores = pretest_qqiraah.scores;
        qasasi_scores = pretest_aasasi.scores;
        aasasi_scores = pretest_aasasi.scores;
        aaly_scores = pretest_aaly.scores;

        qqiraah_times = pretest_qqiraah.times;
        qasasi_times = pretest_qasasi.times;
        aasasi_times = pretest_aasasi.times;
        aaly_times = pretest_aaly.times;

        qqiraah_experiences = pretest_qqiraah.experience;
        qasasi_experiences = pretest_qasasi.experience;
        aasasi_experiences = pretest_aasasi.experience;
        aaly_experiences = pretest_aaly.experience;

        aaly_right = pretest_aaly.rightAnswer;
        aaly_wrong = pretest_aaly.wrongAnswer;

        aasasi_right = pretest_aasasi.rightAnswer;
        aasasi_wrong = pretest_aasasi.wrongAnswer;

        qqiraah_right = pretest_qqiraah.rightAnswer;
        qqiraah_wrong = pretest_qqiraah.wrongAnswer;

        qasasi_right = pretest_qasasi.rightAnswer;
        qasasi_wrong = pretest_qasasi.wrongAnswer;
        AddToList();


        FileHandler.SaveToJSON<PlayerDataInfo>(entries, "player_info.json");
        entries = FileHandler.ReadFromJSON<PlayerDataInfo>("player_info.json");
    }

    bool SaveData()
    {
        bool update_data = false;
        check_usn = entries;
        index = 0;

        foreach (var i in check_usn)
        {
            if (i.usn_info == user_info)
            {
                usn_index = index;
                return true;
/*                break;*/
            }
            else
            {
                update_data = false;
            }

            index++;
        }
        return update_data;
    }
    public void AddToList()
    {

        if (!SaveData())
        {
            entries.Add(new PlayerDataInfo(loginUser.login_username, pw_info, qqiraah_pretest,
                qqiraah_scores, qasasi_scores, aasasi_scores, aaly_scores,
                qqiraah_times, qasasi_times, aasasi_times, aaly_times,
                aaly_right, aasasi_right, qqiraah_right, qasasi_right,
                aaly_wrong, aasasi_wrong, qqiraah_wrong, qasasi_wrong,
                aaly_experiences, aasasi_experiences, qqiraah_experiences, qasasi_experiences));
        }
        else
        {
            // update the data
            entries[usn_index].usn_info = loginUser.login_username;
            entries[usn_index].pw_info = pw_info;

            entries[usn_index].qqiraah_scores = qqiraah_scores;
            entries[usn_index].qasasi_scores = qasasi_scores;
            entries[usn_index].aasasi_scores = aasasi_scores;
            entries[usn_index].aaly_scores = aaly_scores;

            entries[usn_index].qqiraah_times = qqiraah_times;
            entries[usn_index].qasasi_times = qasasi_times;
            entries[usn_index].aasasi_times = aasasi_times;
            entries[usn_index].aaly_times = aaly_times;

            entries[usn_index].qqiraah_pretest = qqiraah_pretest;

            entries[usn_index].aaly_right = aaly_right;
            entries[usn_index].aasasi_right = aasasi_right;
            entries[usn_index].qqiraah_right = qqiraah_right;
            entries[usn_index].qasasi_right = qasasi_right;

            entries[usn_index].aaly_wrong = aaly_wrong;
            entries[usn_index].aasasi_wrong = aasasi_wrong;
            entries[usn_index].qqiraah_wrong = qqiraah_wrong;
            entries[usn_index].qasasi_wrong = qasasi_wrong;

            entries[usn_index].qqiraah_experiences = qqiraah_experiences;
            entries[usn_index].qasasi_experiences = qasasi_experiences;
            entries[usn_index].aasasi_experiences = aasasi_experiences;
            entries[usn_index].aaly_experiences = aaly_experiences;
        }
    }


    void OnApplicationQuit()
    {
        // save the data before exit
        FileHandler.SaveToJSON<PlayerDataInfo>(entries, "player_info.json");
    }
}