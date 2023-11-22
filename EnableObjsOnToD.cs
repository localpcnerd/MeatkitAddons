using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableObjsOnToD : MonoBehaviour {

	[HeaderAttribute("PLACE ME NEXT TO THE ToD MANAGER + CHECK TOOLTIPS FOR INFO")]
	[Tooltip("The minimum time in hours when objects start getting enabled. ex. 11pm = 23")] public float minEnabledTime = 23;
    [Tooltip("The maximum time in hours when objects start getting disabled. ex. 5am = 5")] public float maxEnabledTime = 5;
    [Tooltip("The ToD asset has defined values for if it's night or day. Enabling this will use those values instead of predefined mins and maxes.")] public bool useStaticDayNight;
    [Header("")]
    [Tooltip("Use a generic gameobject.SetActive() method. useful for non-light related components.")] public bool useGameObjects = false;
	public GameObject[] ObjsToEnable;
    [Tooltip("Target lights specifically with light.enabled.")] public bool useLights = true;
	public Light[] lightsToEnable;

	private TOD_Sky todsky;

	void Start () 
	{
		todsky = GetComponent<TOD_Sky>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(todsky != null)
		{
			if(!useStaticDayNight)
			{
                if (minEnabledTime < todsky.Cycle.Hour && todsky.Cycle.Hour <= maxEnabledTime)
                {
                    if (useGameObjects)
                    {
                        foreach (GameObject obj in ObjsToEnable)
                        {
                            obj.SetActive(true);
                        }
                    }

                    if (useLights)
                    {
                        foreach (Light l in lightsToEnable)
                        {
                            l.enabled = true;
                        }
                    }
                }
                else
                {
                    if (useGameObjects)
                    {
                        foreach (GameObject obj in ObjsToEnable)
                        {
                            obj.SetActive(false);
                        }
                    }

                    if (useLights)
                    {
                        foreach (Light l in lightsToEnable)
                        {
                            l.enabled = false;
                        }
                    }
                }
            }
            else
            {
                if(todsky.IsNight)
                {
                    if (useGameObjects)
                    {
                        foreach (GameObject obj in ObjsToEnable)
                        {
                            obj.SetActive(true);
                        }
                    }

                    if (useLights)
                    {
                        foreach (Light l in lightsToEnable)
                        {
                            l.enabled = true;
                        }
                    }
                }
                else if(todsky.IsDay)
                {
                    if (useGameObjects)
                    {
                        foreach (GameObject obj in ObjsToEnable)
                        {
                            obj.SetActive(false);
                        }
                    }

                    if (useLights)
                    {
                        foreach (Light l in lightsToEnable)
                        {
                            l.enabled = false;
                        }
                    }
                }
                else
                {
                    if (useGameObjects)
                    {
                        foreach (GameObject obj in ObjsToEnable)
                        {
                            obj.SetActive(false);
                        }
                    }

                    if (useLights)
                    {
                        foreach (Light l in lightsToEnable)
                        {
                            l.enabled = false;
                        }
                    }
                }
            }
		}
		else
		{
			Debug.LogError("EnableObjsOnToD - Script was unable to find the ToDSky component, contact local because he probably broke something somewhere");
		}
	}
}
