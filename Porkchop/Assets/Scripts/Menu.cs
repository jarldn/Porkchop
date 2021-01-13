using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void Continue()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

}

