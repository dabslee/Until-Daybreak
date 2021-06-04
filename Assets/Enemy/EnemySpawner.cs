using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class EnemySpawner : MonoBehaviour
{
    public GameObject StandardEnemyPrefab;
    public int initialDelay;
    public int delayHalfLife;
    public int baseDelay;
    
    private Stopwatch timer;
    private long lastTime;
    private int[] startchoices = {-100, 100};

    // Start is called before the first frame update
    void Start()
    {
        timer = Stopwatch.StartNew();
        lastTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float delayTime = initialDelay*Mathf.Exp(-Mathf.Log(2)/delayHalfLife*timer.ElapsedMilliseconds)+baseDelay; // initial delay is 2s, decreases with half-life 30s, add delay to base delay of 0.5s
        if (timer.ElapsedMilliseconds - lastTime > delayTime) {
            Instantiate(StandardEnemyPrefab, new Vector2(startchoices[Random.Range(0,2)], -1.15f), Quaternion.identity);
            lastTime = timer.ElapsedMilliseconds;
        }
    }
}
