using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrushAnim : MonoBehaviour
{
    [SerializeField] private Animator AnimationController;

        private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AnimationController.SetBool("PlayBrush", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AnimationController.SetBool("PlayBrush", false);
        }
    }

}
