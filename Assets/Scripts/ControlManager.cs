using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DS4_Wrapper;

public class ControlManager : MonoBehaviour
{
    public static ControlManager instance = null;
    public static DS4Manager DS4;

    private void Awake() // Needed for Singleton Pattern
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        DS4 = DS4Manager.Instancia;
    }

    
    void Update()
    {
        //Handles update timers
        DS4.PoolUpdate();
    }
}
