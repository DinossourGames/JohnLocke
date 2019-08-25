using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform PlayerTransform;
    public float speed;

    public float minX, maxX, minY, maxY;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = PlayerTransform.position;
        //Debug.Log(Screen.width);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Follow();

    }

    public void Follow()
    {
        if (PlayerTransform == null)
            return;

        float clampedX = Mathf.Clamp(PlayerTransform.position.x, minX, maxX);
        float clampedY = Mathf.Clamp(PlayerTransform.position.y, minY, maxY);
        transform.position = Vector2.Lerp(transform.position, new Vector2(clampedX, clampedY), speed);
    }
}
