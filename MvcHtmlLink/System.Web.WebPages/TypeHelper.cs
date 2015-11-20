/*
Copyright (c) Microsoft Open Technologies, Inc.  All rights reserved.
Microsoft Open Technologies would like to thank its contributors, a list
of whom are at http://aspnetwebstack.codeplex.com/wikipage?title=Contributors.

Licensed under the Apache License, Version 2.0 (the "License"); you
may not use this file except in compliance with the License. You may
obtain a copy of the License at

http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or
implied. See the License for the specific language governing permissions
and limitations under the License.
*/

using System.Web.Routing;
using System.Web.WebPages;

namespace System.Web.WebPages
{
    internal static class TypeHelper
    {
        /// <summary>
        /// Given an object of anonymous type, add each property as a key and associated with its value to a dictionary.
        ///
        /// This helper will cache accessors and types, and is intended when the anonymous object is accessed multiple
        /// times throughout the lifetime of the web application.
        /// </summary>
        public static RouteValueDictionary ObjectToDictionary(object value)
        {
            RouteValueDictionary dictionary = new RouteValueDictionary();

            if (value != null)
            {
                foreach (PropertyHelper helper in PropertyHelper.GetProperties(value))
                {
                    dictionary.Add(helper.Name, helper.GetValue(value));
                }
            }

            return dictionary;
        }
    }
}
