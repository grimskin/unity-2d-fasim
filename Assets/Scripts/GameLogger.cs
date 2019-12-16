using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public static class GameLogger
{
    private static GameObject _logText;
    private static Text _textArea;
    
    public static void Log(object message)
    {
        Debug.Log(message);

        if (ReferenceEquals(_logText, null))
        {
            _logText = GameObject.Find("LogPanel/TextContainer/ScrollableText");
            _textArea = _logText.GetComponent<Text>();
        }
        _textArea.text = message + "\n" + _textArea.text;
    }
}
