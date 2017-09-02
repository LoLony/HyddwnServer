﻿// Copyright (c) Aura development team - Licensed under GNU GPL
// For more information, see license file in the main folder

using System;
using System.IO;
using Aura.Mabi.Util;

namespace Aura.Data.Database
{
    public class ColorMapData
    {
        public int Id { get; set; }
        public int DyeId { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public byte[] Raw { get; set; }

        public uint[] ColorMap { get; set; }
    }

    /// <summary>
    ///     Holds information about all colors a specific material can have.
    ///     Indexed by color map id.
    /// </summary>
    public class ColorMapDb : DatabaseDatIndexed<int, ColorMapData>
    {
        public static readonly byte[] DistortionMap =
        {
            0x20, 0x22, 0x2D, 0x2F, 0x2E, 0x28, 0x34, 0x36, 0x30, 0x3D, 0x3E, 0x3B, 0x04, 0x01, 0x0D, 0x09,
            0x0A, 0x10, 0x1C, 0x1B, 0x67, 0x6D, 0x68, 0x76, 0x7C, 0x7A, 0x40, 0x4E, 0x56, 0x5C, 0x5A, 0xA3,
            0xA9, 0xB1, 0xBF, 0x84, 0x82, 0x8B, 0x93, 0x9E, 0xE7, 0xED, 0xEB, 0xF1, 0xFC, 0xFA, 0xC1, 0xCD,
            0xC9, 0xD5, 0xD1, 0xD2, 0xDF, 0xDE, 0xD8, 0xDB, 0xDA, 0xDA, 0xDB, 0xDB, 0xD8, 0xD9, 0xDC, 0xD2,
            0xD1, 0xD5, 0xC9, 0xCD, 0xC1, 0xFA, 0xFC, 0xF1, 0xEB, 0xED, 0xE7, 0x9E, 0x93, 0x8B, 0x8D, 0x85,
            0xBF, 0xB6, 0xA9, 0xA3, 0xA5, 0x5C, 0x56, 0x49, 0x42, 0x45, 0x7E, 0x70, 0x74, 0x6E, 0x63, 0x67,
            0x18, 0x1F, 0x13, 0x16, 0x0A, 0x0E, 0x0C, 0x02, 0x01, 0x07, 0x05, 0x05, 0x3B, 0x38, 0x38, 0x39,
            0x38, 0x38, 0x39, 0x38, 0x3B, 0x3A, 0x05, 0x05, 0x06, 0x01, 0x02, 0x0D, 0x0F, 0x08, 0x14, 0x11,
            0x12, 0x1E, 0x18, 0x64, 0x60, 0x6C, 0x6B, 0x76, 0x7D, 0x7E, 0x44, 0x41, 0x4C, 0x4B, 0x56, 0x5D,
            0x5B, 0xA6, 0xAC, 0xAB, 0xB1, 0xBF, 0xBB, 0x81, 0x8C, 0x95, 0x90, 0x9F, 0x9B, 0xE1, 0xED, 0xE8,
            0xF6, 0xF2, 0xFE, 0xFB, 0xC6, 0xC3, 0xCF, 0xC8, 0xD4, 0xD6, 0xD0, 0xDD, 0xDF, 0xDE, 0xD8, 0xDB,
            0xDB, 0xDB, 0xDA, 0xDA, 0xDB, 0xDB, 0xD8, 0xDE, 0xDF, 0xD2, 0xD3, 0xD6, 0xD4, 0xC8, 0xCC, 0xC3,
            0xC6, 0xFA, 0xFE, 0xF2, 0xF7, 0xE9, 0xED, 0xE6, 0x9B, 0x9C, 0x91, 0x8B, 0x8C, 0x81, 0xBB, 0xBC,
            0xB1, 0xAB, 0xAC, 0xA6, 0x5B, 0x5D, 0x56, 0x4B, 0x4C, 0x41, 0x7A, 0x7E, 0x73, 0x77, 0x68, 0x6D,
            0x61, 0x65, 0x19, 0x1C, 0x10, 0x17, 0x0B, 0x0F, 0x0D, 0x00, 0x07, 0x3A, 0x38, 0x3E, 0x3D, 0x33,
            0x31, 0x37, 0x34, 0x28, 0x29, 0x2F, 0x2C, 0x2D, 0x22, 0x20, 0x21, 0x21, 0x27, 0x24, 0x24, 0x25
        };

        public uint GetRandom(byte id, MTRandom rnd)
        {
            return GetAt(id, rnd.GetUInt32(), rnd.GetUInt32());
        }

        public uint GetRandom(byte id, Random rnd)
        {
            return GetAt(id, (uint) rnd.Next(int.MaxValue), (uint) rnd.Next(int.MaxValue));
        }

        public uint GetAt(byte id, uint x, uint y)
        {
            var mapInfo = Find(id);
            if (mapInfo == null)
                return 0;

            var color = mapInfo.ColorMap[x % mapInfo.Width + y % mapInfo.Height * mapInfo.Height];
            if (color >> 24 == 0)
                color = ((color & 0xFF) << 16) + (((color >> 8) & 0xFF) << 8) + ((color >> 16) & 0xFF);
            return color;
        }

        protected override void Read(BinaryReader br)
        {
            var info = new ColorMapData();
            info.Id = br.ReadByte();
            info.DyeId = br.ReadByte();
            info.Width = br.ReadInt16();
            info.Height = br.ReadInt16();

            info.Raw = br.ReadBytes(info.Width * info.Height * 4);
            info.ColorMap = new uint[info.Width * info.Height];

            using (var ms = new MemoryStream(info.Raw))
            using (var br2 = new BinaryReader(ms))
            {
                for (var i = 0; i < info.ColorMap.Length; ++i)
                    info.ColorMap[i] = br2.ReadUInt32();
            }

            Entries.Add(info.Id, info);
        }
    }
}