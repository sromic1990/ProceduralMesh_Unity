using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Sourav.Utilities.EditorUtils
{
    public class GetBuildTargetGroup : Editor 
    {
        public static BuildTargetGroup GetCorrectBuildTargetGroup()
        {
            BuildTargetGroup group = BuildTargetGroup.Unknown;

#if UNITY_ANDROID
            group = BuildTargetGroup.Android;

#elif UNITY_IOS
            //group = BuildTarget.iOS;
#endif

            //switch(Application.platform)
            //{
            //    case RuntimePlatform.Android:
            //        group = BuildTargetGroup.Android;
            //        break;
            //    case RuntimePlatform.IPhonePlayer:
            //        group = BuildTargetGroup.iOS;
            //        break;
            //    case RuntimePlatform.LinuxEditor:
            //        group = BuildTargetGroup.Unknown;
            //        break;
            //    case RuntimePlatform.LinuxPlayer:
            //        group = BuildTargetGroup.Unknown;
            //        break;
            //    case RuntimePlatform.OSXDashboardPlayer:
            //        group = BuildTargetGroup.Unknown;
            //        break;
            //    case RuntimePlatform.OSXEditor:
            //        group = BuildTargetGroup.Standalone;
            //        break;
            //    case RuntimePlatform.OSXPlayer:
            //        group = BuildTargetGroup.Standalone;
            //        break;
            //    case RuntimePlatform.PS4:
            //        group = BuildTargetGroup.PS4;
            //        break;
            //    case RuntimePlatform.PSM:
            //        group = BuildTargetGroup.PSM;
            //        break;
            //    case RuntimePlatform.PSP2:
            //        group = BuildTargetGroup.PSP2;
            //        break;
            //    case RuntimePlatform.SamsungTVPlayer:
            //        group = BuildTargetGroup.SamsungTV;
            //        break;
            //    case RuntimePlatform.Switch:
            //        group = BuildTargetGroup.Switch;
            //        break;
            //    case RuntimePlatform.TizenPlayer:
            //        group = BuildTargetGroup.Tizen;
            //        break;
            //    case RuntimePlatform.tvOS:
            //        group = BuildTargetGroup.tvOS;
            //        break;
            //    case RuntimePlatform.WebGLPlayer:
            //        group = BuildTargetGroup.WebGL;
            //        break;
            //    case RuntimePlatform.WiiU:
            //        group = BuildTargetGroup.WiiU;
            //        break;
            //    case RuntimePlatform.WindowsEditor:
            //        group = BuildTargetGroup.Standalone;
            //        break;
            //    case RuntimePlatform.WindowsPlayer:
            //        group = BuildTargetGroup.Standalone;
            //        break;
            //    case RuntimePlatform.WSAPlayerARM:
            //        group = BuildTargetGroup.WSA;
            //        break;
            //    case RuntimePlatform.WSAPlayerX64:
            //        group = BuildTargetGroup.WSA;
            //        break;
            //    case RuntimePlatform.WSAPlayerX86:
            //        group = BuildTargetGroup.WSA;
            //        break;
            //    case RuntimePlatform.XboxOne:
            //        group = BuildTargetGroup.XboxOne;
            //        break;
            //    default:
            //        group = BuildTargetGroup.Unknown;
            //        break;
            //}

            //Debug.Log("group = "+group.ToString());

            return group;
        }
    }
    
}
