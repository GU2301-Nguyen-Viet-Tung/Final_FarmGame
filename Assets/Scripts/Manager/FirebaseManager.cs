using System;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;

public class FirebaseManger : ISingleton<FirebaseManger>
{

    public bool IsInit { get; private set; }

    private FirebaseApp App;
    private DatabaseReference DataReference;

    public FirebaseManger()
    {
        IsInit = false;
    }

    public void InitFirebase()
    {
        Debug.Log("FirebaseManger start init! ");
        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            Firebase.DependencyStatus dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available)
            {
                App = Firebase.FirebaseApp.DefaultInstance;
                Debug.Log("FirebaseManger Unity SDK init success! ");
                IsInit = true;
                DataReference = FirebaseDatabase.DefaultInstance.RootReference;

            }
            else
            {
                Debug.LogWarning("FirebaseManger Unity SDK is not safe to use here");
            }
        });
    }

    public void WriteProfileData(string key, string data)
    {
        if (IsInit)
        {
            Debug.Log($"FirebaseManger WriteProfileData data = {data}");
            System.Threading.Tasks.Task rs = DataReference.Child("PlayerData/"+key).SetRawJsonValueAsync(data);
        }
    }

    public void ReadProfileData(string key, Action<bool, string> callback)
    {
        if (IsInit)
        {
            Debug.Log("FirebaseManger ReadProfileData ");
            FirebaseDatabase.DefaultInstance.GetReference("PlayerData/"+key).GetValueAsync().ContinueWithOnMainThread(task =>
            {
                if (task.IsFaulted)
                {
                    Debug.LogWarning("FirebaseManger Handle the error...");
                    callback?.Invoke(false, null);
                }
                else if (task.IsCompleted)
                {
                    DataSnapshot snapshot = task.Result;
                    Debug.Log($"FirebaseManger Data {snapshot.GetRawJsonValue()}");
                    callback?.Invoke(true, snapshot.GetRawJsonValue());
                }
            });
        }
    }

}
