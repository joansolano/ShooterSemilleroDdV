using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruebaCubo : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Debug.Log("La bala atraviesa el cubo");
        }
    }
}
