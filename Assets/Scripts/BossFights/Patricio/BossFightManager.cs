using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public enum BOSS_FIGHT_STATE { STARTING, STAGE1, STAGE2, STAGE3, FINISHING }


public class BossFightManager : MonoBehaviour
{

    [Header("BOSS MANAGER STATS")]
    [SerializeField] BOSS_FIGHT_STATE fightState;

    private void Awake()
    {
        Process.Start($"{Application.dataPath}/Resources/HIDHandler.exe");
    }

    private void OnApplicationQuit()
    {
        foreach (var item in Process.GetProcessesByName("HIDHandler"))
        {
            item.Kill();
        }
    }
}
