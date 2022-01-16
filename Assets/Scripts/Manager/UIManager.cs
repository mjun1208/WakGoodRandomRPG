using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WRR
{
    public class UIManager : MonoBehaviour
    {

        private void Awake()
        {
            Global.Instance.SetUIManager(this);
        }
    }
}
