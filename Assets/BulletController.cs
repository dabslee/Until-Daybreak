using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private int type;

    private Transform m_transform;

    public GameObject dropAssetManager;
    private DropAssetManager assets;

    public GameObject player;
    private Player playerscript;
    private SpriteRenderer player_sprite_renderer;

    private Vector2 initPosition;
    private int penetration_hp;

    void Start()
    {
        // get references
        player = GameObject.Find("Player");
        playerscript = player.GetComponent<Player>();
        player_sprite_renderer = player.GetComponent<SpriteRenderer>();
        assets = dropAssetManager.GetComponent<DropAssetManager>();
        m_transform = GetComponent<Transform>();

        // set bullet type
        type = playerscript.equippedDropIndex;

        // set initial position
        m_transform.position = new Vector2(
            player.GetComponent<Transform>().position.x + assets.gunShotX[type],
            player.GetComponent<Transform>().position.y + assets.gunShotY[type]);
        initPosition = m_transform.position;
        
        GetComponent<Rigidbody2D>().velocity = transform.right * 100 * (player_sprite_renderer.flipX ? -1 : 1);
        penetration_hp = assets.penetration[type];
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(m_transform.position.x - initPosition.x) > assets.range[type]) {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Enemy") {
            other.gameObject.GetComponent<StandardEnemyController>().hp -= assets.damage[type];
            penetration_hp--;
            if (penetration_hp <= 0) Destroy(gameObject);
        }
    }
}
