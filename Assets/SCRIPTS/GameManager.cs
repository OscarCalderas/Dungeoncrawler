using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float _lifetime = 5;
    public float _maxlifetime = 0.5f;

    public TMP_Text _timeText;

    public int _coins = 0;
    public TMP_Text _Coinstext;

    public int _life = 3;
    public TMP_Text _lifetext;
    public void AddPoints(int points)
    {
        _coins += points;
        _Coinstext.text = "Coins: " + _coins.ToString();
    }
    public void ReducePoints(int points)
    {
        if (_lifetime >= _maxlifetime)
        {
            _life -= points;
            _lifetext.text = "Life: " + _life.ToString();
            _lifetime = 0;
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_lifetime < _maxlifetime)
        {
            _lifetime += Time.deltaTime;
        }
    }
}
