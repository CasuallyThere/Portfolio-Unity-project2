using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fruit : MonoBehaviour
{
    private bool dropped = false;
    private Transform fruitPos;
    private Rigidbody2D rigid2d;
    private bool checktime = false;
    private GameObject player;
    private bool mergeCreated = false;
    

    //Change this for each fruit
    [SerializeField]
    public int FruitNo = -1;

            
            
    // Start is called before the first frame update
    void Start()
    {
        //Bandaid fix
        if (transform.position.y<2.8){
            mergeCreated = true;
        }
    }

    void Awake(){
        fruitPos = GetComponent<Transform>();
        rigid2d = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Controller");
        

    }

    // Update is called once per frame
    void Update()
    {
        if(!dropped && !mergeCreated)
        {
            //Controller is player character
            fruitPos.position = Controller.xPos;
        }

        if(Input.GetKeyDown("space")){
            rigid2d.gravityScale = 1;
            
            dropped = true;
            if(Random.value > 0.5f){
                rigid2d.AddForce(Vector2.left * 0.01f);
            }
            else{
                rigid2d.AddForce(Vector2.left * 0.01f);
            }
            //Reset controller spawning
            Controller.spawned = false;
            StartCoroutine(checkEnd());
            
        }

        
    }

    IEnumerator checkEnd(){
        yield return new WaitForSeconds(0.75f);
        checktime = true;


    }
    private void OnCollisionEnter2D(Collision2D collision){
        //Lots of tags I guess

        if (collision.gameObject.tag == gameObject.tag ){
            //Give infor to controller for merging
            Controller.combinePos = fruitPos.position;
            Controller.Combine = true;
            Controller.mergeNo = FruitNo;
            
           
            Destroy(gameObject);
            

        }

    }

    

    // //Collision
     void OnTriggerStay2D(Collider2D collision){
            if((collision.gameObject.name == "BoundaryFruit") && checktime){
                Debug.Log("GG");
                SceneManager.LoadScene("SampleScene");
            }

     }

    


}
