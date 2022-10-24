using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Twenty.SOGameEvents
{
    [System.Serializable]
    public abstract class BaseGameEvent<TParameter> : ScriptableObject
    {
        #region Listeners

        [SerializeField] private bool showListeners;
        [ShowInInspector] [ShowIf("showListeners")] [Required("Need an event to broadcast!")] 
        private List<IEventListener<TParameter>> eventListeners = new();

        #endregion

        [Button(ButtonSizes.Medium)]
        public void Raise(TParameter t)
        {
            for (int i = eventListeners.Count - 1; i >= 0; i--)
            {
                eventListeners[i].OnEventRaised(t);
            }
        }
        
        public void RegisterListener(IEventListener<TParameter> listener)
        {
            if (!eventListeners.Contains(listener)) { eventListeners.Add(listener); }
        }
        
        public void UnRegisterListener(IEventListener<TParameter> listener)
        {
            if (eventListeners.Contains(listener)) { eventListeners.Remove(listener); }
        }
    }
}