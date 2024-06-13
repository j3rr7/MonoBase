using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonoBase.Core;
using UnityEngine;

namespace MonoBase
{
    public class BaseManager : MonoBehaviour
    {
        public void Update()
        {
            HotkeyManager.ProcessHotkeys();
        }
    }
}
