using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    private GameObject turret;
    private Renderer rend;
    private Color startColor;

    public int turretCost = 100;
    public GameObject turretPrefab;
    public Color hoverColor;
    public Color notMoneyColor;


    void Start() 
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    void OnMouseDown() 
    {
        if(turret != null){
            Debug.Log("Can't build there!");
            return;
        }

        //Build a Turret
        if(PlayerStats.Money < turretCost) {
            rend.material.color = notMoneyColor;
            return;
        }

        Vector3 newPositionY = new Vector3(0, 0.56f, 0);
        turret = (GameObject)Instantiate(turretPrefab, transform.position + newPositionY, transform.rotation);

        PlayerStats.Money -= turretCost;
    }

    void OnMouseEnter() 
    {
        rend.material.color = hoverColor;
    }

    void OnMouseExit() 
    {
        rend.material.color = startColor;
    }
}
