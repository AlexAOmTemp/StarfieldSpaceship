using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineForce : MonoBehaviour
{
    public float ForceValue = 100f;
    private bool SwitchOn = false;
    private Rigidbody m_Rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = transform.parent.GetComponent<Rigidbody>();
        if (m_Rigidbody == null)
            Debug.Log("no rigidbody");
    }

    public void StartEngine()
    {
        SwitchOn = true;
    }
    public void StopEngine()
    {
        SwitchOn = false;
    }
    public bool GetEngineState()
    {
        return SwitchOn;
    }
    void FixedUpdate()
    {
        if (SwitchOn)
        {
            m_Rigidbody.AddForceAtPosition(transform.up * ForceValue * (-1), transform.position);
        }
    }
}
