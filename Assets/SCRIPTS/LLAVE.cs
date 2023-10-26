using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LLAVE : MonoBehaviour
{
    public PUERTA_SCRIPT doorToOpen;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            doorToOpen.isUnlocked = true;
        }

        Destroy(gameObject);
    }
}
