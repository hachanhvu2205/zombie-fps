using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Weapon : MonoBehaviour
{
    [SerializeField]Camera FPSCam;
    [SerializeField]float range = 100f;
    [SerializeField]float damage = 25f;
    [SerializeField]ParticleSystem muzzleFlash;
    [SerializeField]GameObject hitEffect;
    [SerializeField]Ammo ammoSlot;
    [SerializeField]AmmoType ammoType;
    [SerializeField]float timeBetweenShots = 0.5f;
    [SerializeField]TextMeshProUGUI ammoText;
    bool canShoot = true;

    void OnEnable() {
        canShoot = true;
    }

    void Update()
    {
        DisplayAmmo();
        if(Input.GetButton("Fire1") && canShoot) {
            StartCoroutine(Shoot());
        }
    }

    void DisplayAmmo() {
        int currentAmmo = ammoSlot.GetCurrentAmmo(ammoType);
        ammoText.text = "AMMO: " + currentAmmo.ToString();
    }

    IEnumerator Shoot() {
        canShoot = false;
        if(ammoSlot.GetCurrentAmmo(ammoType) > 0) {
            PlayMuzzleFlash();
            ammoSlot.ReduceAmmo(ammoType);
            ProcessRaycast();
        }
        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;
    }

    void ProcessRaycast() {
        RaycastHit hit;
        if(Physics.Raycast(FPSCam.transform.position, FPSCam.transform.forward, out hit, range)) {
            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if(target == null) return;
            target.TakeDamage(damage);
        }
        else return;
    }

    void PlayMuzzleFlash() {
        muzzleFlash.Play();
    }

    void CreateHitImpact(RaycastHit hit) {
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 1f);
    }
}
