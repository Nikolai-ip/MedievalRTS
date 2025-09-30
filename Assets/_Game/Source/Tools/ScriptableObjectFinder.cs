using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace _Game.Source.Tools
{
    public class ScriptableObjectFinder
    {
        public static List<T> FindAllScriptableObjects<T>(string folderPath) where T : ScriptableObject
        {
            return Resources.LoadAll<T>(folderPath).ToList();
        }
    }

}