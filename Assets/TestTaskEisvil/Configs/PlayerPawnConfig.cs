using TestTaskEisvil.Character;
using TestTaskEisvil.Characters._Player;
using UnityEngine;

namespace TestTaskEisvil.Configs
{
    [CreateAssetMenu(menuName = "Configs/Player", fileName = "PawnData")]
    public class PlayerPawnConfig : ScriptableObject
    {
        [SerializeField] private PlayerPawn pawnPrefab;
        [SerializeField] private PawnData pawnData;
        
        public PlayerPawn PawnPrefab => pawnPrefab;
        public PawnData PawnData => pawnData;
    }
}
