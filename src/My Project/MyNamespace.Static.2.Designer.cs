﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

// See Compiler::LoadXmlSolutionExtension
using System.Collections;
using System.Diagnostics;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.My
{
    [Embedded()]
    [DebuggerNonUserCode()]
    [System.Runtime.CompilerServices.CompilerGenerated()]
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    internal sealed class InternalXmlHelper
    {
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        private InternalXmlHelper()
        {
        }

        public static string get_Value(System.Collections.Generic.IEnumerable<System.Xml.Linq.XElement> source)
        {
            foreach (System.Xml.Linq.XElement item in source)
                return item.Value;
            return null;
        }

        public static void set_Value(System.Collections.Generic.IEnumerable<System.Xml.Linq.XElement> source, string value)
        {
            foreach (System.Xml.Linq.XElement item in source)
            {
                item.Value = value;
                break;
            }
        }

        public static string get_AttributeValue(System.Collections.Generic.IEnumerable<System.Xml.Linq.XElement> source, System.Xml.Linq.XName name)
        {
            foreach (System.Xml.Linq.XElement item in source)
                return Conversions.ToString(item.Attribute(name));
            return null;
        }

        public static void set_AttributeValue(System.Collections.Generic.IEnumerable<System.Xml.Linq.XElement> source, System.Xml.Linq.XName name, string value)
        {
            foreach (System.Xml.Linq.XElement item in source)
            {
                item.SetAttributeValue(name, value);
                break;
            }
        }

        public static string get_AttributeValue(System.Xml.Linq.XElement source, System.Xml.Linq.XName name)
        {
            return Conversions.ToString(source.Attribute(name));
        }

        public static void set_AttributeValue(System.Xml.Linq.XElement source, System.Xml.Linq.XName name, string value)
        {
            source.SetAttributeValue(name, value);
        }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static System.Xml.Linq.XAttribute CreateAttribute(System.Xml.Linq.XName name, object value)
        {
            if (value is null)
            {
                return null;
            }

            return new System.Xml.Linq.XAttribute(name, value);
        }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static System.Xml.Linq.XAttribute CreateNamespaceAttribute(System.Xml.Linq.XName name, System.Xml.Linq.XNamespace ns)
        {
            var a = new System.Xml.Linq.XAttribute(name, ns.NamespaceName);
            a.AddAnnotation(ns);
            return a;
        }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static object RemoveNamespaceAttributes(string[] inScopePrefixes, System.Xml.Linq.XNamespace[] inScopeNs, System.Collections.Generic.List<System.Xml.Linq.XAttribute> attributes, object obj)
        {
            if (obj is object)
            {
                System.Xml.Linq.XElement elem = obj as System.Xml.Linq.XElement;
                if (elem is object)
                {
                    return RemoveNamespaceAttributes(inScopePrefixes, inScopeNs, attributes, elem);
                }
                else
                {
                    IEnumerable elems = obj as IEnumerable;
                    if (elems is object)
                    {
                        return RemoveNamespaceAttributes(inScopePrefixes, inScopeNs, attributes, elems);
                    }
                }
            }

            return obj;
        }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static IEnumerable RemoveNamespaceAttributes(string[] inScopePrefixes, System.Xml.Linq.XNamespace[] inScopeNs, System.Collections.Generic.List<System.Xml.Linq.XAttribute> attributes, IEnumerable obj)
        {
            if (obj is object)
            {
                System.Collections.Generic.IEnumerable<System.Xml.Linq.XElement> elems = obj as System.Collections.Generic.IEnumerable<System.Xml.Linq.XElement>;
                if (elems is object)
                {
                    return System.Linq.Enumerable.Select(elems, new RemoveNamespaceAttributesClosure(inScopePrefixes, inScopeNs, attributes).ProcessXElement);
                }
                else
                {
                    return System.Linq.Enumerable.Select(System.Linq.Enumerable.Cast<object>(obj), new RemoveNamespaceAttributesClosure(inScopePrefixes, inScopeNs, attributes).ProcessObject);
                }
            }

            return obj;
        }

        [DebuggerNonUserCode()]
        [System.Runtime.CompilerServices.CompilerGenerated()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        private sealed class RemoveNamespaceAttributesClosure
        {
            private readonly string[] m_inScopePrefixes;
            private readonly System.Xml.Linq.XNamespace[] m_inScopeNs;
            private readonly System.Collections.Generic.List<System.Xml.Linq.XAttribute> m_attributes;

            [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
            internal RemoveNamespaceAttributesClosure(string[] inScopePrefixes, System.Xml.Linq.XNamespace[] inScopeNs, System.Collections.Generic.List<System.Xml.Linq.XAttribute> attributes)
            {
                m_inScopePrefixes = inScopePrefixes;
                m_inScopeNs = inScopeNs;
                m_attributes = attributes;
            }

            [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
            internal System.Xml.Linq.XElement ProcessXElement(System.Xml.Linq.XElement elem)
            {
                return RemoveNamespaceAttributes(m_inScopePrefixes, m_inScopeNs, m_attributes, elem);
            }

            [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
            internal object ProcessObject(object obj)
            {
                System.Xml.Linq.XElement elem = obj as System.Xml.Linq.XElement;
                if (elem is object)
                {
                    return RemoveNamespaceAttributes(m_inScopePrefixes, m_inScopeNs, m_attributes, elem);
                }
                else
                {
                    return obj;
                }
            }
        }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static System.Xml.Linq.XElement RemoveNamespaceAttributes(string[] inScopePrefixes, System.Xml.Linq.XNamespace[] inScopeNs, System.Collections.Generic.List<System.Xml.Linq.XAttribute> attributes, System.Xml.Linq.XElement e)
        {
            if (e is object)
            {
                var a = e.FirstAttribute;
                while (a is object)
                {
                    var nextA = a.NextAttribute;
                    if (a.IsNamespaceDeclaration)
                    {
                        var ns = a.Annotation<System.Xml.Linq.XNamespace>();
                        string prefix = a.Name.LocalName;
                        if (ns is object)
                        {
                            if (inScopePrefixes is object && inScopeNs is object)
                            {
                                int lastIndex = inScopePrefixes.Length - 1;
                                for (int i = 0, loopTo = lastIndex; i <= loopTo; i++)
                                {
                                    string currentInScopePrefix = inScopePrefixes[i];
                                    var currentInScopeNs = inScopeNs[i];
                                    if (prefix.Equals(currentInScopePrefix))
                                    {
                                        if (ns == currentInScopeNs)
                                        {
                                            // prefix and namespace match.  Remove the unneeded ns attribute 
                                            a.Remove();
                                        }

                                        // prefix is in scope but refers to something else.  Leave the ns attribute. 
                                        a = null;
                                        break;
                                    }
                                }
                            }

                            if (a is object)
                            {
                                // Prefix is not in scope 
                                // Now check whether it's going to be in scope because it is in the attributes list 

                                if (attributes is object)
                                {
                                    int lastIndex = attributes.Count - 1;
                                    for (int i = 0, loopTo1 = lastIndex; i <= loopTo1; i++)
                                    {
                                        var currentA = attributes[i];
                                        string currentInScopePrefix = currentA.Name.LocalName;
                                        var currentInScopeNs = currentA.Annotation<System.Xml.Linq.XNamespace>();
                                        if (currentInScopeNs is object)
                                        {
                                            if (prefix.Equals(currentInScopePrefix))
                                            {
                                                if (ns == currentInScopeNs)
                                                {
                                                    // prefix and namespace match.  Remove the unneeded ns attribute 
                                                    a.Remove();
                                                }

                                                // prefix is in scope but refers to something else.  Leave the ns attribute. 
                                                a = null;
                                                break;
                                            }
                                        }
                                    }
                                }

                                if (a is object)
                                {
                                    // Prefix is definitely not in scope  
                                    a.Remove();
                                    // namespace is not defined either.  Add this attributes list 
                                    attributes.Add(a);
                                }
                            }
                        }
                    }

                    a = nextA;
                }
            }

            return e;
        }
    }
}