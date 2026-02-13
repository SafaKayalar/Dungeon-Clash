using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeSwing : MonoBehaviour
{
    public float swingAngle = 90f;
    public float swingDuration = 0.2f;

    public GameObject hitbox;

    bool swinging = false;

    void Start()
    {
        hitbox.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !swinging)
        {
            StartCoroutine(Swing());
        }
    }

    IEnumerator Swing()
    {
        swinging = true;
        hitbox.SetActive(true);

        float half = swingAngle / 2f;
        float time = 0;

        while (time < swingDuration)
        {
            time += Time.deltaTime;
            float t = time / swingDuration;

            float angle = Mathf.Lerp(-half, half, t);
            transform.localRotation = Quaternion.Euler(0, 0, angle);

            yield return null;
        }

        transform.localRotation = Quaternion.identity;
        hitbox.SetActive(false);
        swinging = false;
    }
}
