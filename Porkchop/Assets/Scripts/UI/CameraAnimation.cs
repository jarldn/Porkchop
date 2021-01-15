using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    
    public void ZoomIn()
    {
        animator.SetBool("Zoom", true);
    }

    public void ZoomOut()
    {
        animator.SetBool("Zoom", false);
    }
}
