using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldSceneManager : MapGameSceneManager
{
  private GameObject player;
  private AsyncOperation loadScene;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void navTapped(GameObject navButt)
    {
      SceneManager.LoadScene(MapGameConstants.SCENE_ARVIEW, LoadSceneMode.Additive);

    }
    public override void nodeTapped(GameObject node)
    {

    }
}
