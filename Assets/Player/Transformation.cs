using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transformation : MonoBehaviour
{

    private ParticleSystem particle;
    public bool isTransformed;

    //Untransform Color
    private float redColor = 255.0F;

    //Transform Color
    private float greenColor = 255.0F;


    void Start() {
        particle = GetComponent<ParticleSystem>();
        particle.Stop();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.R)) {
            particle.Play();

            if (isTransformed) {
                particle.startColor = new Color(redColor, 0.0f, 0.0f, 1.0f);
            } else {
                particle.startColor = new Color(0.0f, greenColor, 0.0f, 1.0f);
            }
            
            isTransformed = !isTransformed;
        }
    }
}
