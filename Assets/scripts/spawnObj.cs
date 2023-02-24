using System.Collections;
using UnityEngine;

public class spawnObj: MonoBehaviour
{
    public GameObject[] obstacles;
    public GameObject[] stones;
    public GameObject[] bonuses;
    Vector3 pointSpawnObstacles;
    Vector3 pointSpawnBonuses;
    Vector3 pointSpawnStones;
    Quaternion rotationSpawn;
    public float timeSpawnObstacles = 5;
    public float timeSpawnBonuses = 7;
    public float timeSpawnStones = 1.5f;

    public static float speed1 = -1;
    public static float speed2 = 1;

    void Start()
    {
        pointSpawnObstacles = new Vector3(transform.position.x, transform.position.y, 100);
        pointSpawnBonuses = new Vector3(transform.position.x, transform.position.y, 130);
        pointSpawnStones = new Vector3(transform.position.x, transform.position.y, 150);

        StartCoroutine(SpawnerObstacles());
        StartCoroutine(SpawnerBonuses());
        StartCoroutine(SpawnerStones());
    }

    void Update()
    {
        if (speed1 > - 100)
        {
            speed1 -= Time.deltaTime;
        }

        if (speed2 < 100)
        {
            speed2 += Time.deltaTime;
        }

        if (timeSpawnObstacles > 1.5f)
        {
            timeSpawnObstacles -= Time.deltaTime/50;
        }
        if (timeSpawnBonuses > 1.5f)
        {
            timeSpawnBonuses -= Time.deltaTime / 50;
        }
    }

    void RepeatObstacles()
    {
        StartCoroutine(SpawnerObstacles());
      
    }
    void RepeatBonuses()
    {
        StartCoroutine(SpawnerBonuses());
    }
    void RepeatStones()
    {
        StartCoroutine(SpawnerStones());
    }

    IEnumerator SpawnerObstacles()
    {
        yield return new WaitForSeconds(timeSpawnObstacles);

        float rotate = Random.Range(0f, 360f);
        rotationSpawn = Quaternion.Euler(0, 0, rotate);

        int spawnObstacle = Random.Range(0, obstacles.Length - 1);
        Instantiate(obstacles[spawnObstacle], pointSpawnObstacles, rotationSpawn);

        RepeatObstacles();
    }
    IEnumerator SpawnerBonuses()
    {
        yield return new WaitForSeconds(timeSpawnBonuses);

        float rotate = Random.Range(0f, 360f);
        rotationSpawn = Quaternion.Euler(0, 0, rotate);

        int spawnBonuses = Random.Range(0, bonuses.Length - 1);
        Instantiate(bonuses[spawnBonuses], pointSpawnBonuses, rotationSpawn);

        RepeatBonuses();
    }
    IEnumerator SpawnerStones()
    {
        yield return new WaitForSeconds(timeSpawnStones);

        float rotate = Random.Range(0f, 360f);
        rotationSpawn = Quaternion.Euler(0, 0, rotate);

        int spawnStones = Random.Range(0, stones.Length - 1);
        Instantiate(stones[spawnStones], pointSpawnStones, rotationSpawn);

        RepeatStones();
    }
}
