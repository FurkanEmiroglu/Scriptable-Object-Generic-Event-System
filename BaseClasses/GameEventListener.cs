using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace Twenty.SOGameEvents
{
    [AddComponentMenu("SO Events / Game Event Listener", order: 0)]
    public class GameEventListener : MonoBehaviour
    {
        [Title("Properties")]
        [EnumPaging] [Tooltip("Gameobject will stop listening based on this type")]
        [SerializeField] private UnregisterType unregisterType;
        
        [Space]
        
        [Title("Event to listen & response to that event")]
        [Tooltip("Game object will listen to this event")] 
        [SerializeField] private GameEvent gameEvent;
        
        [Tooltip("Game object will response this action to the listening event")]
        [SerializeField] private UnityEvent response;

        public void OnEventRaised()
        {
            response.Invoke();
        }

        private void OnEnable()
        {
            gameEvent.AddListener(this);
        }

        private void OnDisable()
        {
            if (unregisterType == UnregisterType.OnDisable) gameEvent.RemoveListener(this);
        }

        private void OnDestroy()
        {
            if (unregisterType == UnregisterType.OnDestroy) gameEvent.RemoveListener(this);
        }
    }
}