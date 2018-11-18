using Newtonsoft.Json;
using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    static public Game game = new Game();
    static public GameManager instance;

     void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void GetName()
    {
        string name = FindObjectOfType<InputField>().text;
        LoadGame(Application.streamingAssetsPath + "/Resources/");
        game.name= name;
        
    }
    public void SaveGame()
    {
        game.SavingGame();
        string json = JsonConvert.SerializeObject(game);
        SaveSystem.Save(json, game.name);
    }
    public static void LoadGame(string path)
    {
        UIManager.instance.PlayMode();
        string json = SaveSystem.Load(path);
        game = JsonConvert.DeserializeObject<Game>(json);
        game.LoadingGame();

    }
    public static void MovedLoad()
    {
        game.MoveLoad();
    }

}
