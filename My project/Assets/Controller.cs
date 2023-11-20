using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Controller : MonoBehaviour
{
    //This class will only ever be on the player

    public Transform[] fruitsDroppable;
    static public bool spawned = false;
    static public Vector2 xPos;

    //Merge related variables
    static public Vector2 combinePos;
    static public bool Combine = false;
    static public int mergeNo = 0;
    

    [SerializeField]
    public float maxSpawnTimer = 2.0f;

    public float spawnTimer = 0.0f;



    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {   
        if (maxSpawnTimer <= spawnTimer){
        Drop();
        spawnTimer = 0.0f;
        }

        if (Input.GetKey("a")){

            GetComponent<Rigidbody2D>().velocity = new Vector2(-3,0);
        }

        if (Input.GetKey("d")){

            GetComponent<Rigidbody2D>().velocity = new Vector2(3,0);
        }

        if ((!Input.GetKey("a")) && (!Input.GetKey("d"))){
            GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);

        }

        //Tell fruit where player is
        xPos = transform.position;
        if (!spawned){
        spawnTimer += Time.deltaTime;

        }
        //Merge all fruits that are in contact
        mergeFruits();
    }

    void mergeFruits(){
        if (Combine && mergeNo < fruitsDroppable.Length - 1){

            Combine = false;
            Instantiate(fruitsDroppable[mergeNo+1], combinePos, Quaternion.identity);
        }
    }

    void Drop(){
        if (!spawned){
            //Quarter ident is 0 rotat
            Instantiate(fruitsDroppable[Random.Range(0, fruitsDroppable.Length )], transform.position, Quaternion.identity);
            spawned = true;
            

        }

    }

    
}
