using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public enum ComboState {
        NONE,
        PUNCH_1,
        PUNCH_2,
        PUNCH_3,
        KICK_1,
        KICK_2
    }
public class PlayerAttack : NetworkBehaviour
{
    private CharacterAnimation player_Anim;
    private bool activteTimerToReset;
    private float default_Combo_Timer = 0.4f;
    private float current_Combo_Timer;

    private ComboState current_Combo_State;

    
    void Awake()
    {
        player_Anim = GetComponentInChildren<CharacterAnimation>();
    }

    // Update is called once per frame
    void Start()
    {
        current_Combo_Timer = default_Combo_Timer;
        current_Combo_State = ComboState.NONE;
    }

    void Update()
    {
         if(!IsOwner) return;

        ComboAttacks();
        ResetComboState();
    }

    void ComboAttacks()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            if(current_Combo_State == ComboState.PUNCH_3 ||
            current_Combo_State == ComboState.KICK_1 ||
            current_Combo_State == ComboState.KICK_2)
            return;

            current_Combo_State++;
            activteTimerToReset = true;
            current_Combo_Timer = default_Combo_Timer;

            if(current_Combo_State == ComboState.PUNCH_1)
            {
                player_Anim.Punch_1();
            }

            if(current_Combo_State == ComboState.PUNCH_2)
            {
                player_Anim.Punch_2();
            }

            if(current_Combo_State == ComboState.PUNCH_3)
            {
                player_Anim.Punch_3();
            }
        }

        if(Input.GetKeyDown(KeyCode.C))
        {
            if(current_Combo_State == ComboState.KICK_2 ||
            current_Combo_State == ComboState.PUNCH_3)
            return;

            if(current_Combo_State == ComboState.NONE ||
            current_Combo_State == ComboState.PUNCH_1 ||
            current_Combo_State == ComboState.PUNCH_2)
            {
                current_Combo_State = ComboState.KICK_1;
            }

            else if(current_Combo_State == ComboState.KICK_1)
            {
                current_Combo_State++;
            }
            
            activteTimerToReset = true;
            current_Combo_Timer = default_Combo_Timer;

            if(current_Combo_State == ComboState.KICK_1) 
            {
                player_Anim.Kick_1();
            }

            if(current_Combo_State == ComboState.KICK_2) 
            {
                player_Anim.Kick_2();
            }
        }

    }

    void ResetComboState()
        {
            if(activteTimerToReset)
            {
                current_Combo_Timer -= Time.deltaTime;

                if(current_Combo_Timer <= 0f) 
                {
                    current_Combo_State = ComboState.NONE;

                    activteTimerToReset = false;
                    current_Combo_Timer = default_Combo_Timer;
                }
            }
        }
}
