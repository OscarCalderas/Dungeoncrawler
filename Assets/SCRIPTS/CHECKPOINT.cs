using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CHECKPOINT : MonoBehaviour
{
    public GameObject CheckPoint;
    Vector3 spawnpoint;

    private void Start()
    {
        spawnpoint = gameObject.transform.position;
    }

    private void Update()
    {
        if (gameObject.transform.position.y <-20f)
        {
            gameObject.transform.position = spawnpoint;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        spawnpoint = CheckPoint.transform.position;
        Destroy(CheckPoint);
    }
}
