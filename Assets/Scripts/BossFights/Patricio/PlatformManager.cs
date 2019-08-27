using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UnityEngine;

[Serializable]
public class PlatformPosition
{
    [SerializeField] private int _index;
    [SerializeField] private bool _isOccuped;
    [SerializeField] private Rect _position;

    public PlatformPosition(int index, bool isOccuped, Rect position)
    {
        _index = index;
        _isOccuped = isOccuped;
        _position = position;
    }

    public int Index
    {
        get => _index;
        set => _index = value;
    }

    public bool IsOccuped
    {
        get => _isOccuped;
        set => _isOccuped = value;
    }

    public Rect Position
    {
        get => _position;
        set => _position = value;
    }
}

public class PlatformManager : MonoBehaviour
{
    [SerializeField] private Vector2 screenBounds;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private GameObject platformPrefab;
    [SerializeField] private LayerMask platformMask;

    [Header("Listas"), Space] [SerializeField]
    private List<PlatformPosition> platformsPositions;

    [SerializeField] private List<Platform> _platforms; 
    private void Start()
    {
        screenBounds =
            mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        platformsPositions = new List<PlatformPosition>();
        _platforms = new List<Platform>();
        var sizeX = (screenBounds.x * 2 / 6);
        var sizeY = 1;

        for (var i = 0; i < 6; i++)
        {
            var start = new Vector3(screenBounds.x * -1 + sizeX * i, screenBounds.y * -1);
            var end = new Vector3(screenBounds.x * -1 + sizeX * i, screenBounds.y * -1 + sizeY);

            var rect = new Rect(new Vector2(start.x, start.y), new Vector2(sizeX, sizeY));

            Debug.DrawLine(start, end, Color.black, 1000);


            var platform = Instantiate(platformPrefab,
                new Vector3(rect.center.x, rect.center.y, 0),
                Quaternion.identity);
            platform.transform.SetParent(transform);

            _platforms.Add(platform.GetComponent<Platform>());
            
            var pos = new PlatformPosition(i, false, rect);

            platformsPositions.Add(pos);
        }
 
    }

    private void Update()
    {
        PositionCheckers();
    }

    private void PositionCheckers()
    {
        foreach (var t in platformsPositions)
        {
            t.IsOccuped =
                Physics2D.OverlapPoint(t.Position.center, platformMask);

            if (t.IsOccuped) continue;
            foreach (var plat in _platforms)
            {
                plat.UpdateState(t);
            }
        }
    }
    
 }