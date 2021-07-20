using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class HandTracking : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (ARSession.state == ARSessionState.SessionTracking)
        {
            FollowPalmCenter();
        }
    }

    private void FollowPalmCenter()
    {

        HandInfo currentlyDetectedHand = ManomotionManager.Instance.Hand_infos[0].hand_info;
        ManoClass currentlyDetectedManoClass = currentlyDetectedHand.gesture_info.mano_class;

        Vector3 palmCenterPosition = currentlyDetectedHand.tracking_info.palm_center;

        if (currentlyDetectedManoClass == ManoClass.GRAB_GESTURE)
        {
            this.transform.position = ManoUtils.Instance.CalculateNewPosition(palmCenterPosition, currentlyDetectedHand.tracking_info.depth_estimation);
        }
    }
}
