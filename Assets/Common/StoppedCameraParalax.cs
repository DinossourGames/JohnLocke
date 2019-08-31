using System.Collections.Generic;
using UnityEngine;

public class StoppedCameraParalax : MonoBehaviour
{
    [SerializeField, Header("Patricio Position")]
    private Transform playerPosition;

    [SerializeField] private float lastPosition;

    [SerializeField, Header("Parallax Controlers"), Range(0f, 1f)]
    private float intensity;

    [SerializeField] private List<Transform> layers;


    // Start is called before the first frame update
    void Start()
    {
        playerPosition = FindObjectOfType<Patricio>().transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        var direction = playerPosition.position.x - lastPosition;

        foreach (Transform layer in layers)
        {
            var parallaxSpeed = 1 - Mathf.Clamp01(Mathf.Abs(transform.position.z / layer.position.z));
            layer.Translate(intensity * parallaxSpeed * (Mathf.Abs(direction)) *
                            (direction < 0 ? Vector3.right : Vector3.left));
        }

        lastPosition = playerPosition.position.x;
    }
}