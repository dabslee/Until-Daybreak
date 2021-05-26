using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health = 100;
    public int equippedDropIndex = 0;

    Rigidbody2D m_Rigidbody;
    SpriteRenderer mySpriteRenderer;
    public float m_Thrust = 100f;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow)){
            m_Rigidbody.velocity = transform.right * m_Thrust;
            mySpriteRenderer.flipX = false;
        } else if (Input.GetKey(KeyCode.LeftArrow)){
            m_Rigidbody.velocity = -transform.right * m_Thrust;
            mySpriteRenderer.flipX = true;
        } else {
            m_Rigidbody.velocity *= 0.95f;
        }
        anim.SetFloat("speed", Mathf.Abs(m_Rigidbody.velocity.x));
    }
}
