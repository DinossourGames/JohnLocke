﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BOSS_FIGHT_STATE { STARTING, STAGE1, STAGE2, STAGE3, FINISHING }


public class BossFightManager : MonoBehaviour
{

    [Header("BOSS MANAGER STATS")]
    [SerializeField] BOSS_FIGHT_STATE fightState;

}
