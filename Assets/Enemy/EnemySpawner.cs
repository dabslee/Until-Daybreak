using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class EnemySpawner : MonoBehaviour
{
    public GameObject StandardEnemyPrefab;
    
    private Stopwatch timer;
    private int[] startchoices = {-70, 70};

    // Start is called before the first frame update
    void Start()
    {
        timer = Stopwatch.StartNew();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.ElapsedMilliseconds > 2000) {
            Instantiate(StandardEnemyPrefab, new Vector2(startchoices[Random.Range(0,2)], -1.15f), Quaternion.identity);
            timer = Stopwatch.StartNew();
        }
    }
}
