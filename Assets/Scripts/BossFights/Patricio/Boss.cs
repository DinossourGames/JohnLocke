using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] private Animator bossAnimator;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private Transform missilShootPoint;
    [SerializeField] private GameObject armGun;

    [SerializeField, Header("Prefabs"), Space]
    private GameObject bulletPrefab;

    [SerializeField] private GameObject missilPrefab;
    [SerializeField] private GameObject missilParryPrefab;

    [SerializeField] private Patricio _patricio;

    private bool isFacingRight;

    // Start is called before the first frame update
    void Start()
    {
        _patricio = FindObjectOfType<Patricio>();
    }

    // Update is called once per frame
    void Update()
    {
        Flip();
    }


    private void Flip()
    {
        if (transform.position.x - _patricio.transform.position.x < 0 && !isFacingRight)
        {
            isFacingRight = true;
            var localScale = transform.localScale;
            transform.localScale = new Vector3(localScale.x * -1, localScale.y, localScale.z);
        }

        if (!(transform.position.x - _patricio.transform.position.x > 0) || !isFacingRight) return;
        isFacingRight = false;
        var scale = transform.localScale;
        transform.localScale = new Vector3(scale.x * -1, scale.y, scale.z);
    }
}