using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameConfig
{

}

public static class GameConstant
{
    public static string SCENE_LOADING = "LoadingScene";
    public static string SCENE_MAINMENU = "MenuScene";
    public static string SCENE_GAMEPLAY = "GameplayScene";
    public static string SCENE_LOBBY = "LobbyScene";
    public static string SCENE_MULTIPLAYER = "MultiplayerScene";
    public static string TAG_CROP = "Crop";
    public static string TAG_PLAYER = "Player";
}
public static class LoadingData
{
    public static string sceneToLoad = GameConstant.SCENE_MAINMENU;
}
