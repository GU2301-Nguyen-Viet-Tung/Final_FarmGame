using System.Collections;
using UnityEngine;
#if UNITY_IOS
using System;
using Unity.Notifications.iOS;
#endif
#if UNITY_ANDROID
using Unity.Notifications.Android;
#endif

public class NotificationManager : ISingleton<NotificationManager>
{
    public bool IsInit { get; private set; }
    public NotificationManager()
    {
        IsInit = false;
    }

    public IEnumerator RequestNotificationPermission()
    {
        Debug.Log("NotificationManager RequestNotificationPermission ");
#if UNITY_ANDROID
        PermissionRequest request = new PermissionRequest();
        while (request.Status == PermissionStatus.RequestPending)
        {
            yield return null;
        }
#endif

#if UNITY_IOS
        AuthorizationOption authorizationOption = AuthorizationOption.Alert | AuthorizationOption.Badge;
        using (AuthorizationRequest req = new AuthorizationRequest(authorizationOption, true))
        {
            while (!req.IsFinished)
            {
                yield return null;
            };

            string res = "\n RequestAuthorization:";
            res += "\n finished: " + req.IsFinished;
            res += "\n granted :  " + req.Granted;
            res += "\n error:  " + req.Error;
            res += "\n deviceToken:  " + req.DeviceToken;
        }
#endif
        IsInit = true;
        yield return null;
    }

    public void SendPN(string title, string message, int time)
    {

#if UNITY_ANDROID
        AndroidNotification notification = new AndroidNotification
        {
            Title = title,
            Text = message,
            FireTime = System.DateTime.Now.AddSeconds(time)
        };

        int id = AndroidNotificationCenter.SendNotification(notification, "channel_id");
        //AndroidNotificationCenter.CancelNotification(id);
#endif

#if UNITY_IOS
        int minutes = time / 60;
        int seconds = time - minutes * 60;

        iOSNotificationTimeIntervalTrigger timeTrigger = new iOSNotificationTimeIntervalTrigger()
        {
            TimeInterval = new TimeSpan(0, minutes, seconds),
            Repeats = false
        };

        iOSNotification notification = new iOSNotification()
        {
            Identifier = "_notification_01",
            Title = title,
            Body = message,
            Subtitle = "",
            ShowInForeground = true,
            ForegroundPresentationOption = (PresentationOption.Alert | PresentationOption.Sound),
            CategoryIdentifier = "category_a",
            ThreadIdentifier = "thread1",
            Trigger = timeTrigger,
        };
        iOSNotificationCenter.ScheduleNotification(notification);
#endif
    }
}
