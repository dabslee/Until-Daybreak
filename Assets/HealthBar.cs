using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private int health;
    public GameObject player;
    private Player playerscript;

    // Start is called before the first frame update
    void Start()
    {
        playerscript = player.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        int health = playerscript.health;
        Transform transform = GetComponent<Transform>();
        transform.localScale = new Vector3(health/100f * 10,10,1);
    }
}
