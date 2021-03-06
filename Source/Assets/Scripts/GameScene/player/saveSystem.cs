using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class saveSystem
{
    public static void SavePlayer(playerData playerdata)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.sav";

        FileStream stream = new FileStream(path, FileMode.Create);

        playerData data = new playerData(playerdata);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static playerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.sav";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            playerData data =new playerData(formatter.Deserialize(stream) as playerData);
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Sace file not found in " + path);
            return null;
        }

    }

    

}
