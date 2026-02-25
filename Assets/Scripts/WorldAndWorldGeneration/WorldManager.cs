using System.Collections.Generic;
using UnityEngine;
public class Floats
{
    public float jump1;
    public float jump2;
    public float jump3;
    public float jump4;
}

public class WorldManager : MonoBehaviour
{
    public static WorldManager Instance;

    private List<Floats> jumpHeights = new List<Floats>();
    private int i = 0;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        GlobalFuncs.InitCamera();//todo: move call to NewGame in MainMenu, when it's added.
        jumpHeights.Add(new Floats());
    }

    public void SetHeight(int index, float height)
    {
        switch (index)
        {
         case 1:
             jumpHeights[jumpHeights.Count-1].jump1 = height;
             i++;
             break;
         case 2:
             jumpHeights[jumpHeights.Count-1].jump2 = height;
             i++;
             break;
         case 3:
             jumpHeights[jumpHeights.Count-1].jump3 = height;
             i++;
             break;
         case 4:
             jumpHeights[jumpHeights.Count-1].jump4 = height;
             i++;
             break;
         default:
             break;
        }
        if (i == 3)
        {
            i = 0;
            Debug.Log("1. Base+Ticks: "+jumpHeights[jumpHeights.Count-1].jump1+
                      "2. Coroutine: "+jumpHeights[jumpHeights.Count-1].jump2+
                      "3. MaxHeight: "+jumpHeights[jumpHeights.Count-1].jump3+
                      "4. Stopper: "+jumpHeights[jumpHeights.Count-1].jump4);
            jumpHeights.Add(new Floats());
        }
    }
}
