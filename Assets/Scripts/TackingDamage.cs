using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class TackingDamage : MonoBehaviour
{

    public float health;

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [PunRPC]
    public void TakeDamage(float _damage)
    {
        health -= _damage;
        Debug.Log(health);
    }
}
