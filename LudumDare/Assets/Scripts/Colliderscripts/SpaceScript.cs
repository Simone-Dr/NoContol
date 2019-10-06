using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceScript : MonoBehaviour
{
    public static SpaceScript instance;
    [SerializeField] private Renderer rend;
    [SerializeField] private Color colorToTurnTo=Color.white;
    [SerializeField] private Renderer collect;
    public bool JumpAllowed = false;

    private void Awake(){
        instance = this;
    }

    private void OnTriggerEnter2D (Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            rend.material.color = colorToTurnTo;
            collect.enabled = false;
            JumpAllowed = true;
        }
    }
}
