using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WRR
{
    public class UIManager : MonoBehaviour
    {
        public UIChattingWindow UIChattingWindow => _uiChattingWindow;

        [SerializeField] private UIChattingWindow _uiChattingWindow;

        private void Awake()
        {
            Global.Instance.SetUIManager(this);
        }
    }
}
