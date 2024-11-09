using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Siccity.GLTFUtility;
using System.IO;
using System;
using UnityEngine.Networking;
using Unity.Mathematics;

public class LoadFile : MonoBehaviour
{
    GameObject wrapper;
    string filePath;

    private void Start()
    {
        //filePath = $"{Application.persistentDataPath}/Files/";
        filePath = $"C:/Users/Cooper/Downloads/Ship.glb/";
        filePath = "C:/Users/Cooper/Downloads/Ship/result.gltf";
        string m_Path = Application.dataPath;

        Debug.Log("dataPath : " + m_Path);
        Debug.Log(filePath);
        wrapper = new GameObject
        {
            name = "Model"
        };

        ImportGLTFAsync(filePath);
        

    }
   


    void ImportGLTF(string filepath)
    {
        GameObject result = Importer.LoadFromFile(filepath);
    }


    void ImportGLTFAsync(string filepath)
    {
        Importer.ImportGLTFAsync(filepath, new ImportSettings(), OnFinishAsync);
    }

    void OnFinishAsync(GameObject result, AnimationClip[] animations)
    {
        Debug.Log("Finished importing " + result.name);
    }
    string PathGoBack(string path)
    {
        string newPath = Path.GetFullPath(Path.Combine(path, @"..\"));
        return newPath;
    }
    string GoDownPath(string path, string newFolder)
    {
        string newPath = Path.GetFullPath(Path.Combine(path, @"..\"));
        if (File.Exists(newPath))
        {
            return newPath;
        }
        else 
        {
            Debug.Log("Error false path");
            return path;
        }
        
    }
}
