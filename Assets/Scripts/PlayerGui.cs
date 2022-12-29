using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGui : MonoBehaviour
{
    public GameObject player;
    private float playerMaxHP;
    private float playercurHP;
    private Health playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = player.GetComponent<Health>();
        playerMaxHP = playerHealth.Maximum;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
