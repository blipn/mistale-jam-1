using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] private Transform enemiesSpawnPoint;
    [SerializeField] private Transform obstaclesSpawnPoint;
    
    [SerializeField] private List<GameObject> obstacles;
    [SerializeField] private List<GameObject> enemies;

    private float cd = 3f;

    private Transform randomSpawn;
    private List<GameObject>  randomListObstacle;
    
    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(SpawningManager());
    }

    IEnumerator SpawningManager()
    {
        yield return new WaitForSeconds(Mathf.Max(cd,1.5f));
        cd -= .1f;
        RandomList();
        
        
        GameObject go = randomListObstacle[Random.Range(0, randomListObstacle.Count)];
        Vector3 offset = new Vector3(0,go.GetComponent<SpriteRenderer>().bounds.size.y / 2,0);
        
        Instantiate(go, (randomSpawn.position + offset), Quaternion.identity);
        StartCoroutine(SpawningManager());
    }

    private void RandomList()
    {
        int choice = Random.Range(0, 2);
        switch (choice)
        {
            case 0:
                randomSpawn = obstaclesSpawnPoint;
                randomListObstacle = obstacles;
                break;
            case 1:
                randomSpawn = enemiesSpawnPoint;
                randomListObstacle = enemies;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
