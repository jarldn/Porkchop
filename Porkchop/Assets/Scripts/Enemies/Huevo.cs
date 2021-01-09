using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Huevo : MonoBehaviour
{

    public GameObject origen;
    public GameObject explosionPs;

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

       
        //Debug.Log("Toca");
        if (other.gameObject != origen)
        {
            Instantiate(explosionPs, transform.position, Quaternion.identity);

            Destroy(this.gameObject);
        }
           
    }

    //public void Explosion()
    //{
        
       
    //    var ps = GetComponentsInChildren<ParticleSystem>();
    //    foreach (var p in ps)
    //        p.Play();
    //    Debug.Log("Explosion");
        

    //    //var overlap = Physics.OverlapSphere(transform.position, 10);
    //    //Camera.main.GetComponent<CameraEffects>
    //}
}
