using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform projectileSpawn;
    public float projectileSpeed = 30f;
    public float lifeTime = 3f;
    private IEnumerator coroutine;
    private Transform Weapon;
    private Rigidbody ShipRb;
    private Rigidbody projectileRB;
    void Start()
    {
        Weapon = projectileSpawn.parent;
        ShipRb = Weapon.parent.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }
    void OnGUI()
    {
        GUI.Label(new Rect(0, 0, 1000, 100), "Weapon: " + ShipRb.velocity.ToString());
        //GUI.Label(new Rect(0, 10, 1000, 100), "velocity: " + projectileRB.velocity.ToString());
        GUI.Label(new Rect(0, 20, 1000, 100), "Speed: " + ShipRb.velocity.magnitude.ToString());
        //GUI.Label(new Rect(0, 30, 1000, 100), "rotation: " + transform.rotation.ToString());
        //
    }
    private void Fire()
    {
        GameObject projectile = Instantiate(projectilePrefab, projectileSpawn.transform.position, projectileSpawn.transform.rotation);
        Physics.IgnoreCollision(projectile.GetComponent<Collider>(), Weapon.GetComponent<Collider>());
        projectileRB = projectile.GetComponent<Rigidbody>();

        // projectile.transform.position = projectileSpawn.position;

        // Vector3 rotation = projectile.transform.rotation.eulerAngles;
        // projectile.transform.rotation = Quaternion.Euler(rotation.x, transform.eulerAngles.y, rotation.z);
        projectileRB.velocity = ShipRb.velocity;
        projectileRB.AddForce(projectileSpawn.up * projectileSpeed, ForceMode.Impulse);

        coroutine = DestroyProjectile(projectile, lifeTime);
        StartCoroutine(coroutine);
    }

    private IEnumerator DestroyProjectile(GameObject projectile, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(projectile);
    }

}
