global using static ThrottleUtilityButton.Logger;
using System.IO;
using System.Reflection;
using HarmonyLib;
using ModLoader.Framework;
using ModLoader.Framework.Attributes;
using UnityEngine;

namespace ThrottleUtilityButton;

[ItemId("octxly.throttleutilitybutton")] // Harmony ID for your mod, make sure this is unique
public class Main : VtolMod
{
    public string ModFolder;

    private void Awake()
    {
        ModFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        Log($"Awake at {ModFolder}");
    }

    private void Start() 
    {
        var instance = new Harmony("octxly.throttleutilitybutton");
        instance.PatchAll(Assembly.GetExecutingAssembly());
    }

    public override void UnLoad()
    {
        // Destroy any objects
    }
}