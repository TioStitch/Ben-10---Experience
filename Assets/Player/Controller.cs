using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Controller : MonoBehaviour
{

    private CharacterController character;
    private Vector3 inputs;

    //alienígenas
    private Animator animator;
    public GameObject ben10;
    public GameObject diamondHead;
    public GameObject heatBlast;
    public GameObject upgrade;
    public Transformation transformation;


    public int selectedAlien = 0;
    private float velocidade = 8f;


    void Awake() {
        character = GetComponent<CharacterController>();
        animator = ben10.GetComponent<Animator>();
    }

    void Update() {
        TransformChanges();
        Movement();
    }

    private void TransformChanges() {
        if (transformation.isTransformed) {
            ben10.SetActive(false);
            upgrade.SetActive(true);
            animator = upgrade.GetComponent<Animator>();

            print("HeatBlast: " + animator.GetInteger("anim"));
        } else {
            upgrade.SetActive(false);
            ben10.SetActive(true);
            animator = ben10.GetComponent<Animator>();

            print("Ben 10: " + animator.GetInteger("anim"));
        }
    }

    private void Movement() {
        inputs.Set(Input.GetAxis("Vertical"), 0, Input.GetAxis("Horizontal"));

        if (inputs != Vector3.zero) {

            bool isRunning = Input.GetKeyDown(KeyCode.LeftShift);

            if (isRunning) {
                animator.SetInteger("anim", 2);
                velocidade += 4f;
            } else {
                animator.SetInteger("anim", 3);
                velocidade = 8f;
            }

            character.Move(inputs * Time.deltaTime * velocidade);
            transform.forward = Vector3.Slerp(transform.forward, -inputs, Time.deltaTime * 10);
            return;
        }

        if (inputs == Vector3.zero) {
            animator.SetInteger("anim", 1);
            return;
        }
    }
}
