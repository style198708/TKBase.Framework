﻿#region License

//   Copyright 2010 John Sheehan
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License. 

#endregion

using System.Reflection;
using System.Xml.Linq;
using TKBase.Framework.RestSharp.Extensions;

namespace TKBase.Framework.RestSharp.Deserializers
{
    public class XmlAttributeDeserializer : XmlDeserializer
    {
        protected override object GetValueFromXml(XElement root, XName name, PropertyInfo prop, bool useExactName)
        {
            bool isAttribute = false;
            
            //Check for the DeserializeAs attribute on the property
            DeserializeAsAttribute options = prop.GetAttribute<DeserializeAsAttribute>();

            if (options != null)
            {
                name = options.Name ?? name;
                isAttribute = options.Attribute;
            }

            if (!isAttribute) return base.GetValueFromXml(root, name, prop, useExactName);
            
            XAttribute attributeVal = GetAttributeByName(root, name, useExactName);

            return attributeVal != null ? attributeVal.Value : base.GetValueFromXml(root, name, prop, useExactName);
        }
    }
}
