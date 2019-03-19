﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wechat.Util.Extensions
{
    public static class Extension
    {
        public static string ToJson(this object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static object ToObj(this string str)
        {
            return JsonConvert.DeserializeObject(str);
        }

        public static T ToObj<T>(this string str)
        {
            return JsonConvert.DeserializeObject<T>(str);
        }

        public static Stream ToStream(this byte[] buffer)
        {
            MemoryStream sm = new MemoryStream(buffer);
            return sm;
        }

        public static byte[] ToBuffer(this Stream sm)
        {
            byte[] buffer = new byte[sm.Length];
            sm.Read(buffer, 0, buffer.Length);
            sm.Seek(0, SeekOrigin.Begin);
            return buffer;
        }

        public static async Task<byte[]> ToBufferAsync(this Stream sm)
        {
            byte[] buffer = new byte[sm.Length];
            await sm.ReadAsync(buffer, 0, buffer.Length);
            sm.Seek(0, SeekOrigin.Begin);
            return buffer;
        }

        public static bool IsImage(this string fileName)
        {
            bool isImage = false;
            string[] exts = { ".bmp", ".dib", ".jpg", ".jpeg", ".jpe", ".jfif", ".png", ".gif", ".tif", ".tiff" };
            if (exts.Contains(fileName.ToLower()))
            {
                isImage = true;
            }
            return isImage;
        }

        public static bool IsVideo(this string fileName)
        {
            bool isVideo = false;
            string[] exts = { "wmv", ".asf", ".asx", ".rm", ".rmvb", ".mp4 ", ".3gp", ".mov", ".m4v", ".avi", ".dat", ".mkv", ".flv", ".vob" };
            if (exts.Contains(fileName.ToLower()))
            {
                isVideo = true;
            }
            return isVideo;
        }

        public static bool IsVoice(this string fileName)
        {
            bool isVoice = false;
            string[] exts = { ".wav", ".aif", ".aiff", ".au", ".mp3", ".ra", ".rm", ".ram", ".wma", ".mmf", ".amr", ".aac", ".flac",".snd" };
            if (exts.Contains(fileName.ToLower()))
            {
                isVoice = true;
            }
            return isVoice;
        }

   
    }
}
