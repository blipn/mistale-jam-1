using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] private Transform obstaclesThatYouMustCrouchSpawnPoint;
    [SerializeField] private Transform enemiesSpawnPoint;
    [SerializeField] private Transform obstaclesSpawnPoint;
    
    [SerializeField] private List<GameObject> obstacles;
    [SerializeField] private List<GameObject> enemies;
    [SerializeField] private List<GameObject> obstaclesThatYouMustCrouch;

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
        Instantiate(obstacles[Random.Range(0,randomListObstacle.Count)], randomSpawn.position, Quaternion.identity);
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
            case 2:
                randomSpawn = obstaclesThatYouMustCrouchSpawnPoint;
                randomListObstacle = obstaclesThatYouMustCrouch;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
