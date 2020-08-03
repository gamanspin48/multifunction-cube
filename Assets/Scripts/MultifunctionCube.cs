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
    public bool delete;
    [Header("Modify")]
    public bool push;
    // [Header("Splines")]
    [Header("Tags")]
    public bool tag;
    public bool showTag;
    public bool tagOpacity;
    [Header("UI")]
    public bool exportToFBX;
    
 
   

    void OnTriggerEnter(Collider other)
    {  
        bool isSelected = other.GetComponent<ObjectStatus>().isSelected;
        bool isRotateLeft = SceneManager.Instance.isRotateLeft;

        if (isSelected){
            if (duplicate){
                int count = SceneManager.Instance.duplicateCount;
                for (int i = 0; i < count; i++){
                   Vector3 position = new Vector3(Random.Range(-10.0f, 10.0f), 0, Random.Range(-10.0f, 10.0f));
                   Instantiate(other.gameObject.transform, position, Quaternion.identity); 
                }
            }
            if (delete){
                if (isRotateLeft)
                    Destroy(other.gameObject);
                else{
                    Vector3 position = new Vector3(Random.Range(-10.0f, 10.0f), 0, Random.Range(-10.0f, 10.0f));
                    Instantiate(other.gameObject.transform, position, Quaternion.identity);
                }
            }
            if(tag){
                if(isRotateLeft)
                    other.gameObject.tag = SceneManager.Instance.tag;
                else 
                    other.gameObject.tag = "Untagged";
            }
            if(showTag){
                if(isRotateLeft)
                    SceneManager.Instance.tagText.text = "Tags : "+other.gameObject.tag;
                else
                    SceneManager.Instance.tagText.text = "Tags : ";
            }
            if(tagOpacity){
                 Color c = SceneManager.Instance.tagText.color;
                if(isRotateLeft)
                    c.a-=0.1f;
                else
                    c.a+=0.1f;
                SceneManager.Instance.tagText.color = c;
            }
            if(exportToFBX){
                SceneManager.Instance.ExportToFBX(other.gameObject);
            }
        }
        if (fullSelect){
                other.GetComponent<ObjectStatus>().isSelected = !isRotateLeft;
                if (isRotateLeft)
                    other.GetComponent<Renderer>().material = SceneManager.Instance.unselectedMaterial;
                else
                     other.GetComponent<Renderer>().material = SceneManager.Instance.selectedMaterial;
                   
        }
        
    }

}
