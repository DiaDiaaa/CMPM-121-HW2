using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float rotationSpeed;
    public float Direction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Direction == 1){ //x
            transform.Rotate(new Vector3(rotationSpeed,0,0)*Time.deltaTime);
        }else if(Direction == 2){ //y
            transform.Rotate(new Vector3(0,rotationSpeed,0)*Time.deltaTime);
        }else if(Direction == 3){ //z
            transform.Rotate(new Vector3(0,0,rotationSpeed)*Time.deltaTime);
        }else{
            transform.Rotate(new Vector3(0,rotationSpeed,rotationSpeed)*Time.deltaTime);
        }
        
    }
}
