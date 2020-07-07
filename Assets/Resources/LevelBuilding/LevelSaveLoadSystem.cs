using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class LevelData
{
    public int Height;
    public int Width;
    public int[] Grid;
}

public static class LevelSaveLoadSystem
{
    public static readonly string DirectoryName = "/maps";

    public static void SaveLevel(string levelName, LevelData level)
    {
        string directoryPath = string.Concat(Application.persistentDataPath, $"{DirectoryName}");
        if (!Directory.Exists(directoryPath))
            Directory.CreateDirectory(directoryPath);

        string path = string.Concat(directoryPath, $"/{levelName}.map");
        var formatter = new BinaryFormatter();
        var file = File.Create(path);
        string levelJson = JsonUtility.ToJson(level);
        try
        {
            formatter.Serialize(file, levelJson);
        }
        finally
        {
            file.Close();
        }
    }

    public static LevelData LoadLevel(string levelName)
    {
        string path = string.Concat(Application.persistentDataPath, $"{DirectoryName}/{levelName}.map");

        if (File.Exists(path))
        {
            var formatter = new BinaryFormatter();
            var loadData = new LevelData();
            var file = File.Open(path, FileMode.Open);

            try
            {
                loadData = new LevelData();
                JsonUtility.FromJsonOverwrite(formatter.Deserialize(file).ToString(), loadData);
            }
            finally
            {
                file.Close();
            }
            return loadData;
        }

        return null;
    }
}
