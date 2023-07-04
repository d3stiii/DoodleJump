﻿using UnityEngine;

namespace CodeBase.Extensions.Data
{
    public static class JsonExtensions
    {
        public static string ToJson(this object obj) =>
            JsonUtility.ToJson(obj);

        public static T ToDeserialized<T>(this string json) =>
            JsonUtility.FromJson<T>(json);
    }
}