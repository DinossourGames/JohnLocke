using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    [SerializeField] private Platform[] platforms;

    private void Start()
    {
        platforms = FindObjectsOfType<Platform>();
    }

    public void UpdateList(bool force, Platform sender)
    {
//        if (force)
//            platforms = FindObjectsOfType<Platform>();

//        foreach (var platform in platforms)
//        {
//            platform.UpdateState();
//        }
    }
}