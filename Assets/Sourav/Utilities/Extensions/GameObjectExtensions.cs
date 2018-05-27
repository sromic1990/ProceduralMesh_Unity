using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sourav.Utilities.Extensions
{
    public static class GameObjectExtensions
    {
        public static void Show(this GameObject gObj)
        {
            gObj.SetActive(true);
        }

        public static void Hide(this GameObject gObj)
        {
            gObj.SetActive(false);
        }
    }
}
