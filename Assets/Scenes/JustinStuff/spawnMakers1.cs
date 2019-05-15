using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;
using System;
using System.IO;
using Mapbox.Utils;
using Mapbox.Unity.Map;
using Mapbox.Unity.Utilities;
using System.Linq;
using UnityEngine.Networking;
using Newtonsoft.Json.Linq;

public class spawnMakers1 : MonoBehaviour {
    [SerializeField]
    AbstractMap _map;
    [SerializeField]
    GameObject _markerPrefab;

    [SerializeField]
    public string latitudeStart = " -85.588330";

    [SerializeField]
    public string longitudeStart = " 42.931587";

    [SerializeField]
    public string latitudeEnd = "  -85.588330";

    [SerializeField]
    public string longitudeEnd = " 42.931587";


    List<Graph> listofNodes = new List<Graph> ();

    public List<String> listofLatlong = new List<String> ();

    public static List<GameObject> objectsList = new List<GameObject> ();

    public static List<Vector2d> coordList = new List<Vector2d> ();

public int getList(){
    return listofNodes.Count;
}
public int getListStrings(){
    return listofLatlong.Count;
}


public spawnMakers1 (){}
private IEnumerator getCurrentPos(){
        if (!Input.location.isEnabledByUser){
            yield break;
        }


        // Start service before querying location
        Input.location.Start();

        // Wait until service initializes
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        // Service didn't initialize in 20 seconds
        if (maxWait < 1)
        {
            print("Timed out");
            yield break;
        }

        // Connection has failed
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            print("Unable to determine device location");
            yield break;
        }
        else
        {
           longitudeStart = Input.location.lastData.longitude.ToString();
           latitudeStart=Input.location.lastData.latitude.ToString();
            // GET CURRENT LOCATION LATITUDE
            Debug.Log("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);
        }

        // Stop service if there is no need to query location updates continuously
       yield break;


}

public int getDirection(){
  string url = "https://api.mapbox.com/directions/v5/mapbox/walking/"
  + latitudeStart + "%2C" + longitudeStart + "%3B" + latitudeEnd + "%2C" + longitudeEnd  +".json?access_token=pk.eyJ1IjoianVzdGluYmFza2FyYW4iLCJhIjoiY2pxaWd5cmZhMHVsczN4cHNoMW80b25kNiJ9.hsItXmXBZpnCKxA-mzKX8A&steps=true&overview=full&geometries=geojson";
  listofNodes.Clear();
  coordList.Clear();
  StartCoroutine(getCurrentPos());
  StartCoroutine(GetRequest(url));
  return listofNodes.Count;
  //return this.coordList;
}

public void deleteNodes(){
   for (int i = 0; i < listofNodes.Count; i++)
      {
        Destroy(listofNodes[i].objects,1);
      }
}
void Start()
{
  //getDirection();
}

IEnumerator GetRequest(string uri)
{
    UnityWebRequest uwr = UnityWebRequest.Get(uri);
    yield return uwr.SendWebRequest();


    if (uwr.isNetworkError)
    {
        Debug.Log("Error While Sending: " + uwr.error);
    }
    else
    {

        Debug.Log("Received: " + uwr.downloadHandler.text);
        string jsonString = uwr.downloadHandler.text;
        var results = JObject.Parse(jsonString);
        // Debug.Log("Routes: "+results["routes"][0]);
        // Debug.Log("Geometry: "+results["routes"][0]["geometry"]);
        // Debug.Log("coordinates: "+results["routes"][0]["geometry"]["coordinates"]);
        // Debug.Log("coordinates[0]: "+results["routes"][0]["geometry"]["coordinates"][0]);
        int counter = 0;
        while (true){
          try {
          var temp = results["routes"][0]["geometry"]["coordinates"][counter].ToString();
          temp = temp.Replace("[", "");
          temp = temp.Replace("]", "");
          List<string> names = temp.Split(',').ToList<string>();
          names.Reverse();

          Graph a = new Graph();
          a.latlon = names[0] + ","+ names[1];
          listofLatlong.Add(names[0] + ","+ names[1]);
          listofNodes.Add(a);

          counter++;
          } catch (ArgumentOutOfRangeException ae){
            break;
          }
        }
      //  Debug.Log(" SIZE: " + listofNodes.Count);
        for (int i = 0; i < listofNodes.Count; i++)
        {
          var locationString = listofNodes[i].latlon;
          //Debug.Log(" Location1: " + locationString.ToString());
          var instance = Instantiate(_markerPrefab);
          instance.name=i.ToString();
          listofNodes[i].vec2d =Conversions.StringToLatLon(locationString);
          AddCoordToList(Conversions.StringToLatLon(locationString));
          instance.transform.localPosition = _map.GeoToWorldPosition(listofNodes[i].vec2d, true);
          instance.transform.localScale = new Vector3(15, 15, 15);
        listofNodes[i].objects = instance;

        }





    }
  }


private void Update()
{
  //Debug.Log("Count of List: " + listofNodes.Count);
   // listofNodes.Clear();
    try {
      objectsList.Clear();


    for (int i = 0; i < listofNodes.Count; i++)
      {
        var spawnedObject = listofNodes[i].objects;
        var location = listofNodes[i].vec2d;
        spawnedObject.transform.localPosition = _map.GeoToWorldPosition(location, true);
        AdddNodetoList(spawnedObject);

      //  Debug.Log(" objectsList List: " + objectsList.Count);
      //  Debug.Log(" Location2: " + listofNodes[i].vec2d);
      }
    } catch (NullReferenceException ae){
        Debug.Log("Error!");
    }
}
public void AdddNodetoList(GameObject toAdd){
    objectsList.Add(toAdd);
}

public void AddCoordToList(Vector2d toAdd){
  coordList.Add(toAdd);
  // Debug.Log("The official count for coordList is now: " + coordList.Count);
}
public List<Vector2d> CoordList{
  get {
     Debug.Log("The official count for coordList is: " + coordList.Count + " in the getter");
    return coordList;}
}


}
public class Graph{
    public string latlon;

    public Vector2d vec2d;

    public GameObject objects;


}
