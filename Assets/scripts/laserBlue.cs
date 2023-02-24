using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class laserBlue : MonoBehaviour // для левого лазера
{
    public GameObject rayStartPoint;
    LineRenderer lrBlue;

    public Image barLeft;
    public float shootBlue = 1;
    public float timer = 0.3f;
    bool forRay = true;
    public shipDamageAndScore score;

    void Start()
    {
        lrBlue = GetComponent<LineRenderer>();
        lrBlue.SetPosition(0, rayStartPoint.transform.position);
        lrBlue.SetPosition(1, rayStartPoint.transform.position);
    }

    void Update()
    {
        barLeft.fillAmount = shootBlue;

        if (Input.GetKeyDown(KeyCode.O))
        {
            if (shootBlue > 0)
            {
                forRay = false;
                shootBlue -= 0.08f;
            }
        }

        if (Input.GetKeyUp(KeyCode.O))
        {
            forRay = true;
            timer = 0.3f;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        if (forRay == false)
        {
            timer -= Time.deltaTime;
            if (timer > 0)
            {
                Ray ray = new Ray(rayStartPoint.transform.position, rayStartPoint.transform.forward);
                RaycastHit hit;
                lrBlue.SetPosition(0, ray.origin);
                if (Physics.Raycast(ray, out hit))
                {
                    lrBlue.SetPosition(1, hit.point);

                    if (hit.collider.tag == "stone")
                    {
                        score.score += 5;
                        Destroy(hit.collider.gameObject);
                    }
                }
                else lrBlue.SetPosition(1, ray.GetPoint(160));
            }

            if (timer < 0)
            {
                forRay = true;
                timer = 0.3f;
            }
        }

        if (forRay == true)
        {
            lrBlue.SetPosition(0, rayStartPoint.transform.position);
            lrBlue.SetPosition(1, rayStartPoint.transform.position);
        }
    }

    public void LaserOn()
    {
        if (shootBlue > 0)
        {
            forRay = false;
            shootBlue -= 0.08f;
        }
    }
    public void LaserOff()
    {
        forRay = true;
        timer = 0.3f;
    }
}
