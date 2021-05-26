using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    Transform target;
    Transform self;
    float originalx;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player").GetComponent<Transform>();
        self = GetComponent<Transform>();
        originalx = self.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(originalx + target.position.x, self.position.y, self.position.z);
    }
}
