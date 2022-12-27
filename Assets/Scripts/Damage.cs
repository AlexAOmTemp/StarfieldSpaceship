using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    // Start is called before the first frame update
    public float damage = 0.0f;
    public GameObject target;

    public void OnCollisionEnter(Collision collision)
    {
        //2 rigid body collision damage
        if (gameObject.TryGetComponent<Rigidbody>(out Rigidbody thisRB) && collision.gameObject.TryGetComponent<Rigidbody>(out Rigidbody targetRB))
        {   
            float totalMass = thisRB.mass + targetRB.mass;
            float totalDmg = collision.relativeVelocity.magnitude * (totalMass) / 2 / 100;
           
            if (gameObject.TryGetComponent<Health>(out Health thisHealth))
            {
                thisHealth.decrease(totalDmg * targetRB.mass / totalMass);
            }
            if (collision.gameObject.TryGetComponent<Health>(out Health targetHealth))
            {
                targetHealth.decrease(totalDmg * thisRB.mass / totalMass);
            }
            Debug.Log("collision between " + gameObject.name + " mass:" + thisRB.mass + " get:" + totalDmg * targetRB.mass / totalMass
                       + "\nand "+ collision.gameObject.name + " mass:" + targetRB.mass + " get:" + totalDmg * thisRB.mass / totalMass);
           

        }
        //bullet damage
        if (collision.gameObject.TryGetComponent<Health>(out Health tHealth)&& damage>0.001f )
        {
            tHealth.decrease(damage);
            Destroy(gameObject);
        }

    }
}
