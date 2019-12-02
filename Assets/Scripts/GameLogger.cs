using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameLogger
{
    private static GameObject _logText;
    
    public static void Log(object message)
    {
        Debug.Log(message);

        if (_logText == null)
        {
            _logText = GameObject.Find("LogPanel/TextContainer/ScrollableText");
        }
        _logText.GetComponent<Text>().text = message + "\n" + _logText.GetComponent<Text>().text;
    }
}
