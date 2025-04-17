using UnityEngine;

namespace HHG.Dialogues.Runtime
{
    [CreateAssetMenu(fileName = "Character", menuName = "HHG/Dialogue System/Character")]
    public class CharacterAsset : ScriptableObject
    {
        public Sprite Portrait => portrait;
        public Facing Facing => facing;

        [SerializeField] private Sprite portrait;
        [SerializeField] private Facing facing;
    }
}