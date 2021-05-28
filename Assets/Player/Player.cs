using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health = 100;
    public int equippedDropIndex = 0;
    public bool weaponActive = false;

    Rigidbody2D m_Rigidbody;
    SpriteRenderer mySpriteRenderer;
    public float m_Thrust = 50f;
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
            anim.SetBool("running", true);
            weaponActive = false;
            m_Rigidbody.velocity = transform.right * Mathf.Max(0, m_Rigidbody.velocity.x);
            m_Rigidbody.AddForce(transform.right * m_Thrust);
            mySpriteRenderer.flipX = false;
        } else if (Input.GetKey(KeyCode.LeftArrow)){
            anim.SetBool("running", true);
            weaponActive = false;
            m_Rigidbody.velocity = transform.right * Mathf.Min(0, m_Rigidbody.velocity.x);
            m_Rigidbody.AddForce(-transform.right * m_Thrust);
            mySpriteRenderer.flipX = true;
        } else {
            anim.SetBool("running", false);
            if (Input.GetKey(KeyCode.Space)) {
                weaponActive = true;
            } else {
                weaponActive = false;
            }
            m_Rigidbody.velocity *= 0.8f;
        }
        anim.SetInteger("equip index", equippedDropIndex);
        anim.SetBool("active", weaponActive);
    }
}
