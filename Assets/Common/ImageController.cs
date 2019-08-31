using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageController : MonoBehaviour
{
    [SerializeField] private Image target;
    [SerializeField] private Sprite[] images;
    [SerializeField] private int position;

    private void Start()
    {
        target.sprite = images[position];
    }

    public void Next()
    {
        if (position < images.Length)
            position++;
        else
            position = 0;
        
        target.sprite = images[position];
    }

    public void Previous()
    {
        if (position > 0)
            position--;
        else
            position = images.Length;
        
        target.sprite = images[position];
    }
}