using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DS4_Wrapper;

public class NewBehaviourScript : MonoBehaviour
{
    private DS4Manager ds4;

    private void Awake()
    {
        ds4 = DS4Manager.Instancia;
    }

    // Start is called before the first frame update
    void Start()
    {
        ds4.Initialize(false);
        ds4.SetLights(new Color32(255, 0, 255, 255));

    }

    // Update is called once per frame
    void Update()
    {

    }
}
