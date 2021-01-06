using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atributos : MonoBehaviour
{
    Color piel;
    public int vida = 3;
    public Material skin;
    // Start is called before the first frame update
    void Start()
    {
        piel = skin.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            skin.SetColor("_BaseColor", Color.red);
            Debug.Log("Alcanzado");
            this.gameObject.GetComponent<Animator>().SetBool("Damaged", true);
           

        }
    }


    public void AlcanzadoFalse()
    {
        
        this.gameObject.GetComponent<Animator>().SetBool("Damaged", false);
        skin.SetColor("_BaseColor", piel);

    }
}
