﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class MenuDisplay : MonoBehaviour {

    public float distanceToCam = 1000f;

	void Update()
    {
        // Get the Vuforia StateManager
        StateManager sm = TrackerManager.Instance.GetStateManager();

        // Query the StateManager to retrieve the list of
        // currently 'active' trackables 
        //(i.e. the ones currently being tracked by Vuforia)
        IEnumerable<TrackableBehaviour> activeTrackables = sm.GetActiveTrackableBehaviours();

        // Iterate through the list of active trackables
        Debug.Log("List of trackables currently active (tracked): ");
        foreach (TrackableBehaviour tb in activeTrackables)
        {
            Debug.Log("Trackable: " + tb.TrackableName);
            GameObject trackable = GameObject.Find(tb.TrackableName);
            Vector3 pos = trackable.transform.position;
            Debug.DrawRay(Camera.main.transform.position, pos);
            transform.position = Camera.main.WorldToScreenPoint(pos) + new Vector3(0f, 0f, distanceToCam);
        }
    }
}