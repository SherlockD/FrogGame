using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Game
{
    [CreateAssetMenu(fileName = "New GameLevel", menuName = "Game")]
    public class GameLevel : ScriptableObject
    {
        [SerializeField] private string _levelData;

        public List<int> GetLevelData()
        {
            string buffer = _levelData;
            buffer = buffer.Remove(0, 1);
            buffer = buffer.Remove(buffer.Length - 1, 1);

            return buffer.Split(',',' ').Select(str => int.Parse(str)).ToList();
        }
    }
}
