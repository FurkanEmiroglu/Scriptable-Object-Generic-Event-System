using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public abstract class GameEventGeneric<T> : ScriptableObject
{
    [PropertySpace(8,8)]
    [TitleGroup("Description", default, TitleAlignments.Centered, false, true, false, 0)]
    [HideLabel] [SerializeField] [TextArea] private string description;
    
#if UNITY_EDITOR
    [BoxGroup("Test Invocation Order", default, true, 2000)]
    [ShowInInspector] private bool showListeners;

    [BoxGroup("Test Invocation Order")]
    [ShowInInspector] [OnValueChanged("ReorderInvocations")] [ShowIf("showListeners")] private List<Action<T>> listenerList = new List<Action<T>>();
#endif
    
    private event Action<T> @event;

    public void Raise(T t)
    {
        @event?.Invoke(t);
    }
    
    public void AddListener(Action<T> method)
    {
        @event += method;
        
#if UNITY_EDITOR
        listenerList.Add(method);
#endif
    }

    public void RemoveListener(Action<T> method)
    {
        @event -= method;
        
#if UNITY_EDITOR
        listenerList.Remove(method);
#endif
    }

#if UNITY_EDITOR
    [PropertySpace(8,8)]
    [Button(ButtonSizes.Medium)]
    private void TestTheEvent(T t)
    {
        Raise(t);
    }
    
    private void ReorderInvocations()
    {
        @event = null;
        GC.Collect();
        
        listenerList.ForEach(action => @event += action);
    }
#endif
}