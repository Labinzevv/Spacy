using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forObjDestroy : MonoBehaviour //��� ����������� ������� ��� ������������ � �������� (������ ����� �� �������� ������ ������ �������� �������)
{
    public GameObject obj;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ship")
        {
            Destroy(obj);
        }
    }
}

