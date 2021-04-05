using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class UIPanel : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    Vector2 pos;
    public Snake Snake;

    public void OnPointerUp(PointerEventData e){

        float right = pos.x - e.position.x;// - right
        float up = pos.y - e.position.y;// - up

        if(Math.Abs(right) - Math.Abs(up) > 0){

            if(right < 0)
                Snake.Right();
            else
                Snake.Left();

        }
        
        else{

            if(up < 0)
                Snake.Up();
            else
                Snake.Down();

        }   


    }

    public void OnPointerDown(PointerEventData e){
        pos = e.position;
    }
}
