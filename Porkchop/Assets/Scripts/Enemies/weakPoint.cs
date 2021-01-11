using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weakPoint : MonoBehaviour
{
    GameObject gallina;
    public  GameObject player;
    public GameObject despiezado;
    // Start is called before the first frame update
    void Start()
    {
        gallina = this.transform.parent.gameObject;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            
            Debug.Log("Colisión");
            player.GetComponent<RelativeMovement>().bounce = true;
            Instantiate(despiezado, transform.position, transform.rotation);
            Destroy(gallina);
        }
    }
}
