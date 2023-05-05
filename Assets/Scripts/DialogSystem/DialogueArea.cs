using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueArea : MonoBehaviour
{
    public static event Action<Dialogue> OnEnteringDialogue;

    [SerializeField] private Dialogue dialogue;

    private bool _isActivatedBefore = false;

    public void ActivateDialogue()
    {
        _isActivatedBefore = true;
        OnEnteringDialogue?.Invoke(dialogue);
    }
}
