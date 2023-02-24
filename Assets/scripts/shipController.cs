using UnityEngine;

public class shipController : MonoBehaviour
{
    public GameObject ship;
    public GameObject flameLeft;
    public GameObject flameRight;
    public float speedPlus;
    public float speedMinus;
    public float multy1;
    public float multy2;
    Quaternion rotationShip;
  
    bool forSpeedPlus = true;
    bool forGetKeyPlus = true;

    bool forSpeedMinus = true;
    bool forGetKeyMinus = true;

    void Update()
    {
        if (Input.GetKey(KeyCode.D))
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
        if (Input.GetKeyUp(KeyCode.D))
        {
            forSpeedPlus = false;
            forGetKeyPlus = true;
        }
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
                forSpeedPlus = true;
                speedPlus = 0;
            }
        }
        /////////////////////////////////////////////////////////////////////////////////////////////
        if (Input.GetKey(KeyCode.A))
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
        if (Input.GetKeyUp(KeyCode.A))
        {
            forSpeedMinus = false;
            forGetKeyMinus = true;
        }
        if (forSpeedMinus == false)
        {
            speedMinus -= Time.deltaTime * multy2;
            transform.Rotate(Vector3.forward, -speedMinus * Time.deltaTime);
            if (speedMinus <= 0)
            {
                if (flameLeft != null)
                {
                    flameLeft.SetActive(true);
                }
                forSpeedMinus = true;
                speedMinus = 0;
            }
        }
    }
}
