using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveLoad {
    private static string tutorial = "SceneAlex";
    private static string level = tutorial;
    private static string saveName = "/.save";
    
    public static void Save(string levelName)
    {
        SaveLoad.level = levelName;
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create (Application.persistentDataPath + saveName);
        bf.Serialize(file, SaveLoad.level);
        file.Close();
    }   
     
    public static string Load() {
        if(File.Exists(Application.persistentDataPath + saveName)) 
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + saveName, FileMode.Open);
            SaveLoad.level = (string)bf.Deserialize(file);
            file.Close();
        }
        return SaveLoad.level;
    }
    
    public static void Reset()
    {
        SaveLoad.Save(tutorial);
    } 
}