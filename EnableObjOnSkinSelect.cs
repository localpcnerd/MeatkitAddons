using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ModularWorkshop;
#if H3VR_IMPORTED
using FistVR;
#endif

public class EnableObjOnSkinSelect : MonoBehaviour {

    [HeaderAttribute("Hover Over Variables To Read The Tooltips!!!")]

	private ModularFVRFireArm weapon;
    [Tooltip("ID of the skin to enable/disable objects on.")] public string skinID;
	[Tooltip("All objects you want enabled when the skin is selected.")] public GameObject[] objectsEnabled;
    [Tooltip("All objects you want disabled when the skin is selected.")] public GameObject[] objectsDisabled;


    // Update is called once per frame
    void Update () {
		if(weapon == null)
		{
			weapon = GetComponent<ModularFVRFireArm>(); //auto finds weapon script
		}

		if(weapon.CurrentSelectedReceiverSkinID == skinID)
		{
			foreach(GameObject goE in objectsEnabled)
			{
				goE.SetActive(true);
			}

			foreach(GameObject goD in objectsDisabled)
			{
				goD.SetActive(false);
			}
		}
	}
}
