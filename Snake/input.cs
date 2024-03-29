﻿
using System.Collections;
using System.Windows.Forms;

namespace Snake
{
    class Input
    {
        private static Hashtable keyTable = new Hashtable();

        public static bool KeyPress(Keys key)
        {
            if (keyTable[key] == null)
            {
                return false;
            }
            return (bool)keyTable[key];
        }

        public static void ChangeState(Keys key, bool newState)
        {
            keyTable[key] = newState;
        }
    }
}
