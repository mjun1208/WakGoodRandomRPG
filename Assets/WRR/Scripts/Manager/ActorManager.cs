using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WRR;

public class ActorManager
{
    public Dictionary<int, DummyActor> DummyActors { get; private set; }

    public void Initialize()
    {
        ActorCallBackEvent.LocationCallBackEvent += SetActorLocation;

        DummyActors = new Dictionary<int, DummyActor>();
    }

    public void SetActorLocation(int accountID, Vector3 position, float rotation)
    {
        if (DummyActors.ContainsKey(accountID))
        {
            DummyActors[accountID].SetPosition(position, rotation);
        }
        else
        {
            var dummyActor = GameObject.Instantiate(Resources.Load<DummyActor>("DummyActor"), position,
                Quaternion.Euler(0, rotation, 0));
            
            DummyActors.Add(accountID, dummyActor);
        }
    }
}
