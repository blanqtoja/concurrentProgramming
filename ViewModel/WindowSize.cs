﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel
{
    public class WindowSize
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public WindowSize(int width, int height)
        {
            Width = width;
            Height = height;
        }
    }
}
