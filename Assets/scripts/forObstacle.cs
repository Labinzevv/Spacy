using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forObstacle : MonoBehaviour //для вращения, движения, удаления объекта добавленного в obstacle
{
    public GameObject obstacle;
    Vector3 pointDead;
    public float speedObstackle = -15;
    float speed;
  
    public

    void Start()
    {
        pointDead.z = -20;
        speed = Random.Range(spawnObj.speed1, spawnObj.speed2);
    }

    void Update()
    {
        transform.Rotate(Vector3.forward, speed * Time.deltaTime);
        transform.Translate(speedObstackle * transform.forward * Time.deltaTime);
        if (transform.position.z <= pointDead.z)
        {
            Destroy(obstacle);
        }
    }
}
