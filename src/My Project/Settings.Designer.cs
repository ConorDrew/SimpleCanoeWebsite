﻿// ------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by a tool.
// Runtime Version:4.0.30319.42000
// 
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------

using System.Diagnostics;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    [System.Runtime.CompilerServices.CompilerGenerated()]
    [System.CodeDom.Compiler.GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.6.0.0")]
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
    internal sealed partial class MySettings : System.Configuration.ApplicationSettingsBase
    {
        private static MySettings defaultInstance = (MySettings)Synchronized(new MySettings());

           
        public static MySettings Default
        {
            get
            {

                   
                return defaultInstance;
            }
        }

        [System.Configuration.ApplicationScopedSetting()]
        [DebuggerNonUserCode()]
        [System.Configuration.SpecialSetting(System.Configuration.SpecialSetting.ConnectionString)]
        [System.Configuration.DefaultSettingValue(@"Data Source=BLUEPLEX\MSDE;Initial Catalog=FSM;Integrated Security=True")]
        public string FSM
        {
            get
            {
                return Conversions.ToString(this["FSM"]);
            }
        }

        [System.Configuration.UserScopedSetting()]
        [DebuggerNonUserCode()]
        [System.Configuration.DefaultSettingValue("True")]
        public bool FirstRun
        {
            get
            {
                return Conversions.ToBoolean(this["FirstRun"]);
            }

            set
            {
                this["FirstRun"] = value;
            }
        }
    }

    namespace My
    {
        [HideModuleName()]
        [DebuggerNonUserCode()]
        [System.Runtime.CompilerServices.CompilerGenerated()]
        internal static class MySettingsProperty
        {
            [System.ComponentModel.Design.HelpKeyword("My.Settings")]
            internal static MySettings Settings
            {
                get
                {
                    return MySettings.Default;
                }
            }
        }
    }
}