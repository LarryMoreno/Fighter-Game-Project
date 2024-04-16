using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEditor;
using UnityEngine;

public class Attacking : MonoBehaviour
{
    public LayerMask collisionLayer;
    public float radius = 1f;
    public float damage = 20f;

    public GameObject hit_FX;

    [SerializeField] public GameObject player;

    void Start()
    {
        if(player.layer == 8)
        {
            //int pLay = LayerMask.NameToLayer("Player");
            int one = LayerMask.GetMask("Player");
            collisionLayer = one;
        }
        else if (player.layer == 7)
        {
            int two = LayerMask.GetMask("Player2");
            collisionLayer = two;
        }

        //Debug.Log("Name: " + player.name + " Layer: " + player.layer );
    }
    
    void Update()
    {
        DetectCollision();
    }

    void DetectCollision()
    {
        Collider[] hit = Physics.OverlapSphere(transform.position, radius, collisionLayer);

        if(hit.Length > 0)
        {
            print("Hit " + hit[0].gameObject.name);

            if(gameObject.CompareTag(Tags.LEFT_ARM_TAG) ||
            gameObject.CompareTag(Tags.RIGHT_ARM_TAG) ||
            gameObject.CompareTag(Tags.LEFT_LEG_TAG) ||
            gameObject.CompareTag(Tags.RIGHT_LEG_TAG))
            {
                player.GetComponent<PlayerLife>().ApplyDamage(damage);
            }

        gameObject.SetActive(false);
        }
    }

}
