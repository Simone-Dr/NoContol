using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField] private Renderer rock;
    [SerializeField] private Color makeInvisible = Color.white;
  
    public GameObject rockobject;
    public Animator animator;
    [SerializeField] private float timerdown = 1f;
    public bool rockisopen = false;


    void Update()
    {
        if (rockisopen == true ){ 
        timerdown -= Time.deltaTime;
        }

        if (timerdown < 0)
        {
            rockobject.SetActive(false);
            animator.SetBool("IsDigging", false);
            rock.material.color = makeInvisible;
            timerdown = 1f;
            rockisopen = false;
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        bool AccesingOpenDoorsAllowed = EScript.instance.OpenDoorsAllowed;

        if ((AccesingOpenDoorsAllowed == true) && (Input.GetKey("s")))
        {
            rockisopen = true;
            animator.SetBool("IsDigging", true);
            
            

         
        }


    }
}
