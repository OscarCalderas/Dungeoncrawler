using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private CharacterController characterController;
    public new Transform camera;
    public float speed = 4f;
    public float gravity = -9.8f;
    public int sceneVictoria;
    public int playerLive = 5;


    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Vector3 movement = Vector3.zero;
        float movementSpeed = 0;

        if (hor != 0 || ver != 0)
        {
            Vector3 forward = camera.forward;
            forward.y = 0;
            forward.Normalize();

            Vector3 right = camera.right;
            right.y = 0;
            right.Normalize();

            Vector3 direction = forward * ver + right * hor;
            movementSpeed = Mathf.Clamp01(direction.magnitude);
            direction.Normalize();

            movement = direction * speed * movementSpeed * Time.deltaTime;

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 0.2f);
        }

        movement.y += gravity * Time.deltaTime;

        characterController.Move(movement);
    }

    //VICTORIA Y MUERTE
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("bullet"))
        {
            playerLive = playerLive - 1;
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.tag == "Limit")
        {
            SceneManager.LoadScene("DERROTA");
        }
        if (other.gameObject.tag == "Trigger")
        {
            SceneManager.LoadScene("VICTORIA");
        }
        if (other.gameObject.tag == "Limit2")
        {
            SceneManager.LoadScene("DERROTALVL2");
        }
        if (other.gameObject.tag == "Trigger2")
        {
            SceneManager.LoadScene("VICTORIALVL2");
        }
        if (other.gameObject.tag == "Limit3")
        {
            SceneManager.LoadScene("DERROTALVL3");
        }
        if (other.gameObject.tag == "Trigger3")
        {
            SceneManager.LoadScene("VICTORIALVL3");
        }
    }
}