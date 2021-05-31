using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardEnemyController : MonoBehaviour
{
    private Transform player_transform;

    private Animator m_animator;
    private Transform m_transform;
    private SpriteRenderer m_spriterenderer;

    public float speed;
    public float range;
    public int atk;
    public int hp;
    public float attackspeed;

    // Start is called before the first frame update
    void Start()
    {
        m_animator = GetComponent<Animator>();
        m_transform = GetComponent<Transform>();
        m_spriterenderer = GetComponent<SpriteRenderer>();
        GameObject player = GameObject.Find("Player");
        player_transform = player.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        // movement
        float diff = player_transform.position.x - m_transform.position.x;
        if (diff < 0) m_spriterenderer.flipX = true;
        else m_spriterenderer.flipX = false;

        if (Mathf.Abs(diff) < range) {
            m_animator.SetBool("attacking", true);
            m_animator.speed = attackspeed;
        } else {
            m_animator.SetBool("attacking", false);
            m_animator.speed = 1;
            m_transform.position = new Vector2(
                m_transform.position.x + (diff/Mathf.Abs(diff)) * speed * Time.deltaTime,
                m_transform.position.y);
        }
    }

}
