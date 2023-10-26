using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Enemy : MonoBehaviour
{
    //Assignables
    public Rigidbody rb;

    //Stats
    [Range(0f, 1f)]
    public float bounciness;
    public bool useGravity;

    int collisions;
    PhysicMaterial physics_mat;
    // Start is called before the first frame update
    private void Start()
    {
        Setup();
    }

    // Update is called once per frame
    private void Update()
    {

    }

    private void Setup()
    {
        physics_mat = new PhysicMaterial();
        physics_mat.bounciness = bounciness;
        physics_mat.frictionCombine = PhysicMaterialCombine.Minimum;
        physics_mat.bounceCombine = PhysicMaterialCombine.Maximum;

        GetComponent<SphereCollider>().material = physics_mat;

        rb.useGravity = useGravity;
    }
}
