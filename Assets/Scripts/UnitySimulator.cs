using BBKRPGSimulator;
using BBKRPGSimulator.Graphics;
using System;
using UnityEngine;
using UnityEngine.UI;

public class UnitySimulator : MonoBehaviour
{
    private RPGSimulator _simulator;
    public Image image;
    public Texture2D texture2D;
    public static UnitySimulator Instance;

    private void Awake()
    {
        Instance = this; 
    }

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 30;
        Application.runInBackground = true;
        texture2D = new Texture2D(160, 96, TextureFormat.ARGB32, false);
        image.material.mainTexture = texture2D;
        _simulator = gameObject.AddComponent<RPGSimulator>();
        _simulator.RenderFrame += GameViewRenderFrame;
        string libPath = Application.streamingAssetsPath + "/Game/xkx.lib";
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
                Debug.LogError("”Œœ∑libº”‘ÿ ß∞‹");
            }
        }));
    }

    // Update is called once per frame
    void FixedUpdate()
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
        _simulator.Stop();
    }
}