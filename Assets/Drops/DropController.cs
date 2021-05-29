using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropController : MonoBehaviour
{
    private int dropType;
    private System.Random randy;
    public GameObject DropAssetManager;
    public GameObject Player;

    private Player playerscript;
    private DropAssetManager assets;
    
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        playerscript = Player.GetComponent<Player>();
        assets = DropAssetManager.GetComponent<DropAssetManager>();
        randy = new System.Random();
        dropType = randy.Next(1, assets.dropOptions.Length); // excluding machete
        GetComponent<SpriteRenderer>().sprite = assets.dropSpriteArray[dropType];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (other.tag == "Player" && Input.GetKey(KeyCode.DownArrow)) {
            playerscript.equippedDropIndex = dropType;
            playerscript.ammo = assets.ammo[dropType];
            Destroy(gameObject);
        }
    }
}
