using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocidadBala : MonoBehaviour {

    private Rigidbody rig;
    public float speedBullet;

    private void Awake()
    {
        rig = GetComponent<Rigidbody>();
    }

    // Aquí se le da la velocidad en el eje "Z" a el "Projectile".
    void Start()
    {
        //rig.velocity = transform.forward * speed; //new Vector3(0f, 0f, rig.position.z * speed); | transform.forward = eje Z | transform.up = eje Y | transform.right = eje X
        rig.velocity = transform.up * speedBullet;
    }
}
