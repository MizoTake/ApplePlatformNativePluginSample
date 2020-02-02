using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

namespace ApplePlatformNativePlugin {

    public class SampleText : MonoBehaviour
    {

        [SerializeField] private TextMeshProUGUI centerText;
        
#if UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX
        private const string LibraryName = "XcodeProject";
#elif UNITY_IOS && !UNITY_EDITOR
        private const string LibraryName = "__Internal";
#endif
        
        
        [DllImport (LibraryName)]
        private static extern string CallNativeString();
        
        void Start()
        {
            centerText.text = CallNativeString();
        }
    }
    
}