
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System;
using Mapbox.Map;
using Mapbox.Utils;
using Mapbox.Unity.MeshGeneration.Factories;
using Mapbox.Unity.Map;
using Mapbox.Unity.Utilities;
using Utils;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;
using UnityEngine.Networking;




public class Player : MonoBehaviour
{
  private string startLoc = "0,0";
  [SerializeField] private List<Vector2d> myPath;
  [SerializeField] AbstractMap _map;


  public string StartLoc{
    get { return startLoc; }
  }

  public void setStart(string newStart){
  this.startLoc = newStart.ToString();
  }

  public void setList(List<Vector2d> newPath){
    if(myPath != null){
      myPath.Clear();
    }
    foreach(Vector2d obj in newPath){
      myPath.Add(obj);
    }

  }
  public List<Vector2d> getMyList()
  {
    return myPath;
  }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
