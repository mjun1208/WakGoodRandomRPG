using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class ActorCallBackEvent
{
    public static UnityAction<string, string> ChatCallBackEvent;
    
    public static UnityAction<int, Vector3, float> LocationCallBackEvent;
}
