using System;
using System.Collections;
using System.Collections.Generic;
using Enum;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class NotificationService : MonoBehaviour
{
    [SerializeField] private Transform notificationPanel;
    [SerializeField] private GameObject textPrefab;
    [SerializeField] private float duration;
    [SerializeField] private Color failureColor;
    [SerializeField] private Color successColor;
    [SerializeField] private Color notificationColor;
    public static Action<Notification> OnMessage;

    private void Start()
    {
        OnMessage += SendMessage;
    }

    public void SendMessage(Notification notification)
    {
        var notificationInstance = Instantiate(textPrefab, notificationPanel).GetComponent<TMP_Text>();
        notificationInstance.text = notification.Message;
        switch (notification.MessageType)
        {
            case EMessageType.FailureMessage:
                notificationInstance.color = failureColor;
                break;
            case EMessageType.NotificationMessage:
                notificationInstance.color = notificationColor;
                break;
            case EMessageType.SuccessMessage:
                notificationInstance.color = successColor;
                break;
        }

        notificationInstance.DOFade(0, duration).OnComplete((() => Destroy(notificationInstance.gameObject)));
    }
}
