using UnityEngine;
using UnityEngine.Events;

namespace Twenty.SOGameEvents
{
    [AddComponentMenu("SO Events / String Event Listener", order: 5)]
    public class StringGameEventListener : BaseGameEventListener<string, BaseGameEvent<string>, UnityEvent<string>>
    {
        
    }
}