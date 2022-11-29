using System;
using UnityEngine;
using UnityEngine.Events;

namespace Twenty.SOGameEvents
{
    [AddComponentMenu("SO Events / Enum Event Listener", order: 3)]
    public class EnumGameEventListener : BaseGameEventListener<Enum, BaseGameEvent<Enum>, UnityEvent<Enum>>
    {
        
    }
}