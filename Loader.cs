using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonoBase.Features;
using UnityEngine;
using Object = UnityEngine.Object;

namespace MonoBase
{
    public static class Loader
    {
        private static GameObject _monoBaseGameObject;

        public static GameObject GameObjectRef => _monoBaseGameObject;
        public static bool IsLoaded => _monoBaseGameObject != null;

        public static void Load()
        {
            _monoBaseGameObject = new GameObject("MonoBase");
            _monoBaseGameObject.AddComponent<BaseManager>();
            _monoBaseGameObject.AddComponent<BaseConsole>();
            Object.DontDestroyOnLoad(_monoBaseGameObject);
        }

        public static void Unload()
        {
            if (_monoBaseGameObject != null)
            {
                Object.Destroy(_monoBaseGameObject.GetComponent<BaseManager>());
                Object.Destroy(_monoBaseGameObject.GetComponent<BaseConsole>());
                Object.Destroy(_monoBaseGameObject);
                _monoBaseGameObject = null;
            }
            GC.Collect();
        }
    }
}
