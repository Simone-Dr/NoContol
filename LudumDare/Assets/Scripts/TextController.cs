using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    public Text advice;
    private int a=1;
    private int w=1;
    private int s=1;
    private int e =1;
    private int shift =1;
    private int space = 1;
    
 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool AccesRunningRight = ACollider.instance.runningright;
        bool AccesSpaceScript = SpaceScript.instance.JumpAllowed;
        bool AccesShiftScript = ShiftScript.instance.RunFastAllowed;
        bool AccesEScript = EScript.instance.OpenDoorsAllowed;
        bool AccesSScript = SScript.instance.DigDownAllowed;
        bool AccesWScript = WScript.instance.WallJumpAllowed;


        if ((AccesRunningRight == true) && (a==1))
        {
            a = a + 1;
            advice.text = " You can now go left! ";
        }

        //----------------------------------------


        if ((AccesSpaceScript == true) && (space == 1))
        {
            space  = space + 1;
            advice.text = " You can now Jump! ";
        }

        //----------------------------------------

       

        if ((AccesShiftScript == true) && (shift == 1))
        {
            shift = shift + 1;
            advice.text = " You can now sprint! ";
        }

        //----------------------------------------

 

        if ((AccesEScript == true) && (e == 1))
        {
            e = e + 1;
            advice.text = " You can now open doors! ";
        }

        //----------------------------------------


        if ((AccesSScript == true) && (s == 1))
        {
            s = s + 1;
            advice.text = " You can now dig down on the grey rocks! ";
        }

        //----------------------------------------


        if ((AccesWScript == true) && (w == 1))
        {
            w = w + 1;
            advice.text = " You can now climb the green walls ";
        }

        //----------------------------------------
    }


}
