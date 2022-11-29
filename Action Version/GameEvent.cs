using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Event / Action")]
public class GameEvent : ScriptableObject
{
    [PropertySpace(8,8)]
    [TitleGroup("Description", default, TitleAlignments.Centered, false, true, false, 0)]
    [HideLabel] [SerializeField] [TextArea] private string description;
    
#if UNITY_EDITOR
    [BoxGroup("Test Invocation Order", default, true, 2000)]
    [ShowInInspector] private bool showListeners;

    [BoxGroup("Test Invocation Order")]
    [ShowInInspector] [OnValueChanged("ReorderInvocations")] [ShowIf("showListeners")] private List<Action> listenerList = new List<Action>();
#endif
    
    private event Action @event;

    public void Raise()
    {
        @event?.Invoke();
    }
    
    public void AddListener(Action method)
    {
        @event += method;
        
#if UNITY_EDITOR
        listenerList.Add(method);
#endif
    }

    public void RemoveListener(Action method)
    {
        @event -= method;
        
#if UNITY_EDITOR
        listenerList.Remove(method);
#endif
    }

#if UNITY_EDITOR
    [PropertySpace(8,8)]
    [Button(ButtonSizes.Medium)]
    private void TestTheEvent()
    {
        Raise();
    }
    
    private void ReorderInvocations()
    {
        @event = null;
        GC.Collect();
        
        listenerList.ForEach(action => @event += action);
    }
#endif
}