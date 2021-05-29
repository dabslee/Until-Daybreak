using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health = 100;
    public int killcount = 0;
    public int ammo = 0;
    public int equippedDropIndex = 0;

    private Stopwatch shootTimer;
    private float shootDelay = 100;

    Rigidbody2D m_Rigidbody;
    SpriteRenderer mySpriteRenderer;
    public float m_Thrust;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        shootTimer = Stopwatch.StartNew();
    }

    // Update is called once per frame
    void Update()
    {
        if (ammo <= 0) {
            ammo = 0;
            equippedDropIndex = 0;
        }
        if (Input.GetKey(KeyCode.RightArrow)){
            anim.SetBool("running", true);
            m_Rigidbody.velocity = transform.right * Mathf.Max(0, m_Rigidbody.velocity.x);
            m_Rigidbody.AddForce(transform.right * m_Thrust * Time.deltaTime);
            mySpriteRenderer.flipX = false;
        } else if (Input.GetKey(KeyCode.LeftArrow)){
            anim.SetBool("running", true);
            m_Rigidbody.velocity = transform.right * Mathf.Min(0, m_Rigidbody.velocity.x);
            m_Rigidbody.AddForce(-transform.right * m_Thrust * Time.deltaTime);
            mySpriteRenderer.flipX = true;
        } else {
            anim.SetBool("running", false);
            m_Rigidbody.velocity *= 0.8f;
        }
        if (Input.GetKey(KeyCode.Space)) {
            anim.SetBool("active", true);
            if (shootTimer.ElapsedMilliseconds > shootDelay) {
                ammo = Mathf.Max(0, ammo-1);
                shootTimer = Stopwatch.StartNew();
            }
        } else {
            anim.SetBool("active", false);
        }
        anim.SetInteger("equip index", equippedDropIndex);
    }
}
