using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataReset : MonoBehaviour
{
    public MateriID materiID;
    public CompleteTest completedTest;

    public PretestData pretest;
    public LoginUser loginUser;
    // public PretestData pretest_qasasi;
    // public PretestData pretest_aasasi;
    // public PretestData pretest_aaly;
    private void OnApplicationQuit()
    {
        completedTest.reset();
        materiID.reset();
        // pretest_aaly.reset();
        // pretest_aasasi.reset();
        // pretest_qasasi.reset();
        pretest.reset();/*
        loginUser.reset();*/
    }


}
