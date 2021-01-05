using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weakPoint : MonoBehaviour
{
    GameObject gallina;
    GameObject player;
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
            player.GetComponent<RelativeMovement>().bounce = true;
            Debug.Log("Colisión");
            Destroy(gallina);
        }
    }
}
