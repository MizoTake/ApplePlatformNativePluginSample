using System.IO;
using UnityEngine;
using UnityEditor;
using UnityEditor.iOS.Xcode;
using UnityEditor.Callbacks;
using System.Collections;

namespace ApplePlatformNativePlugin
{
    public class XcodeSettingsPostProcesser
    {
#if UNITY_IOS || UNITY_TVOS
        [PostProcessBuildAttribute (0)]
        public static void OnPostprocessBuild (BuildTarget buildTarget, string pathToBuiltProject)
        {
            var projectPath = pathToBuiltProject + "/Unity-iPhone.xcodeproj/project.pbxproj";
            var pbxProject = new PBXProject ();
            pbxProject.ReadFromFile (projectPath);
            var targetGuid = pbxProject.TargetGuidByName ("Unity-iPhone");
            
            pbxProject.AddBuildProperty(targetGuid, "SWIFT_VERSION", "5");
            
            File.WriteAllText (projectPath, pbxProject.WriteToString ());
        }
#endif
    }
}