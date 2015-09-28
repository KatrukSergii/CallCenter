using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CallCenter.Client.SqlStorage.Entities;
using CallCenter.Common;
using CallCenter.Common.Entities;

namespace CallCenter.Server.Helper
{
    public static class KnownTypesHelper
    {

        private static readonly List<Type> KnownTypes;

        /// <summary>
        /// Lists all WCF known types
        /// </summary>
        /// <param name="provider"></param>
        /// <returns>A collection of all WCF known types</returns>
        public static IEnumerable<Type> GetKnownTypes(ICustomAttributeProvider provider)
        {
            return KnownTypes;
        }

        static KnownTypesHelper()
        {
            string interfaceToFindName = typeof (ISerializable).Name;   
            KnownTypes = new List<Type>();
            KnownTypes.AddRange(
                Assembly.GetAssembly(typeof (Operator))
                    .GetTypes().Where(type => type.GetInterface(interfaceToFindName) != null));
        }
    }
}