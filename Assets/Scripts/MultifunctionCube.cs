using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultifunctionCube : MonoBehaviour
{   
    [Header("Selection")]
    public bool fullSelect;
    [Header("Convert")]
    public bool meshVertices;
    [Header("Handling")]
    public bool duplicate;
    // [Header("Modify")]
    // [Header("Splines")]
    // [Header("Tags")]
    // [Header("UI")]
    
 
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {   
        Debug.Log("collide");
        if (duplicate){
            Transform g = Instantiate(other.gameObject.transform, new Vector3(2 * 2.0F, 0, 0), Quaternion.identity);
        }
    }

}
