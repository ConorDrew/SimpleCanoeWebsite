using System;
using System.Collections;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace EngineerVisitAdditionals
    {
        public class EngineerVisitAdditional
        {
            private DataTypeValidator _dataTypeValidator;

            public EngineerVisitAdditional()
            {
                _dataTypeValidator = new DataTypeValidator();
            }

            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            public bool IgnoreExceptionsOnSetMethods
            {
                get
                {
                    return _dataTypeValidator.IgnoreExceptionsOnSetMethods;
                }

                set
                {
                    _dataTypeValidator.IgnoreExceptionsOnSetMethods = value;
                }
            }

            public Hashtable Errors
            {
                get
                {
                    return _dataTypeValidator.Errors;
                }
            }

            public DataTypeValidator DTValidator
            {
                get
                {
                    return _dataTypeValidator;
                }
            }

            private bool _exists = false;

            public bool Exists
            {
                get
                {
                    return _exists;
                }

                set
                {
                    _exists = value;
                }
            }

            private bool _deleted = false;

            public bool Deleted
            {
                get
                {
                    return _deleted;
                }
            }

            public bool SetDeleted
            {
                set
                {
                    _deleted = value;
                }
            }

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */

            private int _EngineerVisitID = 0;

            public int EngineerVisitID
            {
                get
                {
                    return _EngineerVisitID;
                }
            }

            public object SetEngineerVisitID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_EngineerVisitID", value);
                }
            }

            private int _EngineerVisitAdditionalID = 0;

            public int EngineerVisitAdditionalID
            {
                get
                {
                    return _EngineerVisitAdditionalID;
                }
            }

            public object SetEngineerVisitAdditionalID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_EngineerVisitAdditionalID", value);
                }
            }

            private int _TestTypeID = 0;

            public int TestTypeID
            {
                get
                {
                    return _TestTypeID;
                }
            }

            public object SetTestTypeID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_TestTypeID", value);
                }
            }

            private int _Test1 = 0;

            public int Test1
            {
                get
                {
                    return _Test1;
                }
            }

            public object SetTest1
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Test1", value);
                }
            }

            private int _Test2 = 0;

            public int Test2
            {
                get
                {
                    return _Test2;
                }
            }

            public object SetTest2
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Test2", value);
                }
            }

            private int _Test3 = 0;

            public int Test3
            {
                get
                {
                    return _Test3;
                }
            }

            public object SetTest3
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Test3", value);
                }
            }

            private int _Test4 = 0;

            public int Test4
            {
                get
                {
                    return _Test4;
                }
            }

            public object SetTest4
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Test4", value);
                }
            }

            private int _Test5 = 0;

            public int Test5
            {
                get
                {
                    return _Test5;
                }
            }

            public object SetTest5
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Test5", value);
                }
            }

            private int _Test6 = 0;

            public int Test6
            {
                get
                {
                    return _Test6;
                }
            }

            public object SetTest6
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Test6", value);
                }
            }

            private int _Test7 = 0;

            public int Test7
            {
                get
                {
                    return _Test7;
                }
            }

            public object SetTest7
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Test7", value);
                }
            }

            private int _Test8 = 0;

            public int Test8
            {
                get
                {
                    return _Test8;
                }
            }

            public object SetTest8
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Test8", value);
                }
            }

            private int _Test9 = 0;

            public int Test9
            {
                get
                {
                    return _Test9;
                }
            }

            public object SetTest9
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Test9", value);
                }
            }

            private int _Test10 = 0;

            public int Test10
            {
                get
                {
                    return _Test10;
                }
            }

            public object SetTest10
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Test10", value);
                }
            }

            private int _Test111 = 0;

            public int Test111
            {
                get
                {
                    return _Test111;
                }
            }

            public object SetTest111
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Test111", value);
                }
            }

            private int _Test112 = 0;

            public int Test112
            {
                get
                {
                    return _Test112;
                }
            }

            public object SetTest112
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Test112", value);
                }
            }

            private int _Test113 = 0;

            public int Test113
            {
                get
                {
                    return _Test113;
                }
            }

            public object SetTest113
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Test113", value);
                }
            }

            private int _Test114 = 0;

            public int Test114
            {
                get
                {
                    return _Test114;
                }
            }

            public object SetTest114
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Test114", value);
                }
            }

            private int _Test115 = 0;

            public int Test115
            {
                get
                {
                    return _Test115;
                }
            }

            public object SetTest115
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Test115", value);
                }
            }

            private int _Test116 = 0;

            public int Test116
            {
                get
                {
                    return _Test116;
                }
            }

            public object SetTest116
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Test116", value);
                }
            }

            private int _Test117 = 0;

            public int Test117
            {
                get
                {
                    return _Test117;
                }
            }

            public object SetTest117
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Test117", value);
                }
            }

            private int _Test118 = 0;

            public int Test118
            {
                get
                {
                    return _Test118;
                }
            }

            public object SetTest118
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Test118", value);
                }
            }

            private int _Test119 = 0;

            public int Test119
            {
                get
                {
                    return _Test119;
                }
            }

            public object SetTest119
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Test119", value);
                }
            }

            private int _Test120 = 0;

            public int Test120
            {
                get
                {
                    return _Test120;
                }
            }

            public object SetTest120
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Test120", value);
                }
            }

            private string _Test11 = string.Empty;

            public string Test11
            {
                get
                {
                    return _Test11;
                }
            }

            public object SetTest11
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Test11", value);
                }
            }

            private string _Test12 = string.Empty;

            public string Test12
            {
                get
                {
                    return _Test12;
                }
            }

            public object SetTest12
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Test12", value);
                }
            }

            private string _Test13 = string.Empty;

            public string Test13
            {
                get
                {
                    return _Test13;
                }
            }

            public object SetTest13
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Test13", value);
                }
            }

            private string _Test14 = string.Empty;

            public string Test14
            {
                get
                {
                    return _Test14;
                }
            }

            public object SetTest14
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Test14", value);
                }
            }

            private string _Test15 = string.Empty;

            public string Test15
            {
                get
                {
                    return _Test15;
                }
            }

            public object SetTest15
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Test15", value);
                }
            }

            private int _Test121 = 0;

            public int Test121
            {
                get
                {
                    return _Test121;
                }
            }

            public object SetTest121
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Test121", value);
                }
            }

            private int _Test122 = 0;

            public int Test122
            {
                get
                {
                    return _Test122;
                }
            }

            public object SetTest122
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Test122", value);
                }
            }

            private int _Test123 = 0;

            public int Test123
            {
                get
                {
                    return _Test123;
                }
            }

            public object SetTest123
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Test123", value);
                }
            }

            private int _Test124 = 0;

            public int Test124
            {
                get
                {
                    return _Test124;
                }
            }

            public object SetTest124
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Test124", value);
                }
            }

            private int _Test125 = 0;

            public int Test125
            {
                get
                {
                    return _Test125;
                }
            }

            public object SetTest125
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Test125", value);
                }
            }

            private int _Test126 = 0;

            public int Test126
            {
                get
                {
                    return _Test126;
                }
            }

            public object SetTest126
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Test126", value);
                }
            }

            private int _Test127 = 0;

            public int Test127
            {
                get
                {
                    return _Test125;
                }
            }

            public object SetTest127
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Test127", value);
                }
            }

            private int _Test128 = 0;

            public int Test128
            {
                get
                {
                    return _Test128;
                }
            }

            public object SetTest128
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Test128", value);
                }
            }

            private int _Test129 = 0;

            public int Test129
            {
                get
                {
                    return _Test129;
                }
            }

            public object SetTest129
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Test129", value);
                }
            }

            private int _Test130 = 0;

            public int Test130
            {
                get
                {
                    return _Test130;
                }
            }

            public object SetTest130
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Test130", value);
                }
            }

            private int _Test131 = 0;

            public int Test131
            {
                get
                {
                    return _Test131;
                }
            }

            public object SetTest131
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Test131", value);
                }
            }

            private int _Test132 = 0;

            public int Test132
            {
                get
                {
                    return _Test132;
                }
            }

            public object SetTest132
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Test132", value);
                }
            }

            private int _Test133 = 0;

            public int Test133
            {
                get
                {
                    return _Test133;
                }
            }

            public object SetTest133
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Test133", value);
                }
            }

            private int _Test134 = 0;

            public int Test134
            {
                get
                {
                    return _Test134;
                }
            }

            public object SetTest134
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Test134", value);
                }
            }

            private int _Test135 = 0;

            public int Test135
            {
                get
                {
                    return _Test135;
                }
            }

            public object SetTest135
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Test135", value);
                }
            }

            private int _Test136 = 0;

            public int Test136
            {
                get
                {
                    return _Test136;
                }
            }

            public object SetTest136
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Test136", value);
                }
            }

            private int _Test137 = 0;

            public int Test137
            {
                get
                {
                    return _Test137;
                }
            }

            public object SetTest137
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Test137", value);
                }
            }

            private int _Test138 = 0;

            public int Test138
            {
                get
                {
                    return _Test138;
                }
            }

            public object SetTest138
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Test138", value);
                }
            }

            private int _Test139 = 0;

            public int Test139
            {
                get
                {
                    return _Test139;
                }
            }

            public object SetTest139
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Test139", value);
                }
            }

            private int _Test140 = 0;

            public int Test140
            {
                get
                {
                    return _Test140;
                }
            }

            public object SetTest140
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Test140", value);
                }
            }

            private string _Test216 = string.Empty;

            public string Test216
            {
                get
                {
                    return _Test216;
                }
            }

            public object SetTest216
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Test216", value);
                }
            }

            private string _Test217 = string.Empty;

            public string Test217
            {
                get
                {
                    return _Test217;
                }
            }

            public object SetTest217
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Test217", value);
                }
            }

            private string _Test218 = string.Empty;

            public string Test218
            {
                get
                {
                    return _Test218;
                }
            }

            public object SetTest218
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Test218", value);
                }
            }

            private string _Test219 = string.Empty;

            public string Test219
            {
                get
                {
                    return _Test219;
                }
            }

            public object SetTest219
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Test219", value);
                }
            }

            private string _Test220 = string.Empty;

            public string Test220
            {
                get
                {
                    return _Test220;
                }
            }

            public object SetTest220
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Test220", value);
                }
            }

            private string _Test221 = string.Empty;

            public string Test221
            {
                get
                {
                    return _Test221;
                }
            }

            public object SetTest221
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Test221", value);
                }
            }

            private string _Test222 = string.Empty;

            public string Test222
            {
                get
                {
                    return _Test222;
                }
            }

            public object SetTest222
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Test222", value);
                }
            }

            private string _Test223 = string.Empty;

            public string Test223
            {
                get
                {
                    return _Test223;
                }
            }

            public object SetTest223
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Test223", value);
                }
            }

            private string _Test224 = string.Empty;

            public string Test224
            {
                get
                {
                    return _Test224;
                }
            }

            public object SetTest224
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Test224", value);
                }
            }

            private string _Test225 = string.Empty;

            public string Test225
            {
                get
                {
                    return _Test225;
                }
            }

            public object SetTest225
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Test225", value);
                }
            }

            private string _Test226 = string.Empty;

            public string Test226
            {
                get
                {
                    return _Test226;
                }
            }

            public object SetTest226
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Test226", value);
                }
            }

            private string _Test227 = string.Empty;

            public string Test227
            {
                get
                {
                    return _Test227;
                }
            }

            public object SetTest227
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Test227", value);
                }
            }

            private string _Test228 = string.Empty;

            public string Test228
            {
                get
                {
                    return _Test228;
                }
            }

            public object SetTest228
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Test228", value);
                }
            }

            private string _Test229 = string.Empty;

            public string Test229
            {
                get
                {
                    return _Test229;
                }
            }

            public object SetTest229
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Test229", value);
                }
            }

            private string _Test230 = string.Empty;

            public string Test230
            {
                get
                {
                    return _Test230;
                }
            }

            public object SetTest230
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Test230", value);
                }
            }

            private string _Test231 = string.Empty;

            public string Test231
            {
                get
                {
                    return _Test231;
                }
            }

            public object SetTest231
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Test231", value);
                }
            }

            private string _Test232 = string.Empty;

            public string Test232
            {
                get
                {
                    return _Test232;
                }
            }

            public object SetTest232
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Test232", value);
                }
            }

            private string _Test233 = string.Empty;

            public string Test233
            {
                get
                {
                    return _Test233;
                }
            }

            public object SetTest233
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Test233", value);
                }
            }

            private string _Test234 = string.Empty;

            public string Test234
            {
                get
                {
                    return _Test234;
                }
            }

            public object SetTest234
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Test234", value);
                }
            }

            private string _Test235 = string.Empty;

            public string Test235
            {
                get
                {
                    return _Test235;
                }
            }

            public object SetTest235
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Test235", value);
                }
            }

            private string _Test236 = string.Empty;

            public string Test236
            {
                get
                {
                    return _Test236;
                }
            }

            public object SetTest236
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Test236", value);
                }
            }

            private string _Test237 = string.Empty;

            public string Test237
            {
                get
                {
                    return _Test237;
                }
            }

            public object SetTest237
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Test237", value);
                }
            }

            private string _Test238 = string.Empty;

            public string Test238
            {
                get
                {
                    return _Test238;
                }
            }

            public object SetTest238
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Test238", value);
                }
            }

            private string _Test239 = string.Empty;

            public string Test239
            {
                get
                {
                    return _Test239;
                }
            }

            public object SetTest239
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Test239", value);
                }
            }

            private string _Test240 = string.Empty;

            public string Test240
            {
                get
                {
                    return _Test240;
                }
            }

            public object SetTest240
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Test240", value);
                }
            }

            private DateTime _Test16 = DateTime.MinValue;

            public DateTime Test16
            {
                get
                {
                    return _Test16;
                }
            }

            public DateTime SetTest16
            {
                set
                {
                    if (Information.IsDBNull(value))
                    {
                        _Test16 = Conversions.ToDate("1900-01-01");
                    }
                    else
                    {
                        _Test16 = Conversions.ToDate(value);
                    }
                }
            }

            private DateTime _Test17 = DateTime.MinValue;

            public DateTime Test17
            {
                get
                {
                    return _Test17;
                }
            }

            public DateTime SetTest17
            {
                set
                {
                    if (Information.IsDBNull(value))
                    {
                        _Test17 = Conversions.ToDate("1900-01-01");
                    }
                    else
                    {
                        _Test17 = Conversions.ToDate(value);
                    }
                }
            }

            private DateTime _Test18 = DateTime.MinValue;

            public DateTime Test18
            {
                get
                {
                    return _Test18;
                }
            }

            public DateTime SetTest18
            {
                set
                {
                    if (Information.IsDBNull(value))
                    {
                        _Test18 = Conversions.ToDate("1900-01-01");
                    }
                    else
                    {
                        _Test18 = Conversions.ToDate(value);
                    }
                }
            }

            private string _TypeString = string.Empty;

            public string TypeString
            {
                get
                {
                    return _TypeString;
                }
            }

            public object SetTypeString
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_TypeString", value);
                }
            }





            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}