using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUERTA_SCRIPT : MonoBehaviour
{
    public Transform _door;
    public Transform _openTransform;
    public Transform _closeTransform;
    public float _doorSpeed = 1f;
    Vector3 targetPosition;
    float time;

    public bool isUnlocked = true;
    void Start()
    {
        targetPosition = _closeTransform.position;
    }
    void Update()
    {
        if (isUnlocked && _door.position != targetPosition)
        {
            _door.transform.position = Vector3.Lerp(_door.transform.position, targetPosition, time);
            time += Time.deltaTime * _doorSpeed;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            targetPosition = _openTransform.position;
            time = 0;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            targetPosition = _closeTransform.position;
            time = 0;
        }
    }
}
