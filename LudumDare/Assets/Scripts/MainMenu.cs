using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private float timerdown = 2f;
    [SerializeField] private bool x = false;
    public Animator animator;
    public Text pressenter; 
    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetKey("return"))
        {
            x = true;
        }



        if (x == true) { 
            timerdown -= Time.deltaTime;
            animator.SetBool("D", true);
            if (timerdown< 1)
            {
                animator.SetBool("E", true);
                pressenter.text = " ";
            }

            if (timerdown < 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }


    }

    


}
