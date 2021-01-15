using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickButtonsAnimation : MonoBehaviour
{
    Button[] buttons;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        buttons = this.GetComponentsInChildren<Button>();
        for(int i = 0; i < buttons.Length; i++)
        {
            buttons[i].onClick.AddListener(TareaOnClick);
        }
        animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }

    // Update is called once per frame
    void TareaOnClick()
    {
        animator.SetTrigger("Mando");
        Debug.Log("Pulsado");
    }
}
