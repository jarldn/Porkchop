using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{

    ParticleSystem explosion;
    // Start is called before the first frame update
    void Start()
    {
        explosion = GetComponentInChildren<ParticleSystem>();

        //var ps = GetComponentsInChildren<ParticleSystem>();
        //foreach (var p in ps)
        //    p.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!explosion.IsAlive())
        {
            Debug.Log("Acabado");
            Destroy(this.gameObject);
            
        }
    }
    
}
