using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;
    private GameObject nearestEnemy = null;

    private float fireCountDown = 0;

    [Header("Attributes")]
    public float range = 15f;

    //bullets for second
    public float fireRate = 1f;

    [Header("Unity Setup Fields")]
    public string enemyTag = "Enemy";

    public GameObject bulletPrefab;

    public Transform pivot;
    public Transform firePoint;

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        float distanceToEnemy = 0f;
        float shortestDistance = Mathf.Infinity;

        foreach (var enemy in enemies)
        {
            distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if(distanceToEnemy < shortestDistance) {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            } 
        }

        if(nearestEnemy != null && shortestDistance <= range) { 
            target = nearestEnemy.transform; 

        }
        else { target = null; }
    }

    void Shoot()
    {
        GameObject bulletGameObject = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGameObject.GetComponent<Bullet>();

        if(bullet != null) { bullet.Pursue(target, nearestEnemy); }
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void Update() 
    {
        if(target == null) { return; }

        //Turret's head rotation to closest enemy position
        Vector3 direction = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = lookRotation.eulerAngles;

        pivot.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if(fireCountDown <= 0f) {
            Shoot();

            fireCountDown = 1f / fireRate;
        }

        fireCountDown -= Time.deltaTime;

        //bullets 

    }

    void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);    
    }
}