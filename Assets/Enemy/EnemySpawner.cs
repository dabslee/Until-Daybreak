using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public System.Random randy;
    public GameObject StandardEnemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        randy = new System.Random();
        for (int i = 0; i < 3; i++) {
            Instantiate(StandardEnemyPrefab, new Vector2(randy.Next(-70,70+1), -1.15f), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
