using HarmonyLib;
using UnityEngine;

namespace ThrottleUtilityButton;

[HarmonyPatch(typeof(VRThrottle), "UpdateButtonEvents")]
public class ButtonPatch
{
    static bool hasPressed = false;

    public static void Postfix(VRHandController ___controller, bool ___sendEvents, bool ___alwaysSendButtonEvents, AudioClip ___throttleClickSound, AudioSource ___audioSource)
    {
        if ((___sendEvents || ___alwaysSendButtonEvents) && ___controller)
		{
            if (___controller.GetSecondButtonDown()) SecondaryButtonDown(___throttleClickSound, ___audioSource);
            if (___controller.GetSecondButtonUp()) SecondaryButtonUp();
        }
    }

    public static void SecondaryButtonDown(AudioClip audioClip, AudioSource audioSource)
    {
        if (hasPressed) return;
        hasPressed = true;

        if (!ActionManager.hasInit) ActionManager.InitializeBindings();

        MFDCommsPage comms = FlightSceneManager.instance?.playerVehicleMaster?.comms;

        DashMapDisplay nav = comms?.targetingPage?.map;
        TargetingMFDPage tgp = comms.targetingPage;
        MFDRadarUI radar = comms.radarPage;
        MFDAntiRadarAttackDisplay arad = comms.aradPage;
        MFDPTacticalSituationDisplay tsd = comms.tsdPage;

        if (nav.mfdPage?.isSOI == true || nav.portalPage?.isSOI == true)
        {
            ActionManager.navBind?.Invoke();
        }

        if (tgp.mfdPage?.isSOI == true || tgp.portalPage?.isSOI == true)
        {
            ActionManager.tgpBind?.Invoke();
        }

        if (radar.mfdPage?.isSOI == true || radar.portalPage?.isSOI == true)
        {
            ActionManager.radarBind?.Invoke();
        }

        if (arad.mfdPage?.isSOI == true)
        {
            ActionManager.aradBind?.Invoke();
        }

        if (tsd?.isSOI == true)
        {
            ActionManager.tsdBind?.Invoke();
        }
    }
    public static void SecondaryButtonUp()
    {
        if (hasPressed) hasPressed = false;
    }
}