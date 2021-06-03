using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropAssetManager : MonoBehaviour
{
    public string[] dropOptions =   {"machete", "assault",  "pistol",   "shotgun",  "sniper"};
    public int[] ammo; // the ammo you get when you pick up a drop
    public int[] range; // the range of the weapon
    public int[] damage; // the damage that a weapon does to each target
    public int[] penetration; // the max number of targets the weapon can hit
    public float[] speed; // the relative speed of the player while wielding the weapon
    public float[] period; // the time between each shot in 100s of milliseconds
    public float[] knockback; // the time between each shot in 100s of milliseconds

    public Sprite[] dropSpriteArray;
    public Sprite[] iconSpriteArray;

    public float[] gunShotX;
    public float[] gunShotY;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
