using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootMotionControl : MonoBehaviour
{
    [SerializeField] private Transform _MotionTransform;

    void OnAnimatorMove()
    {
        Animator anim = GetComponent<Animator>();
        if (!anim.applyRootMotion)
            return;
        if (_MotionTransform != null)
        {
            _MotionTransform.position += anim.deltaPosition;
            _MotionTransform.rotation *= anim.deltaRotation;
        }
        else
        {
            // If we aren't retargeting, just let Unity apply the Root Motion normally.
            anim.ApplyBuiltinRootMotion();
        }
    }
}