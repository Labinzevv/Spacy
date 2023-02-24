using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class centerObj : MonoBehaviour //для вращения, движения, удаления объекта добавленного в Obj
{
    public GameObject Obj;

    Vector3 pointDead;
    public float speedObj = -15;
    float speed;

    void Start()
    {
        pointDead.z = -20;
        speed = Random.Range(spawnObj.speed1, spawnObj.speed2);
    }

    void Update()
    {
        transform.Rotate(Vector3.forward, speed * Time.deltaTime);
        transform.Translate(speedObj * transform.forward * Time.deltaTime);
        if (transform.position.z <= pointDead.z)
        {
            Destroy(Obj);
        }
    }
}
