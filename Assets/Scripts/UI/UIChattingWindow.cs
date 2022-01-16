using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using WRR;
using WRR.Server;

public class UIChattingWindow : MonoBehaviour
{
    [SerializeField] private InputField _inputField;
    [SerializeField] private ScrollRect _chatScrollRect;
    [SerializeField] private Transform _chatContents;
    [SerializeField] private UIChatItem _chatItem;

    private void Start()
    {
        _inputField.onEndEdit.AddListener(Send);
    }

    private void Show()
    {
        this.gameObject.SetActive(true);
    }

    private void Hide()
    {
        this.gameObject.SetActive(false);
    }

    private bool IsActive()
    {
        return _inputField.isFocused;
    }

    private void Update()
    {
        // _chatScrollRect.verticalNormalizedPosition = 0;
        
        if (Input.GetKeyDown(KeyCode.Return) && !_inputField.isFocused)
        {
            Debug.Log("focus");
            _inputField.Select();
        }
    }

    private void Send(string msg)
    {
        _inputField.Select();
        _inputField.text = "";
    }

    private void Receive(string nickName, string message)
    {
        var newChatItem = Instantiate(_chatItem, _chatContents);

        newChatItem.SetText($"{nickName} : {message}");
        
        _chatScrollRect.verticalNormalizedPosition = 0;
    }
}
