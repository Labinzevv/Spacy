using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forObjDestroy : MonoBehaviour //для уничтожения объекта при столкновении с кораблем (скрипт висит на СИСТЕМАХ ЧАСТИЦ внутри ПРЕФАБОВ БОНУСОВ)
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

