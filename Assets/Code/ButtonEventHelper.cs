using System;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public static class ButtonEventHelper
{
    /// <summary>
    /// This is a helper method to quickly add basic actions to the up and down events on a Unity button
    /// </summary>
    /// <param name="button"></param>
    /// <param name="downAction"></param>
    /// <param name="upAction"></param>
    public static void AddUpDownListenersToButton(Button button, Action downAction, Action upAction)
    {
        AddPointerDownListenerToButton(button, new UnityAction<BaseEventData>((e) => downAction()));
        AddPointerUpListenerToButton(button, new UnityAction<BaseEventData>((e) => upAction()));
    }

    public static void AddUpDownListenersToButton(Button button, UnityAction<BaseEventData> downAction, UnityAction<BaseEventData> upAction)
    {
        AddPointerDownListenerToButton(button, downAction);
        AddPointerUpListenerToButton(button, upAction);
    }

    public static void AddPointerDownListenerToButton(Button button, UnityAction<BaseEventData> action)
    {
        EventTrigger trigger = button.gameObject.AddComponent<EventTrigger>();
        var pointerDown = new EventTrigger.Entry();
        pointerDown.eventID = EventTriggerType.PointerDown;
        pointerDown.callback.AddListener(action);
        trigger.triggers.Add(pointerDown);
    }

    public static void AddPointerUpListenerToButton(Button button, UnityAction<BaseEventData> action)
    {
        EventTrigger trigger = button.gameObject.AddComponent<EventTrigger>();
        var pointerDown = new EventTrigger.Entry();
        pointerDown.eventID = EventTriggerType.PointerUp;
        pointerDown.callback.AddListener(action);
        trigger.triggers.Add(pointerDown);
    }
}

