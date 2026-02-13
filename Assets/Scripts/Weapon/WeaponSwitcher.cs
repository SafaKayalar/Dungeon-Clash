using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    int currentWeapon = -1; //-1 yazdim silahsiz baslasin diye knife ile baslamasi icin 0 yaz

    void Start()
    {
        SelectWeapon();
    }

    void Update()
    {
        // fare tekerlek ile silah deðiþtir
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            currentWeapon++;
            if (currentWeapon >= transform.childCount)
                currentWeapon = 0;

            SelectWeapon();
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            currentWeapon--;
            if (currentWeapon < 0)
                currentWeapon = transform.childCount - 1;

            SelectWeapon();
        }

        // klavye ile silahj secim
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentWeapon = 0; // knife
            SelectWeapon();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentWeapon = 1; // sSpear
            SelectWeapon();
        }
    }

    void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            weapon.gameObject.SetActive(i == currentWeapon);
            i++;
        }
    }
}
