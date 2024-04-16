using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.SceneManagement;

public class PlayerLife : NetworkBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] public float P1;
    [SerializeField] public float P2;
    public HealthBar healthBar ;
    public HealthBar healthBar2 ;
    public bool dead = false;

    private CharacterAnimation animationScript;

    void Awake()
    {
        animationScript = GetComponent<CharacterAnimation>();
    }
    private void Start()
    {
        healthBar = GameObject.Find("HealthBar").GetComponent<HealthBar>();
        P1 = maxHealth;
        healthBar.SetSliderMax(maxHealth);

        healthBar2 = GameObject.Find("HealthBar2").GetComponent<HealthBar>();
        P2 = maxHealth;
        healthBar2.SetSliderMax(maxHealth);
    }
    void Update()
    {
        if(!IsOwner) return;
    }

    public void ApplyDamage(float damage)
    {
       if(IsOwner)
        {
                if(NetworkObjectId == 1)
                {
                    P2 -= damage;
                    healthBar2.SetSlider(P2);
                    DamageClientRPC(damage);
                    print("[h1]NAME:" + gameObject.name + " P1: " + P1 + " P2: " + P2);

                    if(P2 <= 0 ) 
                    {
                        dead = true;
                        gameObject.GetComponent<PlayerMovement>().AnimateVictory();
                        DeathClientRPC();
                    }
                }

                if(NetworkObjectId == 2)
                {
                    P1 -= damage;
                    healthBar.SetSlider(P1);
                    Damage2ServerRPC(damage);
                    print("[h1]NAME:" + gameObject.name + " P1: " + P1 + " P2: " + P2);

                    if(P1 <= 0 )
                    {
                        dead = true;
                        gameObject.GetComponent<PlayerMovement>().AnimateVictory();
                        DeathServerRPC();
                    }
                }
        }

        if(!IsOwner)
        {
            if(P2 <= 0 && NetworkObjectId == 1)
                    {
                        dead = true;
                        gameObject.GetComponent<PlayerMovement>().AnimateDeath();
                        //DeathClientRPC();
                    }
            if(P1 <= 0 && NetworkObjectId == 2)
                    {
                        dead = true;
                        gameObject.GetComponent<PlayerMovement>().AnimateVictory();
                        //DeathServerRPC();
                    }
        }
    }

    [ClientRpc]
    public void DamageClientRPC(float damage)
    {
        if(!IsOwner)
        {
            P2 -= damage;
            healthBar2.SetSlider(P2);
                
            print("[r1]NAME:" + gameObject.name + " curr: " + P1 + " enem " + P2);
        } 
    }

    [ServerRpc]
    public void Damage2ServerRPC(float damage)
    {
        if(!IsOwner)
        {
            P1 -= damage;
            healthBar.SetSlider(P1);
                
            print("[r2]NAME:" + gameObject.name + " curr: " + P1 + " enem " + P2);
        } 
    }

    [ClientRpc]
    public void DeathClientRPC()
    {
        if(!IsOwner)
        {
            gameObject.GetComponent<PlayerMovement>().AnimateDeath();
        } 
    }

    [ServerRpc]
    public void DeathServerRPC()
    {
        if(!IsOwner)
        {
            gameObject.GetComponent<PlayerMovement>().AnimateDeath();
        } 
    }

    
}