﻿using UnityEngine;
using UnityEngine.InputSystem.DualShock;

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
    [SerializeField] private Bossonauro boss;


    private void Start()
    {
        FightState = BossFightState.Stage1;
        BossSide = BossSide.Right;
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 75;
    }

    private void Update()
    {
        BossSide = bossSide; // for static field - this is the worst way  to do it.

        if (boss.life > 600)
        {
            FightState = BossFightState.Stage1;
            try{Patricio.ds4.SetLightBarColor(Color.green);}catch{}
        }

        if (boss.life < 600 && boss.life > 300)
        {
            FightState = BossFightState.Stage2;
            try{DualShockGamepad.current.SetLightBarColor(Color.blue);}catch{}
        }

        if (boss.life < 300)
        {
            FightState = BossFightState.Stage3;
            try{DualShockGamepad.current.SetLightBarColor(Color.red);}catch{}
        }
    }
}