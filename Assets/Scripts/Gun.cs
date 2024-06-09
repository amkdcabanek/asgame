using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.Rendering;
using System.Collections;

public class Gun : MonoBehaviour
{
    public Transform fpsCam;
    public float range = 20;
    public float impactForce = 150;
    public int fireRate = 15;
    private float nextTimeToFire = 0f;

    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public int currentAmmo;
    public int maxAmmo = 10;
    public int magazineSize = 30;
    public Animator animator;
    public float reloadTime = 2f;
    private bool isReloading = false;

    InputAction fire;
    // Start is called before the first frame update
    void Start()
    {
        fire = new InputAction("Fire", binding: "Mouse/leftButton");
        fire.Enable();

        currentAmmo = maxAmmo;

    }
    private void OnEnable()
    {
        isReloading = false;
        animator.SetBool("isReloading", false);
    }
    // Update is called once per frame
    void Update()
    {
        if (currentAmmo == 0 && magazineSize ==0)
        {
            animator.SetBool("isFiring", false);
            return;
        }
        if(isReloading)
        {
            return;
        }
        bool isFiring = fire.ReadValue<float>() == 1;
        animator.SetBool("isFiring", isFiring);
        if (isFiring && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Fire();
        }
        if (currentAmmo == 0 && magazineSize > 0 && !isReloading )
        {
            StartCoroutine(Reload());
            return;
        }
    }
    private void Fire()
    {
        RaycastHit hit;
        muzzleFlash.Play();
        currentAmmo--;
        if (Physics.Raycast(fpsCam.position, fpsCam.forward, out hit, range))
        {

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
            Enmy e = hit.transform.GetComponent<Enmy>();
            if (e != null)
            {
                e.TakeDamage(10);
                return;
            }

            GameObject impact = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            impact.transform.parent = hit.transform;
            Destroy(impact, 2f);

        }
    }
    IEnumerator Reload()
    {
        isReloading = true;
        animator.SetBool("isReloading", true);
        yield return new WaitForSeconds(reloadTime);
        animator.SetBool("isReloading", false);
        if (magazineSize >= maxAmmo)
        {
            currentAmmo = maxAmmo;
            magazineSize -= maxAmmo;
        }
        else
        {
            currentAmmo = magazineSize;
            magazineSize = 0;
        }
        isReloading = false;
    }
}
