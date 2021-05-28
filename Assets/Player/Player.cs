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
            weaponActive = false;
            m_Rigidbody.velocity = transform.right * m_Thrust;
            mySpriteRenderer.flipX = false;
        } else if (Input.GetKey(KeyCode.LeftArrow)){
            weaponActive = false;
            m_Rigidbody.velocity = -transform.right * m_Thrust;
            mySpriteRenderer.flipX = true;
        } else {
            if (Input.GetKey(KeyCode.Space)) {
                weaponActive = true;
            } else {
                weaponActive = false;
            }
            m_Rigidbody.velocity *= 0.95f;
        }
        anim.SetFloat("speed", Mathf.Abs(m_Rigidbody.velocity.x));
        anim.SetInteger("equip index", equippedDropIndex);
        anim.SetBool("active", weaponActive);
    }
}
