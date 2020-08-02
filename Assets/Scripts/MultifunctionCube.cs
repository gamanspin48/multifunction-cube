using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultifunctionCube : MonoBehaviour
{   
    public enum Functions{ Duplicate, Add}

    public Functions function;
    public Transform prefab;
    // Start is called before the first frame update
    void Start()
    {
        switch (function)
        {
            case Functions.Duplicate:
                this.gameObject.AddComponent<Lean.Touch.LeanDragTranslate>();
                break;
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {   
        Debug.Log("collide");
        switch (function)
        {   
            case Functions.Duplicate:
                Transform g = Instantiate(collision.gameObject.transform, new Vector3(2 * 2.0F, 0, 0), Quaternion.identity);
                break;
            
        }
    }

}
