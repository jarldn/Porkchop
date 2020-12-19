using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCMove : MonoBehaviour
{
    [SerializeField]
    List<Waypoint> puntosDestino;

    [SerializeField]
    Transform objetivo;

    [SerializeField]
    float rotationSpeed = 10f;

    NavMeshAgent navMeshAgent;



    int puntoActual;
    private bool ida;
    private bool esperando = false;


    public GameObject huevo;
    public GameObject proyectil;
    bool canShoot;
    [SerializeField]
    float fuerzaDisparoHorizontal;
    [SerializeField]
    float fuerzaDisparoVertical;



    private enum Estado
    {
        Patrullando,
        Apuntando,
        Muriendo,
        Golpeado,
        Recargando,
        BuscandoDestino,
        Esperando,
    }

    private Estado estado;

    private Estado estadoAnterior;

    private void Awake()
    {
        estado = Estado.Patrullando;
    }
    // Start is called before the first frame update
    void Start()
    {
        objetivo = GameObject.FindGameObjectWithTag("Player").transform;
        canShoot = true;
        fuerzaDisparoHorizontal = 10f;
        fuerzaDisparoVertical = 2f;

        navMeshAgent = this.GetComponent<NavMeshAgent>();
        if(navMeshAgent == null)
        {
            Debug.Log("No hay navemesh agent en " + gameObject.name);
        }
        else
        {
            if (puntosDestino != null && puntosDestino.Count >= 2)
            {
                ida = true;
                puntoActual = 0;
                SetDestination();
            }
            else
            {
                Debug.Log("No hay puntos de destino suficientes");

            }
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(puntoActual);
        //Debug.Log(navMeshAgent.isStopped);
        Debug.Log(estado);

       // Buscar();
      
        switch (estado)
        {
            default:
            case Estado.Patrullando:

                if(navMeshAgent.remainingDistance <= 1.0f)
                {

                    estado = Estado.Esperando;
                }

                break;
            case Estado.Apuntando:
                //Ray ray = new Ray(transform.position, transform.forward);

                //RaycastHit hit;
                Apuntar();

                Atacar();

                //if (Input.GetButtonDown("Fire1"))
                //{
                //    navMeshAgent.isStopped = false;

                //    estado = estadoAnterior;
                //}
                    

                break;
            case Estado.BuscandoDestino:
               if(navMeshAgent.isStopped == true)
                    navMeshAgent.isStopped = false;

                if (ida == true)
                {
         
                    puntoActual++;
                    direccion();
                    SetDestination();
                    
                    estado = Estado.Patrullando;
                }
                else if(ida == false)
                {
                    puntoActual--;
                    direccion();
                    SetDestination();
                    
                    estado = Estado.Patrullando;
                }
                break;
            case Estado.Esperando:
                if(esperando == false)
                StartCoroutine (TiempoEspera());
                break;

        }
    }

    private void SetDestination()
    {
       
           
            Vector3 targetVector = puntosDestino[puntoActual].transform.position;
            navMeshAgent.SetDestination(targetVector);
        
    }

    private void direccion()
    {
        if (puntoActual == puntosDestino.Count - 1)
        {
            ida = false;
            //puntoActual++;
            //SetDestination();
            //estado = Estado.Patrullando;
        }
        else if (puntoActual == 0)
        {
            ida = true;
            //puntoActual--;
            //SetDestination();
            //estado = Estado.Patrullando;
        }

    }

    IEnumerator TiempoEspera()
    {
        esperando = true;
        yield return new WaitForSeconds(2f);

        if(estado != Estado.Apuntando)
        estado = Estado.BuscandoDestino;

        esperando = false;
        

    }
    IEnumerator AtacarCor()
    {

     
        //_fireball = Instantiate<GameObject>(fireballPrefab);
        //_fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f); //transformPoint pasa del sistema local al global
        //_fireball.transform.rotation = transform.rotation;

        //Rigidbody rb = Instantiate(huevo, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
        //rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
        //rb.AddForce(transform.up * 8f, ForceMode.Impulse);
        yield return new WaitForSeconds(2f);
        canShoot = true;
    }



    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Player")
        {
            if (estado != Estado.Apuntando)
                estadoAnterior = estado;

            estado = Estado.Apuntando;
            navMeshAgent.isStopped = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            navMeshAgent.isStopped = false;

            estado = estadoAnterior;
        }
    }

    //private void Buscar()
    //{
    //    //if (Input.GetButtonDown("Jump"))
    //    //{
    //    //    if(estado != Estado.Apuntando)
    //    //    estadoAnterior = estado;

    //    //    estado = Estado.Apuntando;
    //    //    navMeshAgent.isStopped = true;
    //    //}

    //}

    private void Apuntar()
    {
        Vector3 direction = objetivo.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);




        
    }

    private void Atacar()
    {        
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        

        if (Physics.SphereCast(ray, 0.75f, out hit))
        {
            GameObject hitObject = hit.transform.gameObject;
            if (hitObject == objetivo.gameObject && canShoot)
            {

                Debug.Log("tocado");
                proyectil = Instantiate(huevo, transform.position, Quaternion.identity);
                Rigidbody rb = proyectil.GetComponent<Rigidbody>();
                rb.GetComponent<Huevo>().origen = gameObject;

                rb.AddForce(transform.forward * fuerzaDisparoHorizontal, ForceMode.Impulse);
                rb.AddForce(transform.up * fuerzaDisparoVertical, ForceMode.Impulse);
                canShoot = false;

                StartCoroutine(AtacarCor());

            }



        }


    }

    public virtual void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, this.GetComponent<SphereCollider>().radius);
    }
}
