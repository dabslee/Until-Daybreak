using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShotConroller : MonoBehaviour
{
    public float[] gunShotX;
    public float[] gunShotY;
    public Sprite showing;
    public Sprite hiding;

    public GameObject player;
    private Player playerscript;
    private SpriteRenderer p_s_renderer;
    
    private SpriteRenderer s_renderer;

    public GameObject dropAssetManager;
    private DropAssetManager assets;

    // Start is called before the first frame update
    void Start()
    {
        playerscript = player.GetComponent<Player>();
        assets = dropAssetManager.GetComponent<DropAssetManager>();
        s_renderer = GetComponent<SpriteRenderer>();
        p_s_renderer = player.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerscript.showGunShot) {
            s_renderer.sprite = showing;
            GetComponent<Transform>().localPosition = new Vector2(
                (p_s_renderer.flipX ? -1 : 1) * gunShotX[playerscript.equippedDropIndex],
                gunShotY[playerscript.equippedDropIndex]);
            s_renderer.flipX = p_s_renderer.flipX;
        } else {
            s_renderer.sprite = hiding;
        }
    }
}
