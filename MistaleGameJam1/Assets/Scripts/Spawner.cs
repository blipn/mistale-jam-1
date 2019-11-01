using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> obstacles;

    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(SpawningManager());
    }

    IEnumerator SpawningManager()
    {
        yield return new WaitForSeconds(1f);
        Instantiate(obstacles[Random.Range(0,obstacles.Count)], transform.position, Quaternion.identity);
        StartCoroutine(SpawningManager());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
