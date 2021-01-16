using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    [SerializeField]
    Sprite[] images;
    Image spriteVida;
    Atributos atributos;
    
    // Start is called before the first frame update
    void Start()
    {
        atributos = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Atributos>();
        spriteVida = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(atributos.vida);
        if (atributos.vida == 3)
        {
            spriteVida.sprite = images[3];
        }else if (atributos.vida == 2)
        {
            spriteVida.sprite = images[2];
        }else if (atributos.vida == 1)
        {
            spriteVida.sprite = images[1];
        }
        else if (atributos.vida == 0)
        {
            spriteVida.sprite = images[0];
        }
        //GetComponent<UnityEngine.UI.Image>().sprite = images[0];
    }
    
}
