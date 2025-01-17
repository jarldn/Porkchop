﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class RelativeMovement : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    public float rotSpeed = 15.0f;

    public float moveSpeed = 6.0f;
    private CharacterController _charController;

    public float jumpSpeed = 15.0f;
    public float gravity = -9.8f;
    public float terminalVelocity = -10.0f;
    public float minFall = -1.5f;
    public bool bounce = false;
    Material skin;
    Atributos atributos;

    private float _vertSpeed;

    private ControllerColliderHit _contact;

    private Animator _animator;
    Color piel;

    RaycastHit hit;
    LevelChanger levelChanger;

   


    // Start is called before the first frame update
    void Start()
    {
        atributos = GetComponentInChildren<Atributos>();
        skin = atributos.skin;
        piel = atributos.piel;
        
        _charController = GetComponent<CharacterController>();
        _vertSpeed = minFall;
        _animator = GetComponent<Animator>();
        levelChanger = GameObject.Find("Level Changer").GetComponent<LevelChanger>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = Vector3.zero;
        float horInput = Input.GetAxis("Horizontal");
        float vertIntput = Input.GetAxis("Vertical");

        if ((horInput != 0 || vertIntput != 0) && atributos.isAlive && levelChanger.fadeInDone)
        {
            movement.x = horInput * moveSpeed;
            movement.z = vertIntput * moveSpeed;
            movement = Vector3.ClampMagnitude(movement, moveSpeed);

            Quaternion rot = Quaternion.Euler(0, target.eulerAngles.y, 0);
            movement = rot * movement;
            //transform.rotation = Quaternion.LookRotation(movement);
            Quaternion direction = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Lerp(transform.rotation, direction, rotSpeed * Time.deltaTime);

            
          

        }

        _animator.SetFloat("Speed", movement.sqrMagnitude);

        bool hitGround = false;


        //if (_vertSpeed < 0 && Physics.Raycast(transform.position, Vector3.down, out hit))
        if (_vertSpeed < 0 && Physics.SphereCast(transform.position - new Vector3(0, -0.3f, 0), 0.3f, Vector3.down, out hit, 1))
        {

            if (hit.distance <= (0.2f))
            {
                hitGround = true;
            }
            else
            {
                hitGround = false;
            }
            //float check = (_charController.radius) / 1.9f;
            //hitGround = hit.distance <= check; //condicional

        }

        //if (_charController.isGrounded)
        if (hitGround)
        {
            if ((Input.GetButtonDown("Jump") || bounce == true) && atributos.isAlive && levelChanger.fadeInDone)
            {
                _vertSpeed = jumpSpeed;
                bounce = false;
            }
            else
            {
                _vertSpeed = minFall;
                _animator.SetBool("Jumping", false);
            }
        }
        else
        {
            _vertSpeed += gravity * 5 * Time.deltaTime;
            if (_vertSpeed < terminalVelocity)
            {
                _vertSpeed = terminalVelocity;
            }

            if (_contact != null)
            {
                _animator.SetBool("Jumping", true);
            }

            if (_charController.isGrounded)
            {
                if (Vector3.Dot(movement, _contact.normal) < 0)
                {
                    movement = _contact.normal * moveSpeed;
                }
                else
                {
                    movement += _contact.normal * moveSpeed;
                }
            }

          

        }
        movement.y = _vertSpeed;
        movement *= Time.deltaTime;
        _charController.Move(movement);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        _contact = hit;
    }

    private void OnDrawGizmos()
    {
        if (_charController != null)
        {
            Gizmos.DrawLine(transform.position, transform.position + Vector3.down * (_charController.radius) / 1.9f);
            Gizmos.DrawSphere(hit.point, 0.2f);

            Gizmos.DrawLine(transform.position, hit.point);
        }
    }
    public void AlcanzadoFalse()
    {

        _animator.SetBool("Damaged", false);
        skin.SetColor("_BaseColor", piel);
       

    }


}
