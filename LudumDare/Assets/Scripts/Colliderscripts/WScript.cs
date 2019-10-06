using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WScript : MonoBehaviour
{
    public static WScript instance;
    [SerializeField] private Renderer rend;
    [SerializeField] private Color colorToTurnTo = Color.white;
    [SerializeField] private Renderer collect;
    public bool WallJumpAllowed = false;

    private void Awake()
    { instance = this;}

    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.CompareTag ("Player"))
        {
            rend.material.color = colorToTurnTo;
            collect.enabled = false;
            WallJumpAllowed = true;
        }
    }

}
