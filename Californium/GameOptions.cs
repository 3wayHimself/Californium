﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Californium
{
    public static class GameOptions
    {
        public static string Caption = "";
        public static uint Width = 800;
        public static uint Height = 600;
        public static bool Resizable = true;

        public static bool Vsync = false;
        public static uint Framerate = 60;

        public static float MusicVolume = 50;
        public static float SoundVolume = 100;

        public static string TextureLocation = "Data/Texture/";
        public static string SoundLocation = "Data/Sound/";
        public static string MusicLocation = "Data/Music/";
        public static string FontLocation = "Data/Font/";

        public static int TileSize = 16;
        public static int TileChunkSize = 32;

        public static int EntityGridSize = 64;
    }
}