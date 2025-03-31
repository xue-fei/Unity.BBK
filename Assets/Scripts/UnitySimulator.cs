using BBKRPGSimulator;
using BBKRPGSimulator.Graphics;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#if !UNITY_EDITOR && UNITY_WEBGL
using System.Runtime.InteropServices;
#endif

public class UnitySimulator : MonoBehaviour
{
    private RPGSimulator _simulator;
    public Image image;
    public Texture2D texture2D;
    public static UnitySimulator Instance;
    public GameObject ScrollView;
    public Toggle togglePrefab;

#if !UNITY_EDITOR && UNITY_WEBGL
    [DllImport("__Internal")]
    private static extern bool IsMobile();
#endif

    private void Awake()
    {
        Instance = this;
        togglePrefab.gameObject.SetActive(false);
        image.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        var isMobile = false;
#if !UNITY_EDITOR && UNITY_WEBGL
        isMobile = IsMobile();
#endif
        Debug.Log("isMobile:" + isMobile);
        StartCoroutine(Tool.LoadString(Application.streamingAssetsPath + "/gamelist.json", delegate (string json)
        {
            try
            {
                GameList gameList = JsonUtility.FromJson<GameList>(json);
                foreach (string name in gameList.Names)
                {
                    Toggle toggle = Instantiate(togglePrefab, togglePrefab.transform.parent);
                    toggle.name = name;
                    toggle.transform.Find("Label").GetComponent<Text>().text = name;
                    toggle.onValueChanged.AddListener((value) =>
                    {
                        if (value)
                        {
                            ScrollView.SetActive(false);
                            StartGame(name);
                            image.gameObject.SetActive(true);
                        }
                    });
                    toggle.gameObject.SetActive(true);
                }
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }
        }));
    }

    void StartGame(string name)
    {
        Application.targetFrameRate = 30;
        Application.runInBackground = true;
        texture2D = new Texture2D(160, 96, TextureFormat.ARGB32, false);
        image.material.mainTexture = texture2D;
        _simulator = gameObject.AddComponent<RPGSimulator>();
        _simulator.RenderFrame += GameViewRenderFrame;
        string libPath = Application.streamingAssetsPath + "/Game/" + name + ".lib";
        Debug.LogWarning("libPath:" + libPath);
        StartCoroutine(Tool.LoadData(libPath, delegate (byte[] data)
        {
            if (data != null)
            {
                Debug.Log("GameName:" + Utilities.GetGameName(data));
                var options = new SimulatorOptions()
                {
                    LibData = data,
                };
                _simulator.Launch(options);
            }
            else
            {
                Debug.LogError("加载游戏lib失败");
            }
        }));
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    _simulator.KeyPressed(SimulatorKeys.KEY_ENTER);
        //}
        //if (Input.GetMouseButtonUp(0))
        //{
        //    _simulator.KeyReleased(SimulatorKeys.KEY_ENTER);
        //}
        if (Input.GetKeyDown(KeyCode.Return))
        {
            _simulator.KeyPressed(SimulatorKeys.KEY_ENTER);
        }
        if (Input.GetKeyUp(KeyCode.Return))
        {
            _simulator.KeyReleased(SimulatorKeys.KEY_ENTER);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _simulator.KeyPressed(SimulatorKeys.KEY_ENTER);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            _simulator.KeyReleased(SimulatorKeys.KEY_ENTER);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _simulator.KeyReleased(SimulatorKeys.KEY_CANCEL);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            _simulator.KeyPressed(SimulatorKeys.KEY_UP);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            _simulator.KeyPressed(SimulatorKeys.KEY_UP);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            _simulator.KeyPressed(SimulatorKeys.KEY_DOWN);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _simulator.KeyPressed(SimulatorKeys.KEY_DOWN);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            _simulator.KeyPressed(SimulatorKeys.KEY_LEFT);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _simulator.KeyPressed(SimulatorKeys.KEY_LEFT);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            _simulator.KeyPressed(SimulatorKeys.KEY_RIGHT);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _simulator.KeyPressed(SimulatorKeys.KEY_RIGHT);
        }
    }

    private void GameViewRenderFrame(ImageBuilder frameData)
    {
        try
        {
            texture2D.LoadRawTextureData(frameData.Data);
            texture2D.Apply();
        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }
    }

    private void OnApplicationQuit()
    {
        if (_simulator != null)
        {
            _simulator.Stop();
        }
    }
}

[Serializable]
public class GameList
{
    public List<string> Names = new List<string>();
}