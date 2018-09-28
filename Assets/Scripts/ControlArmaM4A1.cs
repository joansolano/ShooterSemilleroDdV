using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlArmaM4A1 : MonoBehaviour {

    public Text bulletsText;
    public Image crossHairImage;
    public Image puntoCrossHairImage;

    public GameObject bala;
    public Transform spawnBala;
    public AudioClip soundM4a1;
    public float fireRate;
    private float nextFire = 0;
    public float destroyTimeClonBullet;

    public int maxAmmo = 30;
    private int currentAmmo;
    public float reloadTime = 1f;
    private bool isReloading = false;
    public int capacityAmmo = 120;

    /*
    private Vector3 armaSinApuntar;
    public Vector3 armaApuntando;
    */

    public Camera camara;

    public float velocidad;
    public float zoom;
    private float zoomInicial;
    bool Apuntar = false;

    public Animator animator;
    public ParticleSystem muzzleFlashM4A1;
    public ParticleSystem puffBulletM4A1;

    private void Awake()
    {
        //armaSinApuntar = this.transform.localPosition;
        zoomInicial = Camera.main.fieldOfView;
    }
    // Use this for initialization
    void Start () {
        currentAmmo = maxAmmo;
        crossHairImage.enabled = true;
        puntoCrossHairImage.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(1))
        {
            Apuntar = !Apuntar;
        }
        SistemaApuntado(Apuntar);

        if (isReloading) return;

        if (currentAmmo == 0 && capacityAmmo == 0) return;

        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Shoot();
        }
        if (currentAmmo == 0 && capacityAmmo != 0)
        {
            StartCoroutine(Reload());
            return;
        }
        if (Input.GetKey("r") && currentAmmo < maxAmmo && capacityAmmo >= 0 && capacityAmmo != 0 && currentAmmo >= 0)
        {
            StartCoroutine(Reload());
            return;
        }

	}

    void SistemaApuntado(bool _Apuntando)
    {
        if (_Apuntando)
        {
            /*
            this.transform.localPosition = Vector3.Lerp(this.transform.localPosition, armaApuntando, velocidad * Time.deltaTime);
            */
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, zoom, velocidad * Time.deltaTime);
            animator.SetBool("Apuntar", true);
            crossHairImage.enabled = false;
            puntoCrossHairImage.enabled = true;
        }
        else
        {
            /*
            this.transform.localPosition = Vector3.Lerp(this.transform.localPosition, armaSinApuntar, velocidad * Time.deltaTime);
            */
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, zoomInicial, velocidad * Time.deltaTime);
            animator.SetBool("Apuntar", false);
            crossHairImage.enabled = true;
            puntoCrossHairImage.enabled = false;
        }

    }

    void Shoot()
    {
        GameObject clonBullet = Instantiate(bala, spawnBala.position, spawnBala.rotation) as GameObject;
        GetComponent<AudioSource>().PlayOneShot(soundM4a1);
        muzzleFlashM4A1.Play();
        puffBulletM4A1.Play();
        currentAmmo--;
        bulletsText.text = "Bullets: " + currentAmmo + "/" + capacityAmmo;
        Destroy(clonBullet, destroyTimeClonBullet);
    }

    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reload...");

        animator.SetBool("Apuntar", false);
        animator.SetBool("Reloading", true);

        yield return new WaitForSeconds(reloadTime);

        animator.SetBool("Reloading", false);

        if(currentAmmo <= 0 && capacityAmmo >= maxAmmo)
        {
            currentAmmo = maxAmmo;
            capacityAmmo -= maxAmmo;
        }
        else if(currentAmmo > 0 && currentAmmo <= 29 && capacityAmmo >= maxAmmo)
        {
            capacityAmmo -= (maxAmmo-currentAmmo);
            currentAmmo = maxAmmo;
        }
        else if(currentAmmo <= 0 && capacityAmmo <= maxAmmo)
        {
            currentAmmo = capacityAmmo;
            capacityAmmo = 0;
        }

        bulletsText.text = "Bullets: " + currentAmmo + "/" + capacityAmmo;
        isReloading = false;
    }
}
