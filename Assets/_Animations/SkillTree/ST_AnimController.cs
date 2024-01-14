using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ST_AnimController : MonoBehaviour
{
    // Start is called before the first frame update

    public GameController Controller;
    public Animator ST_Anim;
    public ST_InputAction ST_Actions;

    private InputAction moveMenu;
    private void Awake()
    {
        ST_Actions = new ST_InputAction();
        
    }
    private void OnEnable()
    {
        moveMenu = ST_Actions.SkillTree.MenuAnimations;
        moveMenu.Enable();
        moveMenu.performed += OpenMenu;
    }

    private void OnDisable()
    {
        moveMenu.Disable();
    }

    private void OpenMenu(InputAction.CallbackContext context)
    {
        Debug.Log("MoveST");
        ST_Anim.SetTrigger("OpenSkillTree");
        Controller.isSkillTree = !Controller.isSkillTree;
    }


}
