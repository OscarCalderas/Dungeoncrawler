using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class ENEMIGO_SENCILLO : MonoBehaviour
{
    public int vida = 1;
    public float tiempoentreDisparo = 2f;
    public GameObject _projectile;
    public float shotForce = 1500;
    public float shotRate = 0.5f;
    private float shotRateTime = 0;
    public Transform _puntoDisparo;

    private float _tiempoUltimoDisparo;

    public Rigidbody _rb;
    public bool _drop;
    public int _value;
    public GameObject _loot;
    public string _name;

    void Start()
    {
        _tiempoUltimoDisparo = tiempoentreDisparo;

        _rb = GetComponent<Rigidbody>();

        _value = Random.Range(0, 100);
        if (_value >= 15)
        {
            _drop = true;
        }
        Debug.Log(SceneManager.GetActiveScene().ToString());
    }

    private void Update()
    {
        _tiempoUltimoDisparo += Time.deltaTime;

        if (_tiempoUltimoDisparo >= tiempoentreDisparo)
        {
            Disparar();
            _tiempoUltimoDisparo = 0f;
        }

        if (vida <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void Disparar()
    {
        if (Time.time > shotRateTime)
        {
            GameObject newProjectile;
            newProjectile = Instantiate(_projectile, _puntoDisparo.position, _puntoDisparo.rotation);
            newProjectile.GetComponent<Rigidbody>().AddForce(_puntoDisparo.forward * shotForce);
            shotRateTime = Time.time + shotRate;
        }
    }
}
