using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitCamera : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    public Transform cameraTransform;
    private RaycastHit hit;

    public float rotSpeed = 1.5f;
    private float _rotY;
    private Vector3 _offset;
    private Vector3 _offsetCamera;
    public Vector3 ajusteCam;


    void Start()
    {
        _rotY = transform.eulerAngles.y; //eulerAngles hace referencia a los ángulos de rotación. en roty guardamos el valor inicial de la rotación de y
        _offset = target.position - transform.position;
        _offsetCamera = cameraTransform.localPosition;
        ajusteCam = new Vector3(0, 0, -0.45f);
    }

    private void Update()
    {

        

        if (Physics.Linecast(target.position, transform.position, out hit))
        {
            if(hit.collider.gameObject.tag == "Player" || hit.collider.gameObject.tag == "Enemy")
            {

            }
            else
            {
                //Debug.Log("Detectado");
                cameraTransform.localPosition = new Vector3(0, 0, Vector3.Distance(transform.position, hit.point)) + ajusteCam;
            }
            
        }
        else
        {
            cameraTransform.localPosition = _offsetCamera;
        }
        //Debug.Log(hit.collider.gameObject.name);

    }
    void LateUpdate()//se ejecuta una vez por frame después de que se hayan ejecutado todos los archivos. Así conseguimos que la cámara calcule su posición despues de saber la posición del personaje
    {
        float horInput = Input.GetAxis("Horizontal");
        if (horInput != 0)
        {
            _rotY += horInput * rotSpeed;
        } 
        else
        {
            _rotY += Input.GetAxis("Mouse X") * rotSpeed * 3;//para moverlo con el ratón
        }

       

        Quaternion rotation = Quaternion.Euler(0, _rotY, 0);
        transform.position = target.position - (rotation * _offset);
        transform.LookAt(target);

   
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, target.position);
        //Gizmos.DrawSphere(hit.point, 0.5f);

    }
}
