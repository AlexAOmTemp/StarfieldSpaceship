using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public GameObject ExplosionPrefab;
    [SerializeField]
    private float maximum = 50f;
    [SerializeField]
    private float current = 0.0f;

    public float Current 
    {
        get => current;
        set {
            current = value;
            if (current <= 0)
            {
                ObjectDeath();
            }
            if (current >= Maximum)
                current = Maximum;
        }
    }


    public float Maximum
    {
        get => maximum;    
        set
        {
            if (value > 0)
            {
                maximum = value;
                Current = value;
            }
            else
                ObjectDeath();
        } 
    }
    public float Regen = 0.0f;
    private GameObject explosion;
    

    void Start()
    {

        if (Current < 0.01f)
            Current = Maximum;
    }

  
    void Update()
    {
        if (Current < Maximum)
            Current += Regen * Time.deltaTime;
    }
    public void decrease(float value)
    {
        Current -= value;
    }
    public void increase(float value)
    {
        Current += value;
    }
    public void increaseMaximum(float value)
    {
        Maximum += value;
    }
    public void decreaseMaximum(float value)
    {
        Maximum -= value;
        if (Maximum <= 0)
            Destroy(gameObject);
    }
   
    private void ObjectDeath()
    //should be rework later
    {
        GameObject explosion = Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
        explosion.transform.localScale *= 0.8f * Tools.GetMaxSizeParameterOfGameObjectByCollider(gameObject);
        Destroy(explosion, 2);
        Destroy(gameObject);
    }
}
  
