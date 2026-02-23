using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    public static WorldManager Instance;


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        GlobalFuncs.InitCamera();//todo: move call to NewGame in MainMenu, when it's added.
    }
}
