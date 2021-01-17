using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atributos : MonoBehaviour
{
    public Color piel;
    public int vida = 3;
    public Material skin;
    Animator animator;
    public bool isAlive;
    public bool ahogado;

    LevelChanger levelChanger;

   
    // Start is called before the first frame update
    void Start()
    {
        ahogado = false;
        isAlive = true;
        animator = this.GetComponentInParent<Animator>();
        piel = new Color(0.8773585f, 0.5090335f, 0.7462125f);
        skin.SetColor("_BaseColor", piel);
        levelChanger = GameObject.Find("Level Changer").GetComponent<LevelChanger>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(isAlive);
        if (vida <= 0)
        {
            isAlive = false;
            
            if (ahogado) animator.SetBool("Ahogado", true);
            else 
            {
                animator.SetBool("Die", true);
            }

            levelChanger.fadeToScene(2);

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
