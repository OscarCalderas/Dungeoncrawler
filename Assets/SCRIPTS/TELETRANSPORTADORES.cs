using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TELETRANSPORTADORES : MonoBehaviour
{
    public Transform Target;
    public GameObject JUGADOR;

    private void OnTriggerEnter (Collider other)
    {
        JUGADOR.transform.position = Target.transform.position;
    }
}
