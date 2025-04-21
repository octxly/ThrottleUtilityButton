using System.IO;
using System.Reflection;
using UnityEngine;
using UnityEngine.Events;

namespace ThrottleUtilityButton;

public class ActionManager
{
    public static UnityEvent navBind;
    public static UnityEvent tgpBind;
    public static UnityEvent radarBind;
    public static UnityEvent aradBind;
    public static UnityEvent tsdBind;

    public static Settings settings;

    public static bool hasInit = false;

    public static void InitializeBindings()
    {
        string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        settings = JsonUtility.FromJson<Settings>(File.ReadAllText($"{modFolder}\\options.json"));

        MFDCommsPage comms = FlightSceneManager.instance?.playerVehicleMaster?.comms;

        DashMapDisplay nav = comms.targetingPage?.map;
        TargetingMFDPage tgp = comms.targetingPage;
        MFDRadarUI radar = comms.radarPage;
        MFDAntiRadarAttackDisplay arad = comms.aradPage;
        //MFDPTacticalSituationDisplay tsd = comms.tsdPage;

        if (comms.targetingPage.mfdPage)
        {
            navBind = FindInMFD(nav.mfdPage, ButtonMapping.mfdNAV[settings.nav]);
            tgpBind = FindInMFD(tgp.mfdPage, ButtonMapping.mfdTGP[settings.tgp]);
            radarBind = FindInMFD(radar.mfdPage, ButtonMapping.mfdRADAR[settings.radar]);
            aradBind = FindInMFD(arad.mfdPage, ButtonMapping.mfdARAD[settings.arad]);
        }
        //else if (comms.targetingPage.portalPage)
        //{
        //    navBind = FindInPortal(nav.portalPage, settings.nav);
        //    tgpBind = FindInPortal(tgp.portalPage, settings.tgp);
        //    radarBind = FindInPortal(radar.portalPage, settings.radar);
        //    tsdBind = FindInPortal(tsd, settings.tsd);
        //}

        hasInit = true;
    }

    public static UnityEvent FindInMFD(MFDPage page, MFD.MFDButtons search)
    {
        foreach (MFDPage.MFDButtonInfo button in page.buttons)
        {
            if (button.button == search)
            {
                return button.OnPress;
            }
        }

        return null;
    }
    //public static UnityEvent FindInPortal(MFDPortalPage page, string name)
    //{
    //    foreach (VRInteractable interactable in page.interactables)
    //    //{
    //    //    //if (interactable.controlReferenceName == name) return interactable.OnInteract;
    //    //    //if (interactable.)
            
    //    //    //Find out how tsd portal interactables get their names
    //    //    Log($"{interactable.interactableName} => {interactable.controlReferenceName}");
    //    //    interactable.
                
    //    }
        
    //    return null;
    //}

    public class Settings()
    {
        public string nav;
        public string tgp;
        public string radar;
        public string arad;
        public string tsd;
    }   
}
 