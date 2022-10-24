using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace Twenty.SOGameEvents
{
    public abstract class BaseGameEventListener<TParameter, TGameEvent, TUnityEvent> : MonoBehaviour, IEventListener<TParameter> 
        where TGameEvent : BaseGameEvent<TParameter> where TUnityEvent : UnityEvent<TParameter>
    {
        [Title("Properties")]
        [EnumPaging] [Tooltip("Gameobject will stop listening based on this type")]
        [SerializeField] private UnregisterType unregisterType;
        
        [Space]
        
        [Title("Currently Listening Event")]
        [Tooltip("Game object will listen to this event")] 
        [SerializeField] private TGameEvent gameEvent;
        
        [Title("Response to the Event")]
        [Tooltip("Game object will response this action to the listening event")]
        [SerializeField] private TUnityEvent response;
 
        public void OnEventRaised(TParameter t)
        {
            response.Invoke(t);
        }

        private void OnEnable()
        {
            gameEvent.RegisterListener(this);
        }
 
        private void OnDisable()
        {
            if (unregisterType == UnregisterType.OnDisable) gameEvent.UnRegisterListener(this);
        }

        private void OnDestroy()
        {
            if (unregisterType == UnregisterType.OnDestroy) gameEvent.UnRegisterListener(this);
        }
    }
}