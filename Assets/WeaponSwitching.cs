using UnityEngine;
using UnityEngine.UI;

public class WeaponSwitching : MonoBehaviour {

    public int selectedWeapon = 0;
    public GameObject bulletsTextM4A1;
    public GameObject bulletsTextUMP45;
    public GameObject bulletsTextGlock18;

    // Use this for initialization
    void Start () {
        SelectWeapon();
	}
	
	// Update is called once per frame
	void Update () {

        int previousSelectedWeapon = selectedWeapon;

		if(Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectedWeapon >= transform.childCount - 1)
                selectedWeapon = 0;
            else
                selectedWeapon++;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedWeapon <= 0)
                selectedWeapon = transform.childCount - 1;
            else
                selectedWeapon--;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedWeapon = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >=2)
        {
            selectedWeapon = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3)
        {
            selectedWeapon = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && transform.childCount >= 4)
        {
            selectedWeapon = 3;
        }
        if (previousSelectedWeapon != selectedWeapon)
        {
            SelectWeapon();
        }
    }

    void SelectWeapon()
    {
        int i = 0;
        foreach(Transform weapon in transform)
        {
            if (i == selectedWeapon)
            {
                weapon.gameObject.SetActive(true);
                if (selectedWeapon == 0)
                {
                    bulletsTextM4A1.SetActive(true);
                    bulletsTextUMP45.SetActive(false);
                    bulletsTextGlock18.SetActive(false);
                }
                else if (selectedWeapon == 1)
                {
                    bulletsTextM4A1.SetActive(false);
                    bulletsTextUMP45.SetActive(true);
                    bulletsTextGlock18.SetActive(false);
                }
                else if(selectedWeapon == 2)
                {
                    bulletsTextM4A1.SetActive(false);
                    bulletsTextUMP45.SetActive(false);
                    bulletsTextGlock18.SetActive(true);
                }
            }

            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }
}
