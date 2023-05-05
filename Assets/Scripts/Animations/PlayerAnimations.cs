using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private Movement _movement;

    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    void OnEnable()
    {
        _movement.OnMove += SetMoveTrigger;
    }

    private void SetMoveTrigger(float x, float y)
    {
        if (x != 0 || y != 0)
        {
            _animator.SetBool("isMoving", true);
        }
        else 
        {
            _animator.SetBool("isMoving", false);
        }
    }
}
