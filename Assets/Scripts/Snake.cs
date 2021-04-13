using UnityEngine;

public class Snake : MonoBehaviour
{

    public GameObject prefabBody;
    public GameObject prefabRot1;
    public GameObject prefabRot2;

    

    float speed = 2;

    float screenWidth = 0;
    float screenHiegth = 0;

    bool is_eaten = false;

    int headRot = 0;
    // Start is called before the first frame update
    void Start()
    {
         screenHiegth = 30;
         screenWidth = (Screen.width / (Screen.height / screenHiegth)) - 1.7f;
         
        
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

    public void Reload(){
        headRot = 0;
        Head h = GetComponentInChildren<Head>();
        h.transform.position = new Vector3(3.4f, 0, 0);
        h.transform.rotation = Quaternion.Euler(0, 0, 0);

        Tail t = GetComponentInChildren<Tail>();
        t.transform.position = new Vector3(-6.8f, 0, 0);
        t.transform.rotation = Quaternion.Euler(0, 0, 0);

        var bb = GetComponentsInChildren<Body>();

        foreach(var b in bb){
            Destroy(b.gameObject);
        }

        Instantiate(prefabBody, new Vector3(-3.4f, 0, 0), Quaternion.identity, transform);
        Instantiate(prefabBody, new Vector3(0    , 0, 0), Quaternion.identity, transform);
    }

    public void Eat(){
        is_eaten = true;
    }

    void MoveBody(){


        if(!is_eaten){

        
            Body[] bb = GetComponentsInChildren<Body>();

            

            Tail t = GetComponentInChildren<Tail>();

            t.transform.rotation = bb[1].transform.rotation;
            t.transform.position = bb[0].transform.position;

            Destroy(bb[0].gameObject);
        }
        else
            is_eaten = false;


        

    }



    public void Right(){
        timer = 0;

        if(headRot == 90 || headRot == 270){

            
            Head h = GetComponentInChildren<Head>();

            h.transform.rotation = Quaternion.Euler(0, 0, 0);

            

            if(headRot == 90)
                Instantiate(prefabRot1, h.transform.position, Quaternion.Euler(0, 0, headRot), transform);
            if(headRot == 270)
                Instantiate(prefabRot2, h.transform.position, Quaternion.Euler(0, 0, headRot), transform);
            
            headRot = 0;

            h.transform.position = new Vector3(h.transform.position.x + 3.4f,
                                                h.transform.position.y,
                                                h.transform.position.z);

            MoveBody();


        }
        
    }
    public void Left(){
        timer = 0;
        if(headRot == 90 || headRot == 270){

            Head h = GetComponentInChildren<Head>();

            h.transform.rotation = Quaternion.Euler(0, 0, 180);

            

            if(headRot == 270)
                Instantiate(prefabRot1, h.transform.position, Quaternion.Euler(0, 0, headRot), transform);
            if(headRot == 90)
                Instantiate(prefabRot2, h.transform.position, Quaternion.Euler(0, 0, headRot), transform);
            
            headRot = 180;

            h.transform.position = new Vector3(h.transform.position.x - 3.4f,
                                                h.transform.position.y ,
                                                h.transform.position.z);

            MoveBody();


        }
        
    }
    public void Up(){
        timer = 0;
        if(headRot == 0 || headRot == 180){

            Head h = GetComponentInChildren<Head>();

            h.transform.rotation = Quaternion.Euler(0, 0, 90);

            

            if(headRot == 180)
                Instantiate(prefabRot1, h.transform.position, Quaternion.Euler(0, 0, headRot), transform);
            if(headRot == 0)
                Instantiate(prefabRot2, h.transform.position, Quaternion.Euler(0, 0, headRot), transform);
            
            headRot = 90;

            h.transform.position = new Vector3(h.transform.position.x,
                                                h.transform.position.y + 3.4f,
                                                h.transform.position.z);

            MoveBody();


        }
    }
    public void Down(){
        timer = 0;
        if(headRot == 0 || headRot == 180){

            Head h = GetComponentInChildren<Head>();

            h.transform.rotation = Quaternion.Euler(0, 0, 270);

            

            if(headRot == 0)
                Instantiate(prefabRot1, h.transform.position, Quaternion.Euler(0, 0, headRot), transform);
            if(headRot == 180)
                Instantiate(prefabRot2, h.transform.position, Quaternion.Euler(0, 0, headRot), transform);
            
            headRot = 270;

            h.transform.position = new Vector3(h.transform.position.x,
                                                h.transform.position.y - 3.4f,
                                                h.transform.position.z);

            MoveBody();


        }

    }

}
