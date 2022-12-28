using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public GameObject ExplosionPrefab;
    public float HP = 50.0f;
    public float HPRegen = 0.0f;
    private float CurrentHP = 0.0f;
    private GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {

        if (CurrentHP < 0.01f)
            CurrentHP = HP;
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentHP < HP)
            CurrentHP += HPRegen * Time.deltaTime;
    }
    public void decrease(float value)
    {
        CurrentHP -= value;
        if (CurrentHP <= 0)
        {
            Debug.Log("object destroyed" + gameObject.name);
            GameObject explosion = Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
            explosion.transform.localScale*= 0.8f * Tools.GetMaxSizeParameterOfGameObjectByCollider(gameObject);
            Destroy(explosion, 2);
            Destroy(gameObject);

        }

    }
    public void increase(float value)
    {
        CurrentHP += value;
        Debug.Log("Current health " + CurrentHP.ToString());
        if (CurrentHP >= HP)
            CurrentHP = HP;
    }
    public void increaseMaximum(float value)
    {
        HP += value;
    }
    public void decreaseMaximum(float value)
    {
        HP -= value;
        if (HP <= 0)
            Destroy(gameObject);
    }
    public void setMaximum(float value)
    {
        if (value > 0)
        {
            HP = value;
            CurrentHP = value;
        }
    }
}
  
