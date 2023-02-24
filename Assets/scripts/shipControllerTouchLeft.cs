using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipControllerTouchLeft : MonoBehaviour
{
    public GameObject flameLeft;
    public float speedMinus;
    public float multy1;
    public float multy2;
    bool forSpeedMinus = true;
    bool forGetKeyMinus = true;
    bool forLeftButtonDown = true;
    bool forLeftButtonUp = true;

    void Update()
    {
        if (forLeftButtonDown == false)
        {
            if (forGetKeyMinus == true)
            {
                speedMinus = 0;
                forGetKeyMinus = false;
            }
            if (speedMinus < 250)
            {
                speedMinus += Time.deltaTime * multy1;
            }
            if (flameLeft != null)
            {
                flameLeft.SetActive(false);
            }
                
            transform.Rotate(Vector3.forward, -speedMinus * Time.deltaTime);
        }
        if (forLeftButtonUp == false)
        {
            forSpeedMinus = false;
            forGetKeyMinus = true;
            if (forSpeedMinus == false)
            {
                speedMinus -= Time.deltaTime * multy2;
                transform.Rotate(Vector3.forward, -speedMinus * Time.deltaTime);
            }
            if (speedMinus <= 0)
            {
                if (flameLeft != null)
                {
                    flameLeft.SetActive(true);
                }
                speedMinus = 0;
                forSpeedMinus = true;
                forLeftButtonUp = true;
            }
        }  
    }

    public void MoveLeftDown()
    {
        forLeftButtonDown = false;
        forLeftButtonUp = true;
    }
    public void MoveLeftUp()
    {
        forLeftButtonUp = false;
        forLeftButtonDown = true;
    }
}
