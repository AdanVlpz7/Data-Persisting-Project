using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Manager : MonoBehaviour
{
    public static Manager Instance;
    public string temporaryName;
    public string userName;
    public int userRecord;
   
    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);
        Load();
    }
    [System.Serializable]
    class SaveData
    {
        public string name;
        public int record;
    }
    public void Save()
    {
        SaveData data = new SaveData();
        data.name = userName;
        data.record = userRecord;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void Load()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            userName = data.name;
            userRecord = data.record;
        }
    }
}
