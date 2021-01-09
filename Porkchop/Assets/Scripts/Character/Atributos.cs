using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atributos : MonoBehaviour
{
    public Color piel;
    public int vida = 3;
    public Material skin;
    Animator animator;
   
    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponentInParent<Animator>();
        piel = new Color(0.8773585f, 0.5090335f, 0.7462125f);
        skin.SetColor("_BaseColor", piel);
    }

    // Update is called once per frame
    void Update()
    {
        if (vida <= 0)
        {
            
            animator.SetBool("Die", true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            skin.SetColor("_BaseColor", Color.red);
            Debug.Log("Alcanzado");
            animator.SetBool("Damaged", true);
            vida--;
           

        }
    }



}
