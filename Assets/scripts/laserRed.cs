using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class laserRed : MonoBehaviour //для правого лазера
{
    public GameObject rayStartPoint;
    LineRenderer lrRed;

    public Image barRight;
    public float shootRed = 1;
    public float timer = 0.3f;
    bool forRay = true;
    public shipDamageAndScore score;

    void Start()
    {
        lrRed = GetComponent<LineRenderer>();
        lrRed.SetPosition(0, rayStartPoint.transform.position);
        lrRed.SetPosition(1, rayStartPoint.transform.position);
    }

    void Update()
    {
        barRight.fillAmount = shootRed;

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (shootRed > 0)
            {
                forRay = false;
                shootRed -= 0.25f;
            }
        }
        if (Input.GetKeyUp(KeyCode.P))
        {
            forRay = true;
            timer = 0.3f;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        if (forRay == false)
        {
            timer -= Time.deltaTime;
            if (timer > 0)
            {
                Ray ray = new Ray(rayStartPoint.transform.position, rayStartPoint.transform.forward);
                RaycastHit hit;
                lrRed.SetPosition(0, ray.origin);
                if (Physics.Raycast(ray, out hit))
                {
                    lrRed.SetPosition(1, hit.point);

                    if (hit.collider.tag == "obstacle")
                    {
                        score.score += 10;
                        Destroy(hit.collider.gameObject);
                    }
                    if (hit.collider.tag == "stone")
                    {
                        score.score += 5;
                        Destroy(hit.collider.gameObject);
                    }
                }
                else lrRed.SetPosition(1, ray.GetPoint(160));
            }

            if (timer < 0)
            {
                forRay = true;
                timer = 0.3f;
            }
        }

        if (forRay == true)
        {
            lrRed.SetPosition(0, rayStartPoint.transform.position);
            lrRed.SetPosition(1, rayStartPoint.transform.position);
        }
    }

    public void LaserOn()
    {
        if (shootRed > 0)
        {
            forRay = false;
            shootRed -= 0.25f;
        }
    }
    public void LaserOff()
    {
        forRay = true;
        timer = 0.3f;
    }
}
