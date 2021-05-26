using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponIconController : MonoBehaviour
{
    public GameObject DropAssetManager;
    public GameObject player;

    private DropAssetManager assets;
    private Player playerscript;

    // Start is called before the first frame update
    void Start()
    {
        assets = DropAssetManager.GetComponent<DropAssetManager>();
        playerscript = player.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<SpriteRenderer>().sprite = assets.iconSpriteArray[playerscript.equippedDropIndex];
    }
}
