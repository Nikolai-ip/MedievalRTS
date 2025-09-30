using _Game.Source.Infrastructure.DIInstallers;
using UnityEngine;

namespace _Game.Source.Infrastructure.Configs
{
    [CreateAssetMenu(fileName = "GridParams", menuName = "StaticData/GridParams")]
    public class GridParams_SO: ScriptableObject
    {
        [SerializeField] private GridParams _gridParams;

        public GridParams GridParams => _gridParams;
    }
}