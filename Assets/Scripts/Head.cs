using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{
    
    public Score score;
    public Snake snake;
    public GameController GC;
    
    void OnTriggerEnter2D(Collider2D other){

        if(other.tag == "Frute"){
            snake.Eat();
            score.UpScore();
        }
        else
         GC.GameReload();
            

    }
}
