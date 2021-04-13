using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruts : MonoBehaviour
{
    
    public GameObject grape;
    public GameObject apple;
    public GameObject pear;
    int height = 0;
    int width = 0;

    int sizeHeight = 30;

    float speed = 1;
    void Start()
    {

        height = (int)(sizeHeight / 3.4f) - 1;
        width =  (int)((Screen.width /(Screen.height / sizeHeight) - 1.7f)/ 3.4f) - 1;

        //Debug.Log(height);
        //Debug.Log(width);


    }

    float timer = 0;
    void Update()
    { 

        if(timer * speed < 0){


            if(GetComponentInChildren<Frute>() != null)
                Destroy(GetComponentInChildren<Frute>().gameObject);

            GenerateFrute();
            timer = width + height;
        }
        timer -= Time.deltaTime;
    }


    public void NewFrute(){
        
        timer = -1;
    }


    void GenerateFrute(){

        int ind = Random.Range(0, 3);
        GameObject frut;

        switch (ind)
        {
            case 0:
                frut = grape;
                break;
            case 1:
                frut = apple;
                break;
            default:
                frut = pear;
                break;
        }

        int[] arr = {-1, 1};
        int x = Random.Range(0, width) * arr[Random.Range(0, 2)];
        int y = Random.Range(0, height) * arr[Random.Range(0, 2)];

        Instantiate(frut, new Vector3(x * 3.4f, y * 3.4f, 10), Quaternion.identity, transform);
 


    }
}
