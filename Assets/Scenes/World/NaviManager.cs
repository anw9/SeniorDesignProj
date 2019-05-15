using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;
using Mapbox.Utils;

public class NaviManager : MonoBehaviour
{

  public Text coordText;

  public List<GameObject> testVec;


    // Start is called before the first frame update
    private spawnMakers1 spawner;
    public void onPush()
    {

      bool threadAllow = false;
      string[] coords = coordText.text.Split(',');
      Debug.Log("The Go button was pushed");
      spawner = GameObject.Find("Map").GetComponent<spawnMakers1>();
      spawner.latitudeEnd = coords[0];
      spawner.longitudeEnd = coords[1];
      spawner.getDirection();



      // Debug.Log("The length of the list in Navi is: " + list.Count);
      //
      // Debug.Log("The length of the object list is: " + spawner.objectsList.Count);
      // Debug.Log("The length of the latlong list is: " +  spawner.getList());
      // Debug.Log("The length of the latlong list is: " +  spawner.listofLatlong.Count);
      //list = spawner.coordList;
      //GameManager.Instance.CurrentPlayer.setList(list);
    }


    void Start()
    {
      testVec = spawnMakers1.objectsList;

    }


    // Update is called once per frame
    void Update()
    {
      testVec = spawnMakers1.objectsList;
      

    }
}
