using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoTextSetter : MonoBehaviour
{
    public GameObject player;
    private Player playerscript;
    private TextMeshProUGUI tmp;

    // Start is called before the first frame update
    void Start()
    {
        playerscript = player.GetComponent<Player>();
        tmp = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        int ammo = playerscript.ammo;
        tmp.SetText(ammo.ToString());
    }
}
