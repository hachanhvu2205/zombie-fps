using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField]GameObject carbine;
    [SerializeField]GameObject shotgun;
    [SerializeField]GameObject pistol;

    void Update() {
        if(Input.GetKeyDown(KeyCode.Alpha1)) {
            carbine.SetActive(true);
            shotgun.SetActive(false);
            pistol.SetActive(false);
        }
        if(Input.GetKeyDown(KeyCode.Alpha2)) {
            carbine.SetActive(false);
            shotgun.SetActive(true);
            pistol.SetActive(false);
        }
        if(Input.GetKeyDown(KeyCode.Alpha3)) {
            carbine.SetActive(false);
            shotgun.SetActive(false);
            pistol.SetActive(true);
        }
    }
}
