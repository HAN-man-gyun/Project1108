using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManagerYoo : MonoBehaviour
{
    // 유준호 11/13 인풋매니저 보류
    private const string KEY_UP = "UpKey";
    private const string KEY_DOWN = "DownKey";
    private const string KEY_LEFT = "LeftKey";
    private const string KEY_RIGHT = "RightKey";
    private const string KEY_JUMP = "JumpKey";

    private const string ORIGIN_UP = "UpArrow";
    private const string ORIGIN_DOWN = "DownArrow";
    private const string ORIGIN_LEFT = "LeftArrow";
    private const string ORIGIN_RIGHT = "RightArrow";
    private const string ORIGIN_JUMP = "Z";

    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";
    private const string GET_AXIS_ERROR = "해당 InputManager에서 반환 값으로 지정되지 않은 텍스트 입니다.";

    public InputManagerYoo Instance;
    private float horizon;
    private float vertical;

    public KeyCode Up;
    public KeyCode Down;
    public KeyCode Left;
    public KeyCode Right;
    public KeyCode Jump;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else if(Instance != this)
        {
            Destroy(gameObject);
        }

        Up = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString(KEY_UP, ORIGIN_UP));
        Down = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString(KEY_DOWN, ORIGIN_DOWN));
        Left = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString(KEY_LEFT, ORIGIN_LEFT));
        Right = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString(KEY_RIGHT, ORIGIN_RIGHT));
        Jump = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString(KEY_JUMP, ORIGIN_JUMP));
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public float GetAxis(string name)
    {
        if(name == HORIZONTAL)
        {
            return horizon;
        }
        else if(name == VERTICAL)
        {
            return vertical;
        }
        else
        {
            Debug.LogError(GET_AXIS_ERROR);
            return 0;
        }
    }

    private void SetHorizon()
    {

    }

    private void SetVertical()
    {

    }
}