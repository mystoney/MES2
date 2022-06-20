#region COPYRIGHT
//
//     THIS IS GENERATED BY TEMPLATE
//     
//     AUTHOR  :     ROYE
//     DATE       :     2010
//
//     COPYRIGHT (C) 2010, TIANXIAHOTEL TECHNOLOGIES CO., LTD. ALL RIGHTS RESERVED.
//
#endregion

using System;
using System.Collections.Generic;
using System.Reflection;

namespace System.Text.Template
{
    public static class ContextFactory
    {
        public static object CreateType(Type type)
        {
            return new ClassName(type);
        }

        public static object CreateFunction(Type type, string methodName)
        {
            return new StaticMethod(type, methodName);
        }

        public static object CreateFunction(MethodInfo methodInfo)
        {
            return new StaticMethod(methodInfo);
        }

        public static object CreateFunction(Type type, string methodName, object targetObject)
        {
            return new InstanceMethod(type, methodName, targetObject);
        }

        public static object CreateFunction(MethodInfo methodInfo, object targetObject)
        {
            return new InstanceMethod(methodInfo, targetObject);
        }
    }
}
