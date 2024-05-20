using System.Collections.Generic;
using System.IO;
using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEditor;
using System.Xml.Linq;
using System.Text;

public class BlockDataManager
{
    private static BlockDataManager instance;

    private BlockDataManager()
    {
        // Json 파일 받아오기
        BlockSO jtc = new BlockSO(); 
        string jsonData = JsonUtility.ToJson(jtc); 
        CreateJsonFile(Application.dataPath + "/Json/BlockData.json", jsonData);
        var jtc2 = LoadJsonFile<BlockSO>(Application.dataPath + "/Json/BlockData.json");

        //string jsonFilePath = Application.dataPath + "/Json/BlockData.json";
        //string jsonText = File.ReadAllText(jsonFilePath);
        //BlockSO asset = new BlockSO();
        //asset = LoadJsonFile<BlockSO>(jsonFilePath);
        //BlockSO asset = AssetDatabase.LoadAssetAtPath("Assets/ScriptableObjects/BlockSO/Block1Data.asset", typeof(BlockSO)) as BlockSO;
        //string jsonSaveText = JsonUtility.ToJson(asset);
        //JsonUtility.FromJsonOverwrite(jsonText, asset);
        AssetDatabase.CreateAsset(jtc2, "Asset/ScriptableObjects/BlockSO/BlockData.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        //Selection.activeObject = asset;
    }
    public static BlockDataManager GetInstance()
    {
        if (instance == null) instance = new BlockDataManager();
        return instance;
    }
    T LoadJsonFile<T>(string loadPath)
    {
        FileStream fileStream = new FileStream(string.Format(loadPath), FileMode.Open); 
        byte[] data = new byte[fileStream.Length];
        fileStream.Read(data, 0, data.Length);
        fileStream.Close(); 
        string jsonData = Encoding.UTF8.GetString(data);
        return JsonUtility.FromJson<T>(jsonData);
    }
    void CreateJsonFile(string createPath, string jsonData)
    {
        FileStream fileStream = new FileStream(string.Format(createPath), FileMode.Create);
        byte[] data = Encoding.UTF8.GetBytes(jsonData); 
        fileStream.Write(data, 0, data.Length); 
        fileStream.Close();    
    }
}