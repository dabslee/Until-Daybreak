using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health = 100;
    public int ammo = 0;
    public int equippedDropIndex = 0;
    public int killcount = 0;

    private Stopwatch shootTimer;
    private float shootDelay = 100;
    public bool showGunShot = false;

    public GameObject dropAssetManager;
    private DropAssetManager assets;

    Rigidbody2D m_Rigidbody;
    SpriteRenderer mySpriteRenderer;
    public float m_Thrust;
    Animator anim;

    public GameObject bulletPrefab;

    public GameObject screenFlash;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        shootTimer = Stopwatch.StartNew();
        assets = dropAssetManager.GetComponent<DropAssetManager>();
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
        shootDelay = assets.period[equippedDropIndex];
        if (shootTimer.ElapsedMilliseconds < 50 && equippedDropIndex != 0) {
            showGunShot = true;
        } else {
            showGunShot = false;
        }
        if (Input.GetKey(KeyCode.Space)) {
            anim.SetBool("active", true);
            if (shootTimer.ElapsedMilliseconds > shootDelay) {
                Instantiate(bulletPrefab);
                ammo = Mathf.Max(0, ammo-1);
                shootTimer = Stopwatch.StartNew();
            }
        } else {
            anim.SetBool("active", false);
        }
        anim.SetInteger("equip index", equippedDropIndex);
    }
}
