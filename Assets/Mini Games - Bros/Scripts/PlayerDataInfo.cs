using System;

[Serializable]
public class PlayerDataInfo
{
    // PlayerDataInfo[] dataInfo;
    public string usn_info;
    public string pw_info;

    public bool qqiraah_exp;
    public bool qqiraah_pretest;
    public int qasasi_exp;
    public int aasasi_exp;
    public int aaly_exp;

    public float[] qqiraah_scores;
    public float[] aasasi_scores;
    public float[] qasasi_scores;
    public float[] aaly_scores;

    public float[] qqiraah_times;
    public float[] aasasi_times;
    public float[] qasasi_times;
    public float[] aaly_times;

    public int[] aaly_right;
    public int[] aasasi_right;
    public int[] qqiraah_right;
    public int[] qasasi_right;

    public int[] aaly_experiences;
    public int[] aasasi_experiences;
    public int[] qqiraah_experiences;
    public int[] qasasi_experiences;

    public int[] aaly_wrong;
    public int[] aasasi_wrong;
    public int[] qqiraah_wrong;
    public int[] qasasi_wrong;

    public PlayerDataInfo(string usn_info, string pw_info, bool qqiraah_pretest, 
    float[] qqiraah_scores, float[] qasasi_scores, float[] aasasi_scores, float[] aaly_scores,
    float[] qqiraah_times, float[] qasasi_times, float[] aasasi_times, float[] aaly_times, 
    int[] aaly_right, int[] aasasi_right, int[] qqiraah_right, int[] qasasi_right, 
    int[] aaly_wrong, int[] aasasi_wrong, int[] qqiraah_wrong, int[] qasasi_wrong,
    int[] aaly_experiences, int[] aasasi_experiences, int[] qqiraah_experiences, int[] qasasi_experiences)
    { 
        this.usn_info = usn_info;
        this.pw_info = pw_info;
        this.qqiraah_pretest = qqiraah_pretest;

        this.qqiraah_scores = qqiraah_scores;
        this.qasasi_scores = qasasi_scores;
        this.aasasi_scores = aasasi_scores;
        this.aaly_scores = aaly_scores;

        this.qqiraah_times = qqiraah_times;
        this.qasasi_times = qasasi_times;
        this.aasasi_times = aasasi_times;
        this.aaly_times = aaly_times;

        this.aaly_right = aaly_right;
        this.aasasi_right = aasasi_right;
        this.qqiraah_right = qqiraah_right;
        this.qasasi_right = qasasi_right;

        this.aaly_wrong = aaly_wrong;
        this.aasasi_wrong = aasasi_wrong;
        this.qqiraah_wrong = qqiraah_wrong;
        this.qasasi_wrong = qasasi_wrong;

        this.aaly_experiences = aaly_experiences;
        this.aasasi_experiences = aasasi_experiences;
        this.qqiraah_experiences = qqiraah_experiences;
        this.qasasi_experiences = qasasi_experiences;
    }
}
