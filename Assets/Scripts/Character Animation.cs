using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    private Animator anim;

    void Awake(){
        anim = GetComponent<Animator>();
    }

    public void Walk(bool move){
        anim.SetBool(AnimationTags.MOVEMENT, move);
    }
}
