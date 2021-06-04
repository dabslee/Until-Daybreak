using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class StandardEnemyController : MonoBehaviour
{
    private Transform player_transform;
    private Player player_script;

    private Animator m_animator;
    private Transform m_transform;
    private SpriteRenderer m_spriterenderer;

    private Stopwatch atk_timer;

    public float speed;
    public float range;
    public int atk;
    public int hp;
    public float attackspeed;

    public Sprite attacked_form;

    // Start is called before the first frame update
    void Start()
    {
        hp += Random.Range(-1,1);
        m_animator = GetComponent<Animator>();
        m_transform = GetComponent<Transform>();
        m_spriterenderer = GetComponent<SpriteRenderer>();
        GameObject player = GameObject.Find("Player");
        player_transform = player.GetComponent<Transform>();
        player_script = player.GetComponent<Player>();
        atk_timer = Stopwatch.StartNew();
    }

    // Update is called once per frame
    void Update()
    {
        // direction
        float diff = player_transform.position.x - m_transform.position.x;
        if (diff < 0) m_spriterenderer.flipX = true;
        else m_spriterenderer.flipX = false;

        if (Mathf.Abs(diff) < range) { // attacking
            if (!m_animator.GetBool("attacking")) {
                m_animator.SetBool("attacking", true);
                player_script.health -= atk;
                atk_timer = Stopwatch.StartNew();
            }
            m_animator.speed = attackspeed;
            if (atk_timer.ElapsedMilliseconds > 2*100/attackspeed) {
                atk_timer = Stopwatch.StartNew();
                player_script.health -= atk;
            }
        } else { // movement
            m_animator.SetBool("attacking", false);
            m_animator.speed = 1;
            m_transform.position = new Vector2(
                m_transform.position.x + (diff/Mathf.Abs(diff)) * speed * Time.deltaTime,
                m_transform.position.y);
        }

        if (hp <= 0) {
            m_animator.SetTrigger("attacked");
            StartCoroutine(waitThenDie());
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "bullet") {
            m_animator.SetTrigger("attacked");
        }
    }

    IEnumerator waitThenDie() {
        yield return new WaitForSeconds(0.05f);
        player_script.killcount++;
        Destroy(gameObject);
    }
}
