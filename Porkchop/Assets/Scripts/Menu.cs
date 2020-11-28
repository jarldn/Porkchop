using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    private Animator animator;
    private CanvasGroup canvasGroup;

    public bool IsOpen
    {
        get { return animator.GetBool("IsOpen"); }
        set { animator.SetBool("IsOpen", value); }
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        canvasGroup = GetComponent<CanvasGroup>();

        var rec = GetComponent<RectTransform>();
        rec.offsetMin = rec.offsetMax = new Vector2(0, 0);
    }

    private void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Open"))
        {
            canvasGroup.blocksRaycasts = canvasGroup.interactable = true;
        }
        else
        { canvasGroup.blocksRaycasts = canvasGroup.interactable = false; }
    }

}

