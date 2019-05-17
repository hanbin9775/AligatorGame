using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToothClick : MonoBehaviour
{
    public Animator animt;
    private bool isontooth = false;
    public bool isclicked = false;

    private void Awake()
    {
        animt = GetComponent<Animator>();
    }

    private void OnMouseEnter()
    {
        isontooth = true;          
    }

    private void OnMouseExit()
    {
        isontooth = false;
    }

    private void OnMouseUp()
    {
        if (isontooth)
        {
            animt.SetTrigger("OnClick");
            isclicked = true;
        }
    }
}
