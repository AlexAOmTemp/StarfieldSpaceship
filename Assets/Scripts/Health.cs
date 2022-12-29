using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public GameObject ExplosionPrefab;
    [SerializeField]
    private float maximum = 50f;
    [SerializeField]
    private float Current = 0.0f;

    public float Maximum
    {
        get => maximum;    // get method
        set
        {
            if (value > 0)
            {
                maximum = value;
                Current = value;
            }
        }  // set method
    }
    public float Regen = 0.0f;
    private GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {

        if (Current < 0.01f)
            Current = Maximum;
    }

    // Update is called once per frame
    void Update()
    {
        if (Current < Maximum)
            Current += Regen * Time.deltaTime;
    }
    public void decrease(float value)
    {
        Current -= value;
        if (Current <= 0)
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
        Current += value;
        Debug.Log("Current health " + Current.ToString());
        if (Current >= Maximum)
            Current = Maximum;
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
}
  
