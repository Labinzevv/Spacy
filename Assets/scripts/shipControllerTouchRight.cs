using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipControllerTouchRight : MonoBehaviour
{
    public GameObject flameRight;
    public float speedPlus;
    public float multy1;
    public float multy2;
    bool forSpeedPlus = true;
    bool forGetKeyPlus = true;
    bool forRightButtonUp = true;
    bool forRightButtonDown = true;

    void Update()
    {
        if (forRightButtonDown == false)
        {
            if (forGetKeyPlus == true)
            {
                speedPlus = 0;
                forGetKeyPlus = false;
            }
            if (speedPlus < 250)
            {
                speedPlus += Time.deltaTime * multy1;
            }
            if (flameRight != null)
            {
                flameRight.SetActive(false);
            }
          
            transform.Rotate(Vector3.forward, speedPlus * Time.deltaTime);
        }

        if (forRightButtonUp == false)
        {
            forSpeedPlus = false;
            forGetKeyPlus = true;
            if (forSpeedPlus == false)
            {
                speedPlus -= Time.deltaTime * multy2;
                transform.Rotate(Vector3.forward, speedPlus * Time.deltaTime);
                if (speedPlus <= 0)
                {
                    if (flameRight != null)
                    {
                        flameRight.SetActive(true);
                    }
                    speedPlus = 0;
                    forSpeedPlus = true;
                    forRightButtonUp = true;
                }
            }
        }
    }
  
    public void MoveRightDown()
    {
        forRightButtonDown = false;
        forRightButtonUp = true;
    }
    public void MoveRightUp()
    {
        forRightButtonUp = false;
        forRightButtonDown = true;
    }
}
