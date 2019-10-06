using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Renderer door;
    [SerializeField] private Color makeInvisible = Color.white;
    [SerializeField] private Color comeback = Color.white;
    public GameObject doorobject;
    [SerializeField] private float timergoesdown = 5f;
    public bool doorisopen = false;


    void Update()
    {
        if (doorisopen == true)
        {
            timergoesdown -= Time.deltaTime;
            if (timergoesdown < 0)
            {
                doorobject.SetActive(true);
                door.material.color = comeback;
                doorisopen = false;
                timergoesdown = 5f;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        bool AccesingOpenDoorsAllowed = EScript.instance.OpenDoorsAllowed;
        
        if ((AccesingOpenDoorsAllowed == true) && (Input.GetKey("e")))
        {
            doorobject.SetActive(false);
            door.material.color = makeInvisible;
            doorisopen = true;
        }


    }


    
}
