using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{   
    [Header("Main Cube")]
    public GameObject mainCube;
    GameObject g;
    [Header("Buttons")]
    public Text btnText;
    public Text btnRotateText;
    [Header("Materials")]
    public Material selectedMaterial;
    public Material unselectedMaterial;
    bool isAdd;
    public bool isRotateLeft = true;

    public static SceneManager Instance { get; private set; } // static singleton

    void Awake() {
            if (Instance == null) { Instance = this;  }
            else { Destroy(gameObject); }
            // Cache references to all desired variables
    }

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
        btnRotateText.transform.parent.gameObject.SetActive(true);
        btnText.text = "Remove";
        g = Instantiate(mainCube, new Vector3(0, 0, 0), Quaternion.identity).gameObject;
        g.transform.Rotate(0,25f,0,Space.Self);
    }

    private void RemoveMainCube(){
        isAdd = false;
        btnRotateText.transform.parent.gameObject.SetActive(false);
        btnText.text = "Add";
        Destroy(g);
    }

}
