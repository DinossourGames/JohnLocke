using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public enum BossFightState { Starting, Stage1, Stage2, Stage3, Finishing }


public class BossFightManager : MonoBehaviour
{

    [Header("BOSS MANAGER STATS")]
    [SerializeField]
    private BossFightState fightState;

    private void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 75;
    }

//    private void OnApplicationQuit()
//    {
//        //TODO: REMOVE THIS
//        foreach (var item in Process.GetProcessesByName("HIDHandler"))
//        {
//            item.Kill();
//        }
//    }

   
}
