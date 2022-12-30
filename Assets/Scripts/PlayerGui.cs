using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGui : MonoBehaviour
{
    public GameObject Player;
    public GameObject _HealthBar;
    private Health playerHealth;
    private HealthBar HBarScript;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = Player.GetComponent<Health>();
        HBarScript = _HealthBar.GetComponent<HealthBar>();
        HBarScript.Maximum = playerHealth.Maximum;
        HBarScript.Current = playerHealth.Current;
    }

    // Update is called once per frame
    void Update()
    {
        HBarScript.Maximum = playerHealth.Maximum;
        HBarScript.Current = playerHealth.Current;
    }
}
