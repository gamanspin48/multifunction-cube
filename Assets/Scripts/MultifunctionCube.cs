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
    
 
   

    void OnTriggerEnter(Collider other)
    {  
        bool isSelected = other.GetComponent<ObjectStatus>().isSelected;
        bool isRotateLeft = SceneManager.Instance.isRotateLeft;

        

        if (isSelected){
            if (duplicate){
                if (isRotateLeft)
                    Instantiate(other.gameObject.transform, new Vector3(2 * 2.0F, 0, 0), Quaternion.identity);
            }
        }
        if (fullSelect){
                Debug.Log("full select");
                other.GetComponent<ObjectStatus>().isSelected = !isRotateLeft;
                if (isRotateLeft)
                    other.GetComponent<Renderer>().material = SceneManager.Instance.unselectedMaterial;
                else
                     other.GetComponent<Renderer>().material = SceneManager.Instance.selectedMaterial;
                   
        }
        
    }

}
