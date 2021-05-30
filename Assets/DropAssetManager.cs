﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropAssetManager : MonoBehaviour
{
    public string[] dropOptions =   {"machete", "assault",  "pistol",   "shotgun",  "sniper"};
    public int[] ammo =             {0,         70,         30,         8,          8}; // the ammo you get when you pick up a drop
    public int[] range =            {2,         8,          8,          5,          30}; // the range of the weapon
    public int[] damage =           {1,         1,          1,          4,          10}; // the damage that a weapon does to each target
    public int[] penetration =      {10,        1,          1,          10,         1}; // the max number of targets the weapon can hit
    public float[] speed =          {1f,        0.8f,       1f,         0.8f,       0.6f}; // the relative speed of the player while wielding the weapon
    public float[] period =         {500,       100,        500,        1000,       1000}; // the time between each shot in 100s of milliseconds

    public Sprite[] dropSpriteArray;
    public Sprite[] iconSpriteArray;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
