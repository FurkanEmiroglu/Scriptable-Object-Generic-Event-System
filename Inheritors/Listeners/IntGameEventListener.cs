using UnityEngine;
using UnityEngine.Events;

namespace Twenty.SOGameEvents
{
    [AddComponentMenu("SO Events / Int Event Listener", order: 1)]
    public class IntGameEventListener : BaseGameEventListener<int, BaseGameEvent<int>, UnityEvent<int>>
    {
        
    }
}