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
            
            
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake(){
        fruitPos = GetComponent<Transform>();
        rigid2d = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if(!dropped)
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

    // //Collision
     void OnTriggerStay2D(Collider2D collision){
            if((collision.gameObject.name == "BoundaryFruit") && checktime){
                Debug.Log("GG");
                SceneManager.LoadScene("SampleScene");
            }

     }

    


}
