using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if H3VR_IMPORTED
using FistVR;
#endif

public class MultiHandleBoltHandle : ClosedBoltHandle 
{
    [Header("Multiple Rotating Handles")]
    public bool useMultipleHandles;
    public Transform[] handles;
    public Vector3[] leftRots;
    public Vector3[] rightRots;
    public Vector3[] neutralRots;
    public bool[] StayRotOnBack;
    public bool[] UseSoundOnGrab;

    public override void BeginInteraction(FVRViveHand hand)
    {
        for(int i = 0; i < handles.Length; i++)
        {
            if (UseSoundOnGrab[i])
            {
                Weapon.PlayAudioEvent(FirearmAudioEventType.HandleGrab);
            }
        }

        base.BeginInteraction(hand);
    }

    public override void UpdateInteraction(FVRViveHand hand)
    {
        base.UpdateInteraction(hand);
        if (HasRotatingPart)
        {
            Vector3 normalized = (base.transform.position - m_hand.PalmTransform.position).normalized;
            if (Vector3.Dot(normalized, base.transform.right) > 0f)
            {
                RotatingPart.localEulerAngles = RotatingPartLeftEulers;
            }
            else
            {
                RotatingPart.localEulerAngles = RotatingPartRightEulers;
            }
        }

        if(useMultipleHandles)
        {
            for (int i = 0; i < handles.Length; i++)
            {
                Vector3 normalized = (base.transform.position - m_hand.PalmTransform.position).normalized;
                if (Vector3.Dot(normalized, base.transform.right) > 0f)
                {
                    handles[i].localEulerAngles = leftRots[i];
                }
                else
                {
                    handles[i].localEulerAngles = rightRots[i];
                }
            }
        }
    }

    public override void EndInteraction(FVRViveHand hand)
    {
        if (useMultipleHandles && !StaysRotatedWhenBack)
        {
            for(int i = 0; i < handles.Length; i++)
            {
                if(!StayRotOnBack[i])
                {
                    handles[i].localEulerAngles = neutralRots[i];
                }
            }
        }

        base.EndInteraction(hand);
    }
}
