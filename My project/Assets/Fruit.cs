using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    private bool dropped = false;
    private Transform fruitPos;
    private Rigidbody2D rigid2d;
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

            //Reset controller spawning
            Controller.spawned = false;
            
        }


    }
}
