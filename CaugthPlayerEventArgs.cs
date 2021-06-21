using System;
using UnityEngine;

namespace Codes
{
    public class CaugthPlayerEventArgs : EventArgs
    {
        public Color Color { get; }

        public CaugthPlayerEventArgs(Color Color)
        {
            this.Color = Color;
        }
    }
}