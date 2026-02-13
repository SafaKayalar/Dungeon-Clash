using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeponAim : MonoBehaviour
{
    void Update()
    {
        // mouse world pozisyonunu al
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;

        // WeaponHolder -> mouse yonu
        Vector3 direction = mousePos - transform.position;

        // aci hesap
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // WeaponHolder döndur
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
