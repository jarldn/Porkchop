using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Huevo : MonoBehaviour
{

    public GameObject origen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

       
        Debug.Log("Toca");
        if(other.gameObject != origen)
        Destroy(this.gameObject);
    }
}
