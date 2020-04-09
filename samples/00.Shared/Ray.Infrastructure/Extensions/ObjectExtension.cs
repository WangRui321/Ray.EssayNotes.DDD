﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Ray.Infrastructure.Extensions
{
    public static class ObjectExtension
    {
        /// <summary>
        /// 利用反射获取实例的某个字段值
        /// （包括私有变量）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="fielName"></param>
        /// <returns></returns>
        public static object GetFieldValue(this object obj, string fielName)
        {
            try
            {
                Type type = obj.GetType();
                FieldInfo fieldInfo = type.GetFields(BindingFlags.NonPublic
                    | BindingFlags.Public
                    | BindingFlags.Instance
                    | BindingFlags.DeclaredOnly
                    | BindingFlags.Static)
                    .FirstOrDefault(x => x.Name == fielName);
                return fieldInfo?.GetValue(obj);
            }
            catch
            {
                return default;
            }
        }

        /// <summary>
        /// 利用反射获取实例的某个属性值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public static object GetPropertyValue(this object obj, string fieldName)
        {
            try
            {
                Type Ts = obj.GetType();
                var pi = Ts.GetProperty(fieldName, BindingFlags.NonPublic
                    | BindingFlags.Public
                    | BindingFlags.Instance
                    | BindingFlags.DeclaredOnly
                    | BindingFlags.Static);
                return pi.GetValue(obj, null);
            }
            catch
            {
                return null;
            }
        }
    }
}
