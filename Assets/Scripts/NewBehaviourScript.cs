using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public Button btn;

    private void Awake()
    {
        btn.onClick.AddListener(Log);
    }

    private void Log()
    {
        SceneManager.LoadScene("b", 1);
    }
}
