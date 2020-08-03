using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityFBXExporter;

public class SceneManager : MonoBehaviour
{   
    [Header("Main Cube")]
    public GameObject mainCube;
    [Header("UI")]
    public Text btnText;
    public Text btnRotateText;
    public Text tagText;
    [Header("Materials")]
    public Material selectedMaterial;
    public Material unselectedMaterial;
    [Header("Parameters")]
    public bool isRotateLeft = true;
    public int duplicateCount = 1;
    public string tag;
    public string fileName;
  
    
    bool isAdd;
    GameObject g;
    MultifunctionCube cubeFunctions;

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
        if(cubeFunctions.duplicate)
            duplicateCount--;
    }

    private void RotateRight(){
        btnRotateText.text = "Rotate Left";
        isRotateLeft = false;
        g.transform.Rotate(0,-50f,0,Space.Self);
        if(cubeFunctions.duplicate)
            duplicateCount++;
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
        cubeFunctions = g.GetComponent<MultifunctionCube>();
        g.transform.Rotate(0,25f,0,Space.Self);
    }

    private void RemoveMainCube(){
        isAdd = false;
        btnRotateText.transform.parent.gameObject.SetActive(false);
        btnText.text = "Add";
        Destroy(g);
    }

    public void ExportToFBX(GameObject objMeshToExport){
        string path = Path.Combine(Application.persistentDataPath, "data");
        path = Path.Combine(path, fileName+ ".fbx");

        //Create Directory if it does not exist
        if (!Directory.Exists(Path.GetDirectoryName(path)))
        {
            Directory.CreateDirectory(Path.GetDirectoryName(path));
        }

        FBXExporter.ExportGameObjToFBX(objMeshToExport, path, true, true);
        }

}
