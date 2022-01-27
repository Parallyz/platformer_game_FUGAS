
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
public static class SaveSystem
{
    public static void SaveGame()
    {
        string path = Application.persistentDataPath + "/player.fun";
        PlayerData data = new PlayerData();

        if (!File.Exists(path))
        {
            SaveToFile(path, data);
        }

        else
        {
            PlayerData oldData = LoadPlayer();
            oldData.coins += data.coins;
            oldData.keys += data.keys;
            SaveToFile(path, oldData);

        }

    }
    private static void SaveToFile(string path, PlayerData data)
    {
        BinaryFormatter formatter = GetBinaryFormater();
        using (FileStream stream = new FileStream(path, FileMode.Create))
        {
            formatter.Serialize(stream, data);
        }





    }

    public static BinaryFormatter GetBinaryFormater()
    {
        return new BinaryFormatter();
    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.fun";
        if (File.Exists(path))
        {
            PlayerData data;
            BinaryFormatter formatter = GetBinaryFormater();
            using (FileStream stream = new FileStream(path, FileMode.Open))
            {
                data = formatter.Deserialize(stream) as PlayerData;
            }
            return data;
        }
        return null;
    }
}
