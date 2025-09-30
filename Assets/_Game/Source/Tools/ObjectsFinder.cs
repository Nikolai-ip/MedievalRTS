using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace _Game.Source.Tools
{
    public class ObjectsFinder
    {
        public static T FindObject<T>() where T : MonoBehaviour
        {
            return Object.FindAnyObjectByType<T>(FindObjectsInactive.Include);
        }

        public static bool TryFindObject<T>(out T foundObject) where T : MonoBehaviour
        {
            foundObject = FindObject<T>();
            return foundObject != null;
        }
        public static List<T> FindObjectOfInterfaceType<T>()
        {
            return Object
                .FindObjectsByType<MonoBehaviour>(FindObjectsInactive.Include, FindObjectsSortMode.None)
                .OfType<T>().ToList();
        }

        public static List<T> FindObjects<T>(FindObjectsInactive findInactives = FindObjectsInactive.Include, FindObjectsSortMode findObjectsSortMode = FindObjectsSortMode.None) where T : MonoBehaviour
        {
            return Object
                .FindObjectsByType<T>(findInactives, findObjectsSortMode)
                .ToList();
        }
    }
}