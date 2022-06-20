﻿#region COPYRIGHT
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
using System.Linq;
using System.Text;
using System.Reflection.Emit;

namespace System.Reflection
{
    public static class ReflectionExtensions
    {
        //private static readonly Reflector _Reflector = Reflector.Create();

        public static Type[] ToTypeArray(this ParameterInfo[] parameters)
        {
            if (parameters.Length == 0)
                return Type.EmptyTypes;
            var types = new Type[parameters.Length];
            for (int i = 0; i < types.Length; i++)
            {
                types[i] = parameters[i].ParameterType;
            }
            return types;
        }

        public static Type[] ToTypeArray(this object[] objects)
        {
            if (objects.Length == 0)
                return Type.EmptyTypes;
            var types = new Type[objects.Length];
            for (int i = 0; i < types.Length; i++)
            {
                types[i] = objects[i].GetType();
            }
            return types;
        }

        public static List<PropertyInfo> GetProperties(this object obj)
        {
            return obj.GetType().GetProperties().ToList();
        }

        public static object GetValue(this PropertyInfo pi, object obj)
        {
            return pi.GetGetMethod().Invoke(obj, Constants.EmptyObjectArray);
        }
        /*
        #region Constructor

        /// <summary>
        /// Invokes the no-arg constructor on type <paramref name="targetType"/>
        /// </summary>
        /// <param name="targetType">The type whose constructor is to be invoked</param>
        /// <returns>An instance of type <paramref name="targetType"/></returns>
        public static object Construct(this Type targetType)
        {
            return _Reflector.Construct(targetType);
        }

        public static object Construct(this Type targetType, params object[] parameters)
        {
            return targetType.Construct(parameters.ToTypeArray(), parameters);
        }

        /// <summary>
        /// Invokes a constructor specified by <param name="parameters" /> on the type <paramref name="targetType"/>
        /// </summary>
        /// <param name="targetType">The type whose constructor is to be invoked</param>
        /// <param name="paramTypes">The types of the constructor parameters (must be in the right order)</param>
        /// <param name="parameters">The parameters of the constructor (must be in the right order)</param>
        /// <returns>An instance of type <paramref name="targetType"/></returns>
        public static object Construct(this Type targetType, Type[] paramTypes, params object[] parameters)
        {
            return _Reflector.Construct(targetType, paramTypes, parameters);
        }

        /// <summary>
        /// Creates a delegate which can invoke the constructor of type <paramref name="targetType"/>
        /// </summary>
        /// <param name="targetType">The type which has the constructor to be invoked</param>
        /// <returns>The delegate which can invoke the constructor of type <paramref name="targetType"/></returns>
        public static ConstructorInvoker DelegateForConstruct(this Type targetType)
        {
            return _Reflector.DelegateForConstruct(targetType);
        }

        /// <summary>
        /// Creates a delegate which can invoke the constructor of type <paramref name="targetType"/>
        /// </summary>
        /// <param name="targetType">The type which has the constructor to be invoked</param>
        /// <param name="paramTypes">The types of the constructor parameters (must be in the right order)</param>
        /// <returns>The delegate which can invoke the constructor of type <paramref name="targetType"/></returns>
        public static ConstructorInvoker DelegateForConstruct(this Type targetType, Type[] paramTypes)
        {
            return _Reflector.DelegateForConstruct(targetType, paramTypes);
        }

        #endregion

        #region Property

        /// <summary>
        /// Sets the static properties of <paramref name="targetType"/> based on
        /// the properties available in <paramref name="obj"/>. 
        /// </summary>
        /// <param name="targetType">The type whose static properties are to be set</param>
        /// <param name="obj">An object whose properties will be used to set the static properties of
        /// <paramref name="targetType"/></param>
        /// <returns><paramref name="targetType"/></returns>
        public static Type SetProperties(this Type targetType, object obj)
        {
            _Reflector.SetProperties(targetType, obj);
            return targetType;
        }

        /// <summary>
        /// Sets the properties of <paramref name="target"/> based on
        /// the properties available in <paramref name="obj"/>. 
        /// </summary>
        /// <param name="target">The object whose properties are to be set</param>
        /// <param name="obj">An object whose properties will be used to set the properties of
        /// <paramref name="target"/></param>
        /// <returns><paramref name="target"/></returns>
        public static object SetProperties(this object target, object obj)
        {
            _Reflector.SetProperties(target, obj);
            return target;
        }

        /// <summary>
        /// Sets the static property <paramref name="propertyName"/> of type <paramref name="targetType"/>
        /// with the specified <paramref name="value" />.
        /// </summary>
        /// <param name="targetType">The type whose property is to be set</param>
        /// <param name="propertyName">The name of the static property to be set</param>
        /// <param name="value">The value used to set the static property</param>
        /// <returns><paramref name="targetType"/></returns>
        public static Type SetProperty(this Type targetType, string propertyName, object value)
        {
            _Reflector.SetProperty(targetType, propertyName, value);
            return targetType;
        }

        /// <summary>
        /// Sets the property <paramref name="propertyName"/> of object <paramref name="target"/>
        /// with the specified <paramref name="value" />.
        /// </summary>
        /// <param name="target">The object whose property is to be set</param>
        /// <param name="propertyName">The name of the property to be set</param>
        /// <param name="value">The value used to set the property</param>
        /// <returns><paramref name="target"/></returns>
        public static object SetProperty(this object target, string propertyName, object value)
        {
            _Reflector.SetProperty(target, propertyName, value);
            return target;
        }

        /// <summary>
        /// Gets the value of the static property <paramref name="propertyName"/> of type 
        /// <paramref name="targetType"/>.
        /// </summary>
        /// <param name="targetType">The type whose property is to be retrieved</param>
        /// <param name="propertyName">The name of the static property whose value is to be retrieved</param>
        /// <returns>The value of the static property</returns>
        public static TReturn GetProperty<TReturn>(this Type targetType, string propertyName)
        {
            return _Reflector.GetProperty<TReturn>(targetType, propertyName);
        }

        /// <summary>
        /// Retrieves the value of the property <paramref name="propertyName"/> of object
        /// <paramref name="target"/>.
        /// </summary>
        /// <param name="target">The object whose property is to be retrieved</param>
        /// <param name="propertyName">The name of the property whose value is to be retrieved</param>
        /// <returns>The value of the property</returns>
        public static TReturn GetProperty<TReturn>(this object target, string propertyName)
        {
            return _Reflector.GetProperty<TReturn>(target, propertyName);
        }

        /// <summary>
        /// Creates a delegate which can set the value of the specified static property.
        /// </summary>
        /// <param name="targetType">The type which the property belongs to</param>
        /// <param name="propertyName">The name of the static property to be set</param>
        /// <returns>A delegate which can set the value of the specified static property</returns>
        public static StaticAttributeSetter DelegateForSetStaticProperty(this Type targetType, string propertyName)
        {
            return _Reflector.DelegateForSetStaticProperty(targetType, propertyName);
        }

        /// <summary>
        /// Creates a delegate which can set the value of the specified property.
        /// </summary>
        /// <param name="targetType">The type which the property belongs to</param>
        /// <param name="propertyName">The name of the property to be set</param>
        /// <returns>A delegate which can set the value of the specified property</returns>
        public static AttributeSetter DelegateForSetProperty(this Type targetType, string propertyName)
        {
            return _Reflector.DelegateForSetProperty(targetType, propertyName);
        }

        /// <summary>
        /// Creates a delegate which can get the value of the specified static property.
        /// </summary>
        /// <param name="targetType">The type which the property belongs to</param>
        /// <param name="propertyName">The name of the static property to be retrieved</param>
        /// <returns>A delegate which can get the value of the specified static property</returns>
        public static StaticAttributeGetter DelegateForGetStaticProperty(this Type targetType, string propertyName)
        {
            return _Reflector.DelegateForGetStaticProperty(targetType, propertyName);
        }

        /// <summary>
        /// Creates a delegate which can get the value of the specified property.
        /// </summary>
        /// <param name="targetType">The type which the property belongs to</param>
        /// <param name="propertyName">The name of the property to be retrieved</param>
        /// <returns>A delegate which can get the value of the specified property</returns>
        public static AttributeGetter DelegateForGetProperty(this Type targetType, string propertyName)
        {
            return _Reflector.DelegateForGetProperty(targetType, propertyName);
        }

        #endregion

        #region Field

        /// <summary>
        /// Sets the static fields of <paramref name="targetType"/> based on
        /// the properties available in <paramref name="obj"/>. 
        /// </summary>
        /// <param name="targetType">The type whose static fields are to be set</param>
        /// <param name="obj">An object whose properties will be used to set the static fields of
        /// <paramref name="targetType"/></param>
        /// <returns><paramref name="targetType"/></returns>
        public static Type SetFields(this Type targetType, object obj)
        {
            _Reflector.SetFields(targetType, obj);
            return targetType;
        }

        /// <summary>
        /// Sets the fields of <paramref name="target"/> based on
        /// the properties available in <paramref name="obj"/>. 
        /// </summary>
        /// <param name="target">The object whose fields are to be set</param>
        /// <param name="obj">An object whose fields will be used to set the properties of
        /// <paramref name="target"/></param>
        /// <returns><paramref name="target"/></returns>
        public static object SetFields(this object target, object obj)
        {
            _Reflector.SetFields(target, obj);
            return target;
        }

        /// <summary>
        /// Sets the static field <paramref name="fieldName"/> of type <paramref name="targetType"/>
        /// with the specified <paramref name="value" />.
        /// </summary>
        /// <param name="targetType">The type whose field is to be set</param>
        /// <param name="fieldName">The name of the static field to be set</param>
        /// <param name="value">The value used to set the static field</param>
        /// <returns><paramref name="targetType"/></returns>
        public static Type SetField(this Type targetType, string fieldName, object value)
        {
            _Reflector.SetField(targetType, fieldName, value);
            return targetType;
        }

        /// <summary>
        /// Sets the field <paramref name="fieldName"/> of object <paramref name="target"/>
        /// with the specified <paramref name="value" />.
        /// </summary>
        /// <param name="target">The object whose field is to be set</param>
        /// <param name="fieldName">The name of the field to be set</param>
        /// <param name="value">The value used to set the field</param>
        /// <returns><paramref name="target"/></returns>
        public static object SetField(this object target, string fieldName, object value)
        {
            _Reflector.SetField(target, fieldName, value);
            return target;
        }

        /// <summary>
        /// Gets the value of the static field <paramref name="fieldName"/> of type 
        /// <paramref name="targetType"/>.
        /// </summary>
        /// <param name="targetType">The type whose field is to be retrieved</param>
        /// <param name="fieldName">The name of the static field whose value is to be retrieved</param>
        /// <returns>The value of the static field</returns>
        public static TReturn GetField<TReturn>(this Type targetType, string fieldName)
        {
            return _Reflector.GetField<TReturn>(targetType, fieldName);
        }

        /// <summary>
        /// Retrieves the value of the field <paramref name="fieldName"/> of object
        /// <paramref name="target"/>.
        /// </summary>
        /// <param name="target">The object whose field is to be retrieved</param>
        /// <param name="fieldName">The name of the field whose value is to be retrieved</param>
        /// <returns>The value of the field</returns>
        public static TReturn GetField<TReturn>(this object target, string fieldName)
        {
            return _Reflector.GetField<TReturn>(target, fieldName);
        }

        /// <summary>
        /// Creates a delegate which can set the value of the specified static field.
        /// </summary>
        /// <param name="targetType">The type which the field belongs to</param>
        /// <param name="fieldName">The name of the static field to be set</param>
        /// <returns>A delegate which can set the value of the specified static field</returns>
        public static StaticAttributeSetter DelegateForSetStaticField(this Type targetType, string fieldName)
        {
            return _Reflector.DelegateForSetStaticField(targetType, fieldName);
        }

        /// <summary>
        /// Creates a delegate which can set the value of the specified field.
        /// </summary>
        /// <param name="targetType">The type which the field belongs to</param>
        /// <param name="fieldName">The name of the field to be set</param>
        /// <returns>A delegate which can set the value of the specified field</returns>
        public static AttributeSetter DelegateForSetField(this Type targetType, string fieldName)
        {
            return _Reflector.DelegateForSetField(targetType, fieldName);
        }

        /// <summary>
        /// Creates a delegate which can get the value of the specified static field.
        /// </summary>
        /// <param name="targetType">The type which the field belongs to</param>
        /// <param name="fieldName">The name of the static field to be retrieved</param>
        /// <returns>A delegate which can get the value of the specified static field</returns>
        public static StaticAttributeGetter DelegateForGetStaticField(this Type targetType, string fieldName)
        {
            return _Reflector.DelegateForGetStaticField(targetType, fieldName);
        }

        /// <summary>
        /// Creates a delegate which can get the value of the specified field.
        /// </summary>
        /// <param name="targetType">The type which the field belongs to</param>
        /// <param name="fieldName">The name of the field to be retrieved</param>
        /// <returns>A delegate which can get the value of the specified field</returns>
        public static AttributeGetter DelegateForGetField(this Type targetType, string fieldName)
        {
            return _Reflector.DelegateForGetField(targetType, fieldName);
        }
        #endregion

        #region a
        /// <summary>
        /// Invokes the static method specified by <paramref name="methodName"/> of type
        /// <paramref name="targetType"/>
        /// </summary>
        /// <param name="targetType">The type whose method is to be invoked</param>
        /// <param name="methodName">The name of the static method to be invoked</param>
        /// <returns><paramref name="targetType"/></returns>
        public static Type Invoke(this Type targetType, string methodName)
        {
            _Reflector.Invoke(targetType, methodName);
            return targetType;
        }

        /// <summary>
        /// Invokes the static method specified by <paramref name="methodName"/> of type
        /// <paramref name="targetType"/>
        /// </summary>
        /// <param name="targetType">The type whose method is to be invoked</param>
        /// <param name="methodName">The name of the static method to be invoked</param>
        /// <param name="paramTypes">The types of the method parameters (must be in the right order)</param>
        /// <param name="parameters">The parameters of the method (must be in the right order)</param>
        /// <returns><paramref name="targetType"/></returns>
        public static Type Invoke(this Type targetType, string methodName, Type[] paramTypes, object[] parameters)
        {
            _Reflector.Invoke(targetType, methodName, paramTypes, parameters);
            return targetType;
        }

        /// <summary>
        /// Invokes the method specified by <paramref name="methodName"/> of object
        /// <paramref name="target"/>
        /// </summary>
        /// <param name="target">The object whose method is to be invoked</param>
        /// <param name="methodName">The name of the method to be invoked</param>
        /// <returns><paramref name="target"/></returns>
        public static object Invoke(this object target, string methodName)
        {
            _Reflector.Invoke(target, methodName);
            return target;
        }

        /// <summary>
        /// Invokes the method specified by <paramref name="methodName"/> of object
        /// <paramref name="target"/>
        /// </summary>
        /// <param name="target">The object whose method is to be invoked</param>
        /// <param name="methodName">The name of the method to be invoked</param>
        /// <param name="paramTypes">The types of the method parameters (must be in the right order)</param>
        /// <param name="parameters">The parameters of the method (must be in the right order)</param>
        /// <returns><paramref name="target"/></returns>
        public static object Invoke(this object target, string methodName, Type[] paramTypes, object[] parameters)
        {
            _Reflector.Invoke(target, methodName, paramTypes, parameters);
            return target;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <param name="methodName"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static object Invoke(this object target, string methodName, object[] parameters)
        {
            _Reflector.Invoke(target, methodName, parameters.ToTypeArray(), parameters);
            return target;
        }

        /// <summary>
        /// Invokes the static method specified by <paramref name="methodName"/> of type <paramref name="targetType"/>
        /// and get back the return value, casted to <typeparamref name="TReturn"/>
        /// </summary>
        /// <typeparam name="TReturn">The return type of the static method</typeparam>
        /// <param name="targetType">The type whose method is to be invoked</param>
        /// <param name="methodName">The name of the static method to be invoked</param>
        /// <returns>The return value of the static method</returns>
        public static TReturn Invoke<TReturn>(this Type targetType, string methodName)
        {
            return _Reflector.Invoke<TReturn>(targetType, methodName);
        }

        /// <summary>
        /// Invokes the method specified by <paramref name="methodName"/> of object <paramref name="target"/>
        /// and get back the return value, casted to <typeparamref name="TReturn"/>
        /// </summary>
        /// <typeparam name="TReturn">The return type of the method</typeparam>
        /// <param name="target">The object whose method is to be invoked</param>
        /// <param name="methodName">The name of the method to be invoked</param>
        /// <returns>The return value of the method</returns>
        public static TReturn Invoke<TReturn>(this object target, string methodName)
        {
            return _Reflector.Invoke<TReturn>(target, methodName);
        }

        /// <summary>
        /// Invokes the static method specified by <paramref name="methodName"/> of type <paramref name="targetType"/>
        /// and get back the return value, casted to <typeparamref name="TReturn"/>
        /// </summary>
        /// <typeparam name="TReturn">The return type of the static method</typeparam>
        /// <param name="targetType">The type whose method is to be invoked</param>
        /// <param name="methodName">The name of the static method to be invoked</param>
        /// <param name="paramTypes">The types of the method parameters (must be in the right order)</param>
        /// <param name="parameters">The parameters of the method (must be in the right order)</param>
        /// <returns>The return value of the static method</returns>
        public static TReturn Invoke<TReturn>(this Type targetType, string methodName, Type[] paramTypes, object[] parameters)
        {
            return _Reflector.Invoke<TReturn>(targetType, methodName, paramTypes, parameters);
        }

        public static TReturn Invoke<TReturn>(this object target, string methodName, params object[] parameters)
        {
            return target.Invoke<TReturn>(methodName, parameters.ToTypeArray(), parameters);
        }

        /// <summary>
        /// Invokes the method specified by <paramref name="methodName"/> of object <paramref name="target"/>
        /// and get back the return value, casted to <typeparamref name="TReturn"/>
        /// </summary>
        /// <typeparam name="TReturn">The return type of the method</typeparam>
        /// <param name="target">The object whose method is to be invoked</param>
        /// <param name="methodName">The name of the method to be invoked</param>
        /// <param name="paramTypes">The types of the method parameters (must be in the right order)</param>
        /// <param name="parameters">The parameters of the method (must be in the right order)</param>
        /// <returns>The return value of the method</returns>
        public static TReturn Invoke<TReturn>(this object target, string methodName, Type[] paramTypes, object[] parameters)
        {
            return _Reflector.Invoke<TReturn>(target, methodName, paramTypes, parameters);
        }

        /// <summary>
        /// Creates a delegate which can invoke the specified static method.
        /// </summary>
        /// <param name="targetType">The type which the method belongs to</param>
        /// <param name="methodName">The name of the static method to be invoked</param>
        /// <returns>A delegate which can invoke the specified static method</returns>
        public static StaticMethodInvoker DelegateForStaticInvoke(this Type targetType, string methodName)
        {
            return _Reflector.DelegateForStaticInvoke(targetType, methodName);
        }

        /// <summary>
        /// Creates a delegate which can invoke the specified static method.
        /// </summary>
        /// <param name="targetType">The type which the method belongs to</param>
        /// <param name="methodName">The name of the static method to be invoked</param>
        /// <param name="paramTypes">The types of the method parameters (must be in the right order)</param>
        /// <returns>A delegate which can invoke the specified static method</returns>
        public static StaticMethodInvoker DelegateForStaticInvoke(this Type targetType, string methodName, Type[] paramTypes)
        {
            return _Reflector.DelegateForStaticInvoke(targetType, methodName, paramTypes);
        }

        /// <summary>
        /// Creates a delegate which can invoke the specified method.
        /// </summary>
        /// <param name="targetType">The type which the method belongs to</param>
        /// <param name="methodName">The name of the method to be invoked</param>
        /// <returns>A delegate which can invoke the specified method</returns>
        public static MethodInvoker DelegateForInvoke(this Type targetType, string methodName)
        {
            return _Reflector.DelegateForInvoke(targetType, methodName);
        }

        /// <summary>
        /// Creates a delegate which can invoke the specified method.
        /// </summary>
        /// <param name="targetType">The type which the method belongs to</param>
        /// <param name="methodName">The name of the method to be invoked</param>
        /// <param name="paramTypes">The types of the method parameters (must be in the right order)</param>
        /// <returns>A delegate which can invoke the specified method</returns>
        public static MethodInvoker DelegateForInvoke(this Type targetType, string methodName, Type[] paramTypes)
        {
            return _Reflector.DelegateForInvoke(targetType, methodName, paramTypes);
        }

        #endregion

        #region Indexer

        /// <summary>
        /// Sets the value of the indexer of object <paramref name="target"/>
        /// </summary>
        /// <param name="target">The object whose indexer is to be set</param>
        /// <param name="paramTypes">The types of the indexer parameters (must be in the right order), plus
        /// the type of the indexer.  For example if the indexer is of type <code>string</code> and accepts 
        /// a parameter of type <code>int</code>, the <paramref name="paramTypes"/> must be specified with 
        /// <code>new Type[]{typeof(int), typeof(string)}</code></param>
        /// <param name="parameters">The list of the indexer parameters plus the value to be set to the indexer.
        /// This list must match with the <paramref name="paramTypes"/> list</param>
        /// <returns><paramref name="target"/></returns>
        public static object SetIndexer(this object target, Type[] paramTypes, object[] parameters)
        {
            _Reflector.SetIndexer(target, paramTypes, parameters);
            return target;
        }

        /// <summary>
        /// Gets the value of the indexer of object <paramref name="target"/>
        /// </summary>
        /// <typeparam name="TReturn">The type of the indexer</typeparam>
        /// <param name="target">The object whose indexer is to be retrieved</param>
        /// <param name="paramTypes">The types of the indexer parameters (must be in the right order)</param>
        /// <param name="parameters">The list of the indexer parameters</param>
        /// <returns>The value returned by the indexer</returns>
        public static TReturn GetIndexer<TReturn>(this object target, Type[] paramTypes, object[] parameters)
        {
            return _Reflector.GetIndexer<TReturn>(target, paramTypes, parameters);
        }

        /// <summary>
        /// Creates a delegate which can set an indexer
        /// </summary>
        /// <param name="targetType">The type which the indexer belongs to</param>
        /// <param name="paramTypes">The types of the indexer parameters (must be in the right order), plus
        /// the type of the indexer.  For example if the indexer is of type <code>string</code> and accepts 
        /// a parameter of type <code>int</code>, the <paramref name="paramTypes"/> must be specified with 
        /// <code>new Type[]{typeof(int), typeof(string)}</code></param>
        /// <returns>A delegate which can set an indexer</returns>
        public static MethodInvoker DelegateForSetIndexer(this Type targetType, Type[] paramTypes)
        {
            return _Reflector.DelegateForSetIndexer(targetType, paramTypes);
        }

        /// <summary>
        /// Creates a delegate which can get the value of an indexer
        /// </summary>
        /// <param name="targetType">The type which the indexer belongs to</param>
        /// <param name="paramTypes">The types of the indexer parameters (must be in the right order)</param>
        /// <returns>The delegate which can get the value of an indexer</returns>
        public static MethodInvoker DelegateForGetIndexer(this Type targetType, Type[] paramTypes)
        {
            return _Reflector.DelegateForGetIndexer(targetType, paramTypes);
        }

        #endregion
         * */
    }
}
