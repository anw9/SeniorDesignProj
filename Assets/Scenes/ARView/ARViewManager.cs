using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ARViewManager : MapGameSceneManager
{


    public override void navTapped(GameObject navButt)
    {
      print("Capture SceneManager.navTapped: Activated");
    }
    public override void nodeTapped(GameObject node)
    {
      print("Capture SceneManager.nodeTapped: Activated");
    }
}
