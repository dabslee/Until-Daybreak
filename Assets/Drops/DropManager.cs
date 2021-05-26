using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class DropManager : MonoBehaviour
{
    public int period_mean; // period mean in seconds
    public int period_hrng; // period half-range in seconds
    public GameObject dropPrefab;

    private Stopwatch dropTimer;
    private int dropDelay;
    private System.Random randy;

    // Start is called before the first frame update
    void Start()
    {
        randy = new System.Random();
        dropTimer = Stopwatch.StartNew();
        dropDelay = randy.Next(period_mean-period_hrng, period_mean+period_hrng+1);
    }

    // Update is called once per frame
    void Update()
    {
        dropTimer.Stop();
        if (dropTimer.ElapsedMilliseconds >= dropDelay*1000) {
            Instantiate(dropPrefab, new Vector2(randy.Next(-70,70+1), 4), Quaternion.identity);
            dropTimer = Stopwatch.StartNew();
        } else {
            dropTimer.Start();
            dropDelay = randy.Next(period_mean-period_hrng, period_mean+period_hrng+1);
        }
    }
}
