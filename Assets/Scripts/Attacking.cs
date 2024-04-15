using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Attacking : MonoBehaviour
{
    public LayerMask collisionLayer;
    public float radius = 1f;
    public float damage = 2f;

    public GameObject hit_FX;

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
        }

        gameObject.SetActive(false);
    }
}
