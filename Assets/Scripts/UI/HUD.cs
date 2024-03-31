using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    [SerializeField] private Animator target;
    [SerializeField] private GameInstance gameInstance;

    private void Start()
    {
        if (target == null || gameInstance == null)
        {
            return;
        }
        
        target.Play(gameInstance.data.defaultAnimationState);
    }
}
