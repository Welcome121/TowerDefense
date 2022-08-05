using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{   
    public GameObject ripEffect;
    public int killPrice = 20;

    private float life = 100f;
    private UnityEngine.AI.NavMeshAgent enemy;
    private GameObject enemyGoal;

    public void Hited(float bulletDamage) {
        life -= bulletDamage;

        if(life <= 0) {
            Rip();

            PlayerStats.Money += killPrice;
        }
    }

    void Rip() { 
        GameObject effect = (GameObject)Instantiate(ripEffect, transform.position, transform.rotation);

        Destroy(gameObject);
        Destroy(effect, 1f);
    }

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<UnityEngine.AI.NavMeshAgent>();
        enemyGoal = GameObject.Find("EnemyGoal");

        enemy.SetDestination(enemyGoal.transform.position);
        Debug.Log(enemy.transform.position);
    }
}
