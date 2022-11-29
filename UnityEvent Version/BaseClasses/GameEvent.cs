using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Twenty.SOGameEvents
{
    [System.Serializable]
    [CreateAssetMenu(menuName = "SO Game Events / Game Event", order = 0)]
    public class GameEvent : ScriptableObject
    {
        #region Listeners 
        [SerializeField] private bool showListeners;
        [ShowInInspector] [ShowIf("showListeners")] [Required("Need an event to broadcast!")] 
        private List<GameEventListener> eventListeners = new();
        #endregion

        [Button(ButtonSizes.Medium)]
        public void Raise()
        {
            for (int i = eventListeners.Count-1; i >= 0; i--)
            {
                eventListeners[i].OnEventRaised();
            }
        }

        public void AddListener(GameEventListener listenerVoid)
        {
            if (!eventListeners.Contains(listenerVoid))
                eventListeners.Add(listenerVoid);
        }

        public void RemoveListener(GameEventListener listenerVoid)
        {
            if (eventListeners.Contains(listenerVoid))
                eventListeners.Remove(listenerVoid);
        }
    }
}