using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThrottleUtilityButton;

public static class ButtonMapping
{
    public static Dictionary<string, MFD.MFDButtons> mfdNAV = new Dictionary<string, MFD.MFDButtons>()
    {
        {"GPS", MFD.MFDButtons.T2},
        {"MODE", MFD.MFDButtons.T4},
        {"SOI", MFD.MFDButtons.T5},
        {"RESET", MFD.MFDButtons.R1},
        {"ZOOM+", MFD.MFDButtons.R2},
        {"ZOOM-", MFD.MFDButtons.R3},
        {"UP", MFD.MFDButtons.R4},
        {"DOWN", MFD.MFDButtons.R5},
        {"RIGHT", MFD.MFDButtons.B5},
        {"LEFT", MFD.MFDButtons.B4},
        {"GPS-S", MFD.MFDButtons.B3},
        {"ALT+", MFD.MFDButtons.B2},
        {"ALT-", MFD.MFDButtons.B1},
        //{"SET ALT", MFD.MFDButtons.L5},
        {"FUEL", MFD.MFDButtons.L4},
        {"RTB", MFD.MFDButtons.L3},
        {"OBJ", MFD.MFDButtons.L2},
    };
    public static Dictionary<string, MFD.MFDButtons> mfdTGP = new Dictionary<string, MFD.MFDButtons>()
    {
        {"WPT", MFD.MFDButtons.T3},
        {"SOI", MFD.MFDButtons.T5},
        {"ZOOM+", MFD.MFDButtons.R2},
        {"ZOOM-", MFD.MFDButtons.R3},
        {"GPS-S", MFD.MFDButtons.R4},
        {"GPS-A", MFD.MFDButtons.R5},
        {"PWR", MFD.MFDButtons.B5},
        {"HMD", MFD.MFDButtons.B4},
        {"HEAD", MFD.MFDButtons.B3},
        {"FWD", MFD.MFDButtons.B2},
        {"LIM", MFD.MFDButtons.L4},
        {"SENS", MFD.MFDButtons.L3},
        {"MODE", MFD.MFDButtons.L2},
    };
    public static Dictionary<string, MFD.MFDButtons> mfdRADAR = new Dictionary<string, MFD.MFDButtons>()
    {
        {"SOI", MFD.MFDButtons.T5},
        {"OPT", MFD.MFDButtons.R1},
        {"R+", MFD.MFDButtons.R2},
        {"R-", MFD.MFDButtons.R3},
        {"BORE", MFD.MFDButtons.R4},
        {"HEAD", MFD.MFDButtons.R5},
        {"SCAN ANGLE", MFD.MFDButtons.B5},
        {"UNLCK", MFD.MFDButtons.B2},
        {"CLR", MFD.MFDButtons.B1},
    };
    public static Dictionary<string, MFD.MFDButtons> mfdARAD = new Dictionary<string, MFD.MFDButtons>()
    {
        {"SOI", MFD.MFDButtons.T5},
        {"HUD", MFD.MFDButtons.R4},
        {"DECL", MFD.MFDButtons.R5},
    };
}
