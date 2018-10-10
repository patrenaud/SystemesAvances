using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using System;

public class SaveManager : MonoBehaviour
{
    private string SAVE_FILE_PATH;

    private class SaveData
    {
        public float X;
        public float Y;
    }

    private class SaveDataUnity
    {
        public Sprite monSprite;
    }

    private static SaveManager m_Instance = null;
    public static SaveManager Instance
    {
        get
        {
            return m_Instance;
        }
    }

    private void Awake()
    {
        if(m_Instance == null)
        {
            SAVE_FILE_PATH = Application.persistentDataPath + "/save.json";

            m_Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Save()
    {
        var player = FindObjectOfType<PlayerController>();

        var save = new SaveData
        {
            X = player.transform.position.x,
            Y = player.transform.position.y,
        };

        File.WriteAllText(SAVE_FILE_PATH, JsonConvert.SerializeObject(save));

        Debug.Log("Saved file at " + SAVE_FILE_PATH);

        SaveUnity();
    }

    private void SaveUnity()
    {
        var player = FindObjectOfType<PlayerController>();

        var save = new SaveDataUnity
        {
            monSprite = player.GetComponent<SpriteRenderer>().sprite
        };

        File.WriteAllText(SAVE_FILE_PATH+"2", JsonUtility.ToJson(save));

        Debug.Log("Saved file at " + SAVE_FILE_PATH);
    }

    public void Load()
    {
        try
        {
            string json = File.ReadAllText(SAVE_FILE_PATH);

            var save = JsonConvert.DeserializeObject<SaveData>(json);

            var player = FindObjectOfType<PlayerController>();
            player.transform.position = new Vector3(save.X, save.Y);
        }
        catch(Exception ex)
        {
            Debug.LogError("Exception: " + ex);
        }

        LoadUnity();
    }

    public void LoadUnity()
    {
        try
        {
            string json = File.ReadAllText(SAVE_FILE_PATH+"2");

            var save = JsonUtility.FromJson<SaveDataUnity>(json);

            var player = FindObjectOfType<PlayerController>();
            player.GetComponent<SpriteRenderer>().sprite = save.monSprite;
        }
        catch (Exception ex)
        {
            Debug.LogError("Exception: " + ex);
        }
    }
}
