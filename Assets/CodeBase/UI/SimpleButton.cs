using System.Collections;
using System.Collections.Generic;
using CodeBase.Hero;
using UnityEngine;

public class SimpleButton : MonoBehaviour
{
    private HeroAnimator _heroAttack;


    void Start()
    {
        _heroAttack = FindObjectOfType<HeroAnimator>();
    }

    
    void Attack()
    {
        _heroAttack.PlayAttack();
    }
    
    
}