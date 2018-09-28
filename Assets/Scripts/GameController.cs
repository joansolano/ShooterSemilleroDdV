using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject bulletsTextM4A1;
    public GameObject bulletsTextUMP45;
    public GameObject bulletsTextGlock18;

    // Use this for initialization
    void Start () {
        bulletsTextGlock18.SetActive(false);
        bulletsTextM4A1.SetActive(false);
        bulletsTextUMP45.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
