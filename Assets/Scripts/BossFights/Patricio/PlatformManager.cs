using System;
using System.Collections;
using System.Collections.Generic;
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

[Serializable]
public class PlatformData
{
    [SerializeField] private GameObject platformObject;
    [SerializeField] private Platform platformScript;

    public PlatformData(GameObject platformObject, Platform platformScript)
    {
        this.PlatformObject = platformObject;
        this.PlatformScript = platformScript;
    }

    public GameObject PlatformObject
    {
        get => platformObject;
        set => platformObject = value;
    }

    public Platform PlatformScript
    {
        get => platformScript;
        set => platformScript = value;
    }
}

public class PlatformManager : MonoBehaviour
{
    [SerializeField] private Vector2 screenBounds;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private GameObject platformPrefab;
    [SerializeField] private LayerMask platformMask;

    [Header("Listas"), Space] [SerializeField]
    private List<PlatformData> platforms;

    [SerializeField] private List<PlatformPosition> platformsPositions;

    private void Start()
    {
        screenBounds =
            mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        platformsPositions = new List<PlatformPosition>();

        var sizeX = (screenBounds.x * 2 / 6);
        var sizeY = 1;

        for (var i = 0; i < 6; i++)
        {
            var start = new Vector3(screenBounds.x * -1 + sizeX * i, screenBounds.y * -1);
            var end = new Vector3(screenBounds.x * -1 + sizeX * i, screenBounds.y * -1 + sizeY);

            var rect = new Rect(new Vector2(start.x, start.y), new Vector2(sizeX, sizeY));

            Debug.DrawLine(start, end, Color.black, 1000);

            var pos = new PlatformPosition(i, false, rect);
            platformsPositions.Add(pos);
        }

        for (var i = 0; i < platformsPositions.Count; i++)
        {
            var platformsPosition = platformsPositions[i];
            var platform = Instantiate(platformPrefab,
                new Vector3(platformsPosition.Position.center.x, platformsPosition.Position.center.y, 0),
                Quaternion.identity);
            platform.transform.SetParent(transform);
            var data = new PlatformData(platform, platform.GetComponent<Platform>());
            platforms.Add(data);
            platformsPositions[i].IsOccuped = true;
        }

        platforms[0].PlatformScript.UpdateState();
    }


    private void Update()
    {
        PositionCheckers();
        UpdatePositions();
    }

    private void PositionCheckers()
    {
        foreach (var position in platformsPositions)
        {
            position.IsOccuped = Physics2D.OverlapPoint(position.Position.center, platformMask);
        }
    }

    private void UpdatePositions()
    {
        foreach (var platform in platforms)
        {
            var state = platform.PlatformScript.State;
            if (state == State.Rising || state == State.Falling || state == State.IdleUp || state == State.MovingLeft ||
                state == State.MovingRight)
                continue;

            //TODO : Check boss side and take different approach.

            //check if the near point is empty
            foreach (var platformPosition in platformsPositions.Where(platformPosition => !platformPosition.IsOccuped))
            {
                var distance = Vector3.Distance(platform.PlatformObject.transform.position,
                    platformPosition.Position.center);
                if (distance > 2.5f && distance < 4f)
                {
                    print(
                        $"Platform: {platforms.IndexOf(platform)} Distance: {distance}  State: {platform.PlatformScript.State}");

                    if (BossFightManager.BossSide == BossSide.Right)
                    {
                        if (platforms.IndexOf(platform) > platformPosition.Index && !platform.PlatformScript._movementLocker)
                            platform.PlatformScript.StartCoroutine(platform.PlatformScript.Move(platformPosition.Position.center,true));
                    }
                }
            }
        }
    }
}