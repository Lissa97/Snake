using UnityEngine;

public class Snake : MonoBehaviour
{

    public GameObject prefabBody;

    float speed = 2;

    float screenWidth = 0;
    float screenHiegth = 0;

    int headRot = 0;
    // Start is called before the first frame update
    void Start()
    {
         screenWidth = (Screen.width / (Screen.height / 30)) - 1.7f;
         screenHiegth = 30;
        
    }

    float timer = 1;
    void Update()
    {
        if(timer * speed > 1){
            Move();
            timer = 0;
        }
        timer += Time.deltaTime;
        
    }

    void Move (){

        Head h = GetComponentInChildren<Head>();

        if(headRot == 0 && h.transform.position.x + 3.4f < screenWidth){

            

            Instantiate(prefabBody, h.transform.position, Quaternion.Euler(0 , 0, headRot), transform);
            
            
            h.transform.position = new Vector3(h.transform.position.x + 3.4f,
                                                h.transform.position.y,
                                                h.transform.position.z);

            
            
            MoveBody();


        }

        if(headRot == 90 && h.transform.position.y + 3.4f < screenHiegth){

            

            Instantiate(prefabBody, h.transform.position, Quaternion.Euler(0 , 0, headRot), transform);
            
            
            h.transform.position = new Vector3(h.transform.position.x,
                                                h.transform.position.y + 3.4f,
                                                h.transform.position.z);

            
            MoveBody();
            

        }

        if(headRot == 180 && h.transform.position.x - 3.4f > - screenHiegth){

            

            Instantiate(prefabBody, h.transform.position, Quaternion.Euler(0 , 0, headRot), transform);
            
            
            h.transform.position = new Vector3(h.transform.position.x - 3.4f,
                                                h.transform.position.y,
                                                h.transform.position.z);

            
            MoveBody();
            

        }
        if(headRot == 270 && h.transform.position.y - 3.4f >  -screenHiegth){

            

            Instantiate(prefabBody, h.transform.position, Quaternion.Euler(0 , 0, headRot), transform);
            
            
            h.transform.position = new Vector3(h.transform.position.x,
                                                h.transform.position.y - 3.4f,
                                                h.transform.position.z);

            
            MoveBody();
            

        }

        


    }

    void MoveBody(){

        Body[] bb = GetComponentsInChildren<Body>();

            

        Tail t = GetComponentInChildren<Tail>();

        t.transform.rotation = bb[0].transform.rotation;
        t.transform.position = bb[0].transform.position;

        Destroy(bb[0].gameObject);

    }

}
