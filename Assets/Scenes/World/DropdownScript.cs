
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class DropdownScript : MonoBehaviour
{

  public Dropdown dropdown;
  public Text selectionTest;
  public Text lastDestination;
  private string myDest = "";

  Dictionary<string, string> buildings = new Dictionary<string, string>() {
  {"Mail & Print Services", "-85.587926, 42.937103"},
  {"Physical Plant", "-85.587011, 42.936854"},
  {"Huizenga Tennis and Track", "-85.590348, 42.933482"},
  {"Speolhof Fieldhouse", "-85.589012,42.932834"},
  {"Van Noord Arena",  "-85.589166, 42.933572"},
  {"Engineering Building", "-85.589720, 42.931600"},
  {"North Hall", "-85.588694, 42.931688"},
  {"Science Building", "-85.588678, 42.930898"},
  {"DeVries Hall", "-85.589280, 42.930833"},
  {"Speolhof College Center", "-85.589214, 42.929521"},
  {"Chapel", "-85.588522, 42.929432"},
  {"Hiemenga Hall", "-85.588408, 42.930119"},
  {"Hekman Library", "-85.587189, 42.929983"},
  {"Commons Annex", "-85.587253, 42.930421"},
  {"Commons Building", "-85.587399, 42.930984"},
  {"Covenant Fine Arts Center", "-85.586447, 42.930516"},
  {"Devos Communication Center", "-85.583556, 42.929910"},
  {"Prince Conference Center", "-85.582344, 42.930104"},
  {"Bunker Interperative Center", "-85.582404, 42.931854" }
};

  public void DropdownValueChanged(int index)
  {
    string realCoord = buildings.Values.ElementAt(index);
    string realLoc = buildings.Keys.ElementAt(index);
    myDest = realCoord;
    selectionTest.text = myDest;
    lastDestination.text = realLoc;
  }

  public string MyDest{
    get {return myDest; }
  }



  void Start()
  {
    PopulateList();
  }

  void PopulateList()
  {
    //TODO: Read These values in from manual input

    dropdown.AddOptions(buildings.Keys.ToList());
  }

}
