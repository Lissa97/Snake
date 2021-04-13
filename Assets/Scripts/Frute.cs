using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frute : MonoBehaviour
{

    public Fruts fruts;
    void OnTriggerEnter2D(Collider2D other){

        Destroy(gameObject);
        GetComponentInParent<Fruts>().NewFrute();
        

    }
}
