// Decompiled with JetBrains decompiler
// Type: FSM.Entity.EngineerVisitAdditionals.EngineerVisitAdditional
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.EngineerVisitAdditionals
{
  public class EngineerVisitAdditional
  {
    private DataTypeValidator _dataTypeValidator;
    private bool _exists;
    private bool _deleted;
    private int _EngineerVisitID;
    private int _EngineerVisitAdditionalID;
    private int _TestTypeID;
    private int _Test1;
    private int _Test2;
    private int _Test3;
    private int _Test4;
    private int _Test5;
    private int _Test6;
    private int _Test7;
    private int _Test8;
    private int _Test9;
    private int _Test10;
    private int _Test111;
    private int _Test112;
    private int _Test113;
    private int _Test114;
    private int _Test115;
    private int _Test116;
    private int _Test117;
    private int _Test118;
    private int _Test119;
    private int _Test120;
    private string _Test11;
    private string _Test12;
    private string _Test13;
    private string _Test14;
    private string _Test15;
    private int _Test121;
    private int _Test122;
    private int _Test123;
    private int _Test124;
    private int _Test125;
    private int _Test126;
    private int _Test127;
    private int _Test128;
    private int _Test129;
    private int _Test130;
    private int _Test131;
    private int _Test132;
    private int _Test133;
    private int _Test134;
    private int _Test135;
    private int _Test136;
    private int _Test137;
    private int _Test138;
    private int _Test139;
    private int _Test140;
    private string _Test216;
    private string _Test217;
    private string _Test218;
    private string _Test219;
    private string _Test220;
    private string _Test221;
    private string _Test222;
    private string _Test223;
    private string _Test224;
    private string _Test225;
    private string _Test226;
    private string _Test227;
    private string _Test228;
    private string _Test229;
    private string _Test230;
    private string _Test231;
    private string _Test232;
    private string _Test233;
    private string _Test234;
    private string _Test235;
    private string _Test236;
    private string _Test237;
    private string _Test238;
    private string _Test239;
    private string _Test240;
    private DateTime _Test16;
    private DateTime _Test17;
    private DateTime _Test18;
    private string _TypeString;

    public EngineerVisitAdditional()
    {
      this._exists = false;
      this._deleted = false;
      this._EngineerVisitID = 0;
      this._EngineerVisitAdditionalID = 0;
      this._TestTypeID = 0;
      this._Test1 = 0;
      this._Test2 = 0;
      this._Test3 = 0;
      this._Test4 = 0;
      this._Test5 = 0;
      this._Test6 = 0;
      this._Test7 = 0;
      this._Test8 = 0;
      this._Test9 = 0;
      this._Test10 = 0;
      this._Test111 = 0;
      this._Test112 = 0;
      this._Test113 = 0;
      this._Test114 = 0;
      this._Test115 = 0;
      this._Test116 = 0;
      this._Test117 = 0;
      this._Test118 = 0;
      this._Test119 = 0;
      this._Test120 = 0;
      this._Test11 = string.Empty;
      this._Test12 = string.Empty;
      this._Test13 = string.Empty;
      this._Test14 = string.Empty;
      this._Test15 = string.Empty;
      this._Test121 = 0;
      this._Test122 = 0;
      this._Test123 = 0;
      this._Test124 = 0;
      this._Test125 = 0;
      this._Test126 = 0;
      this._Test127 = 0;
      this._Test128 = 0;
      this._Test129 = 0;
      this._Test130 = 0;
      this._Test131 = 0;
      this._Test132 = 0;
      this._Test133 = 0;
      this._Test134 = 0;
      this._Test135 = 0;
      this._Test136 = 0;
      this._Test137 = 0;
      this._Test138 = 0;
      this._Test139 = 0;
      this._Test140 = 0;
      this._Test216 = string.Empty;
      this._Test217 = string.Empty;
      this._Test218 = string.Empty;
      this._Test219 = string.Empty;
      this._Test220 = string.Empty;
      this._Test221 = string.Empty;
      this._Test222 = string.Empty;
      this._Test223 = string.Empty;
      this._Test224 = string.Empty;
      this._Test225 = string.Empty;
      this._Test226 = string.Empty;
      this._Test227 = string.Empty;
      this._Test228 = string.Empty;
      this._Test229 = string.Empty;
      this._Test230 = string.Empty;
      this._Test231 = string.Empty;
      this._Test232 = string.Empty;
      this._Test233 = string.Empty;
      this._Test234 = string.Empty;
      this._Test235 = string.Empty;
      this._Test236 = string.Empty;
      this._Test237 = string.Empty;
      this._Test238 = string.Empty;
      this._Test239 = string.Empty;
      this._Test240 = string.Empty;
      this._Test16 = DateTime.MinValue;
      this._Test17 = DateTime.MinValue;
      this._Test18 = DateTime.MinValue;
      this._TypeString = string.Empty;
      this._dataTypeValidator = new DataTypeValidator();
    }

    public bool IgnoreExceptionsOnSetMethods
    {
      get
      {
        return this._dataTypeValidator.IgnoreExceptionsOnSetMethods;
      }
      set
      {
        this._dataTypeValidator.IgnoreExceptionsOnSetMethods = value;
      }
    }

    public Hashtable Errors
    {
      get
      {
        return this._dataTypeValidator.Errors;
      }
    }

    public DataTypeValidator DTValidator
    {
      get
      {
        return this._dataTypeValidator;
      }
    }

    public bool Exists
    {
      get
      {
        return this._exists;
      }
      set
      {
        this._exists = value;
      }
    }

    public bool Deleted
    {
      get
      {
        return this._deleted;
      }
    }

    public bool SetDeleted
    {
      set
      {
        this._deleted = value;
      }
    }

    public int EngineerVisitID
    {
      get
      {
        return this._EngineerVisitID;
      }
    }

    public object SetEngineerVisitID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_EngineerVisitID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int EngineerVisitAdditionalID
    {
      get
      {
        return this._EngineerVisitAdditionalID;
      }
    }

    public object SetEngineerVisitAdditionalID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_EngineerVisitAdditionalID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int TestTypeID
    {
      get
      {
        return this._TestTypeID;
      }
    }

    public object SetTestTypeID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_TestTypeID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int Test1
    {
      get
      {
        return this._Test1;
      }
    }

    public object SetTest1
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Test1", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int Test2
    {
      get
      {
        return this._Test2;
      }
    }

    public object SetTest2
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Test2", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int Test3
    {
      get
      {
        return this._Test3;
      }
    }

    public object SetTest3
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Test3", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int Test4
    {
      get
      {
        return this._Test4;
      }
    }

    public object SetTest4
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Test4", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int Test5
    {
      get
      {
        return this._Test5;
      }
    }

    public object SetTest5
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Test5", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int Test6
    {
      get
      {
        return this._Test6;
      }
    }

    public object SetTest6
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Test6", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int Test7
    {
      get
      {
        return this._Test7;
      }
    }

    public object SetTest7
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Test7", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int Test8
    {
      get
      {
        return this._Test8;
      }
    }

    public object SetTest8
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Test8", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int Test9
    {
      get
      {
        return this._Test9;
      }
    }

    public object SetTest9
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Test9", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int Test10
    {
      get
      {
        return this._Test10;
      }
    }

    public object SetTest10
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Test10", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int Test111
    {
      get
      {
        return this._Test111;
      }
    }

    public object SetTest111
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Test111", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int Test112
    {
      get
      {
        return this._Test112;
      }
    }

    public object SetTest112
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Test112", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int Test113
    {
      get
      {
        return this._Test113;
      }
    }

    public object SetTest113
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Test113", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int Test114
    {
      get
      {
        return this._Test114;
      }
    }

    public object SetTest114
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Test114", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int Test115
    {
      get
      {
        return this._Test115;
      }
    }

    public object SetTest115
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Test115", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int Test116
    {
      get
      {
        return this._Test116;
      }
    }

    public object SetTest116
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Test116", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int Test117
    {
      get
      {
        return this._Test117;
      }
    }

    public object SetTest117
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Test117", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int Test118
    {
      get
      {
        return this._Test118;
      }
    }

    public object SetTest118
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Test118", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int Test119
    {
      get
      {
        return this._Test119;
      }
    }

    public object SetTest119
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Test119", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int Test120
    {
      get
      {
        return this._Test120;
      }
    }

    public object SetTest120
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Test120", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string Test11
    {
      get
      {
        return this._Test11;
      }
    }

    public object SetTest11
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Test11", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string Test12
    {
      get
      {
        return this._Test12;
      }
    }

    public object SetTest12
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Test12", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string Test13
    {
      get
      {
        return this._Test13;
      }
    }

    public object SetTest13
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Test13", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string Test14
    {
      get
      {
        return this._Test14;
      }
    }

    public object SetTest14
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Test14", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string Test15
    {
      get
      {
        return this._Test15;
      }
    }

    public object SetTest15
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Test15", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int Test121
    {
      get
      {
        return this._Test121;
      }
    }

    public object SetTest121
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Test121", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int Test122
    {
      get
      {
        return this._Test122;
      }
    }

    public object SetTest122
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Test122", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int Test123
    {
      get
      {
        return this._Test123;
      }
    }

    public object SetTest123
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Test123", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int Test124
    {
      get
      {
        return this._Test124;
      }
    }

    public object SetTest124
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Test124", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int Test125
    {
      get
      {
        return this._Test125;
      }
    }

    public object SetTest125
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Test125", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int Test126
    {
      get
      {
        return this._Test126;
      }
    }

    public object SetTest126
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Test126", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int Test127
    {
      get
      {
        return this._Test125;
      }
    }

    public object SetTest127
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Test127", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int Test128
    {
      get
      {
        return this._Test128;
      }
    }

    public object SetTest128
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Test128", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int Test129
    {
      get
      {
        return this._Test129;
      }
    }

    public object SetTest129
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Test129", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int Test130
    {
      get
      {
        return this._Test130;
      }
    }

    public object SetTest130
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Test130", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int Test131
    {
      get
      {
        return this._Test131;
      }
    }

    public object SetTest131
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Test131", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int Test132
    {
      get
      {
        return this._Test132;
      }
    }

    public object SetTest132
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Test132", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int Test133
    {
      get
      {
        return this._Test133;
      }
    }

    public object SetTest133
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Test133", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int Test134
    {
      get
      {
        return this._Test134;
      }
    }

    public object SetTest134
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Test134", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int Test135
    {
      get
      {
        return this._Test135;
      }
    }

    public object SetTest135
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Test135", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int Test136
    {
      get
      {
        return this._Test136;
      }
    }

    public object SetTest136
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Test136", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int Test137
    {
      get
      {
        return this._Test137;
      }
    }

    public object SetTest137
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Test137", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int Test138
    {
      get
      {
        return this._Test138;
      }
    }

    public object SetTest138
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Test138", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int Test139
    {
      get
      {
        return this._Test139;
      }
    }

    public object SetTest139
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Test139", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int Test140
    {
      get
      {
        return this._Test140;
      }
    }

    public object SetTest140
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Test140", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string Test216
    {
      get
      {
        return this._Test216;
      }
    }

    public object SetTest216
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Test216", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string Test217
    {
      get
      {
        return this._Test217;
      }
    }

    public object SetTest217
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Test217", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string Test218
    {
      get
      {
        return this._Test218;
      }
    }

    public object SetTest218
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Test218", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string Test219
    {
      get
      {
        return this._Test219;
      }
    }

    public object SetTest219
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Test219", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string Test220
    {
      get
      {
        return this._Test220;
      }
    }

    public object SetTest220
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Test220", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string Test221
    {
      get
      {
        return this._Test221;
      }
    }

    public object SetTest221
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Test221", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string Test222
    {
      get
      {
        return this._Test222;
      }
    }

    public object SetTest222
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Test222", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string Test223
    {
      get
      {
        return this._Test223;
      }
    }

    public object SetTest223
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Test223", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string Test224
    {
      get
      {
        return this._Test224;
      }
    }

    public object SetTest224
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Test224", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string Test225
    {
      get
      {
        return this._Test225;
      }
    }

    public object SetTest225
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Test225", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string Test226
    {
      get
      {
        return this._Test226;
      }
    }

    public object SetTest226
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Test226", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string Test227
    {
      get
      {
        return this._Test227;
      }
    }

    public object SetTest227
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Test227", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string Test228
    {
      get
      {
        return this._Test228;
      }
    }

    public object SetTest228
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Test228", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string Test229
    {
      get
      {
        return this._Test229;
      }
    }

    public object SetTest229
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Test229", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string Test230
    {
      get
      {
        return this._Test230;
      }
    }

    public object SetTest230
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Test230", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string Test231
    {
      get
      {
        return this._Test231;
      }
    }

    public object SetTest231
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Test231", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string Test232
    {
      get
      {
        return this._Test232;
      }
    }

    public object SetTest232
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Test232", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string Test233
    {
      get
      {
        return this._Test233;
      }
    }

    public object SetTest233
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Test233", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string Test234
    {
      get
      {
        return this._Test234;
      }
    }

    public object SetTest234
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Test234", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string Test235
    {
      get
      {
        return this._Test235;
      }
    }

    public object SetTest235
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Test235", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string Test236
    {
      get
      {
        return this._Test236;
      }
    }

    public object SetTest236
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Test236", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string Test237
    {
      get
      {
        return this._Test237;
      }
    }

    public object SetTest237
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Test237", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string Test238
    {
      get
      {
        return this._Test238;
      }
    }

    public object SetTest238
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Test238", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string Test239
    {
      get
      {
        return this._Test239;
      }
    }

    public object SetTest239
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Test239", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string Test240
    {
      get
      {
        return this._Test240;
      }
    }

    public object SetTest240
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Test240", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public DateTime Test16
    {
      get
      {
        return this._Test16;
      }
    }

    public DateTime SetTest16
    {
      set
      {
        if (Information.IsDBNull((object) value))
          this._Test16 = Conversions.ToDate("1900-01-01");
        else
          this._Test16 = value;
      }
    }

    public DateTime Test17
    {
      get
      {
        return this._Test17;
      }
    }

    public DateTime SetTest17
    {
      set
      {
        if (Information.IsDBNull((object) value))
          this._Test17 = Conversions.ToDate("1900-01-01");
        else
          this._Test17 = value;
      }
    }

    public DateTime Test18
    {
      get
      {
        return this._Test18;
      }
    }

    public DateTime SetTest18
    {
      set
      {
        if (Information.IsDBNull((object) value))
          this._Test18 = Conversions.ToDate("1900-01-01");
        else
          this._Test18 = value;
      }
    }

    public string TypeString
    {
      get
      {
        return this._TypeString;
      }
    }

    public object SetTypeString
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_TypeString", RuntimeHelpers.GetObjectValue(value));
      }
    }
  }
}
