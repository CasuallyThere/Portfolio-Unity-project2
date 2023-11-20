using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Combine : MonoBehaviour
{

    public static Transform[] fruitsDroppable = {};
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void replaceFruit(int current, Vector3 transform){
        
        if (current>= 0 && current < - 1){
        Instantiate(fruitsDroppable[current+1], transform, Quaternion.identity);
        
        }
    }
}
