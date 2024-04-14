using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.SceneManagement;

public class PlayerLife : NetworkBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;
    public HealthBar healthBar ;
    public HealthBar healthBar2 ;
    bool dead = false;

    private void Start()
    {
        healthBar = GameObject.Find("HealthBar").GetComponent<HealthBar>();
        currentHealth = maxHealth;
        healthBar.SetSliderMax(maxHealth);
    }
    void Update()
    {
        if(!IsOwner) return;
        
        if(Input.GetKeyDown(KeyCode.K))
        {
            TakeDamage(20f);
        }
    }
    
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        healthBar.SetSlider(currentHealth);
    }

    void Die()
    {
        dead = true;
    }

}
