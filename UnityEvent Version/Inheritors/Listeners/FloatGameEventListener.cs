using UnityEngine;
using UnityEngine.Events;

namespace Twenty.SOGameEvents
{
    [AddComponentMenu("SO Events / Float Event Listener", order: 2)]
    public class FloatGameEventListener : BaseGameEventListener<float, BaseGameEvent<float>, UnityEvent<float>>
    {
        
    }
}