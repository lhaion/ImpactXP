using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "Settings", menuName = "Settings", order = 1)]
    public class ScriptableSettings : ScriptableObject
    {
        [Range(0.1f, 2)] public float sense;
        [Range(0.05f, 0.8f)] public float moveDelay;
        [Range(0.001f, 1)]public float sfxVolume;
        [Range(0.001f, 1)] public float musicVolume;
             
    }
}
