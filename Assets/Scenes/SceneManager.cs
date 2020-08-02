using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    public GameObject mainCube;
    GameObject g;
    public Text btnText;
    public Text btnRotateText;
    bool isAdd;
    bool isRotateLeft = true;

    public void RotateCube(){
        if(isRotateLeft)
            RotateRight();
        else
            RotateLeft();
    }

    private void RotateLeft(){
        btnRotateText.text = "Rotate Right";
        isRotateLeft = true;
        g.transform.Rotate(0,50f,0,Space.Self);
    }

    private void RotateRight(){
        btnRotateText.text = "Rotate Left";
        isRotateLeft = false;
        g.transform.Rotate(0,-50f,0,Space.Self);
    }

    public void AddRemoveMainCube(){
        if(isAdd){
            RemoveMainCube();
        }else{
            AddMainCube();
        }
    }

    private void AddMainCube(){
        isAdd = true;
        btnText.text = "Remove";
        g = Instantiate(mainCube, new Vector3(0, 0, 0), Quaternion.identity).gameObject;
        g.transform.Rotate(0,25f,0,Space.Self);
    }

    private void RemoveMainCube(){
        isAdd = false;
        btnText.text = "Add";
        Destroy(g);
    }

}
