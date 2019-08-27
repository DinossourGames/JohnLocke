using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public enum BossFightState
{
    Starting,
    Stage1,
    Stage2,
    Stage3,
    Finishing
}

public enum BossSide
{
    Left,
    Right
}

public class BossFightManager : MonoBehaviour
{
    [Header("BOSS MANAGER STATS")] public static BossFightState FightState;
    public static BossSide BossSide;
    [SerializeField] private BossSide bossSide;
    private void Start()
    {
        FightState = BossFightState.Stage1;
        BossSide = BossSide.Right;
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 75;
    }

    private void Update()
    {
        BossSide = bossSide;
    }
}
