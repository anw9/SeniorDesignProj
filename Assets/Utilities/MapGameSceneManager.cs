using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MapGameSceneManager : MonoBehaviour
{
    public abstract void navTapped(GameObject navButt);
    public abstract void nodeTapped(GameObject node);
}
