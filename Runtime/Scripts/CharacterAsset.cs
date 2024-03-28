using UnityEngine;

namespace HHG.DialogueSystem.Runtime
{
    [CreateAssetMenu(fileName = "Character", menuName = "HHG/Dialogue System/Character")]
    public class CharacterAsset : ScriptableObject
    {
        public Sprite Portrait => portrait;

        [SerializeField] private Sprite portrait;
    }
}