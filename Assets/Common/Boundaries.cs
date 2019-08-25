using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Boundaries : MonoBehaviour
{
    [FormerlySerializedAs("MainCamera")] public Camera mainCamera;
    public Vector2 screenBounds;
    private float _objectWidth;
    private float _objectHeight;

    // Use this for initialization
    private void Start()
    {
        screenBounds =
            mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        _objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x; //extents = size of width / 2
        _objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y; //extents = size of height / 2
    }

    private void Update()
    {
        screenBounds =
            mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        var viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + _objectWidth, screenBounds.x - _objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1 + _objectHeight, screenBounds.y - _objectHeight);
        transform.position = viewPos;
    }
}