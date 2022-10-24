using UnityEngine;
using UnityEngine.Events;

namespace Twenty.SOGameEvents
{
    [AddComponentMenu("SO Events / Bool Event Listener", order: 4)]
    public class BoolGameEventListener : BaseGameEventListener<bool, BaseGameEvent<bool>, UnityEvent<bool>>
    {
        
    }
}