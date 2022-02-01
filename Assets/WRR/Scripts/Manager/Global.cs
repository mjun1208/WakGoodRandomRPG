using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WRR
{
    public class Global : MonoBehaviour
    {
        public static Global Instance
        {
            get
            {
                if (_instance == null)
                {
                    return null;
                }

                return _instance;
            }
        }
        
        public static UIManager UIManager => _uiManager;
        public static ActorManager ActorManager => _actorManager;
        
        private static Global _instance;
        private static UIManager _uiManager;
        private static ActorManager _actorManager;

        public static Actor MyActor { get; private set; }

        private void Awake()
        {
            _instance = this;
            
            _actorManager = new ActorManager();
            _actorManager.Initialize();
        }

        public void SetMyActor(Actor actor)
        {
            MyActor = actor;
        }
        
        public void SetUIManager(UIManager uiManager)
        {
            _uiManager = uiManager;
        }
    }
}