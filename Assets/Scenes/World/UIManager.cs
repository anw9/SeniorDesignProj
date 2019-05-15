using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;

public class UIManager : MonoBehaviour
{
  [SerializeField] private Text locationText;
  [SerializeField] private GameObject menu;
  [SerializeField] private GameObject nav;
  [SerializeField] private GameObject arCam;
  [SerializeField] private GameObject arMenu;
  [SerializeField] private GameObject mainCam;
  [SerializeField] private GameObject gui;
  [SerializeField] private GameObject player;


  private void Awake() {

    Assert.IsNotNull(locationText);
    Assert.IsNotNull(menu);
    Assert.IsNotNull(nav);
    Assert.IsNotNull(arCam);
    Assert.IsNotNull(arMenu);
    Assert.IsNotNull(mainCam);
    Assert.IsNotNull(gui);
    Assert.IsNotNull(player);

  }

  public void updateLocation(string newLocation) {
    locationText.text = newLocation.ToString();
  }
  public void toggleMenu() {
    menu.SetActive(!menu.activeSelf);
  }
  public void untoggleMenu()
  {
    menu.SetActive(!menu.activeSelf);
  }
  public void toggleNavView()
  {
    nav.SetActive(!nav.activeSelf);
    gui.SetActive(!gui.activeSelf);
  }
  public void untoggleNavView()
  {
    nav.SetActive(!nav.activeSelf);
  }
  public void toggleNonAR(){

    nav.SetActive(!nav.activeSelf);
    menu.SetActive(!menu.activeSelf);
    arCam.SetActive(!arCam.activeSelf);
    mainCam.SetActive(!mainCam.activeSelf);
    arMenu.SetActive(!arMenu.activeSelf);
    player.SetActive(!player.activeSelf);

  }
  public void untoggleAr(){
    arMenu.SetActive(!arMenu.activeSelf);
    mainCam.SetActive(!mainCam.activeSelf);
    arCam.SetActive(!arCam.activeSelf);
    gui.SetActive(!gui.activeSelf);
    player.SetActive(!player.activeSelf);
  }

  private void OnButtonPush()
  {
    MapGameSceneManager[] managers = FindObjectsOfType<MapGameSceneManager>();
    foreach( MapGameSceneManager mapGameSceneManager in managers){
      if ( mapGameSceneManager.gameObject.activeSelf ){
        mapGameSceneManager.navTapped(this.gameObject);
      }

    }
  }



}
