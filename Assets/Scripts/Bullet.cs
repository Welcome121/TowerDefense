using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    private GameObject enemyGameObject;

    public float speed = 80f;
    public float hitDamage = 25f;

    public GameObject hitEffect;

    public void Pursue(Transform _target, GameObject _enemyGameObject) {
        target = _target;
        enemyGameObject = _enemyGameObject;
    }

    private void HitTarget() 
    {
        GameObject effect = (GameObject)Instantiate(hitEffect, transform.position, transform.rotation);

        Enemy enemy = enemyGameObject.GetComponent<Enemy>();

        enemy.Hited(hitDamage);

        Destroy(effect, 2f);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null) {
            Destroy(gameObject);
            return;
        }

        Vector3 directionToEnemy = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(directionToEnemy.magnitude <= distanceThisFrame) {
            HitTarget();

            return;
        }

        transform.Translate(directionToEnemy.normalized * distanceThisFrame, Space.World);
    }
}
