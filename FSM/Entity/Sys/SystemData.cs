// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Sys.SystemData
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System.Data;
using System.Reflection;

namespace FSM.Entity.Sys
{
  public class SystemData
  {
    private const Enums.DatabaseSystems _DataBaseServerType = Enums.DatabaseSystems.Microsoft_SQL_Server;
    private Configuration _Configuration;
    private const string _DeletedPostfix = " (Deleted)";
    private const string _Title = "Field Service Manager - Beta";
    private const string _Description = "Field Management System";
    private const string _Company = "Gasway Services Ltd";
    private const string _Product = "FSM";
    private const string _Copyright = "FSM";
    private const string _Trademark = "FSM";
    private const string _Address = "Exel Computer Systems plc\r\n\r\nBothe Hall\r\nSawley\r\nNottingham\r\nNG10 3XL";
    private const string _Telephone = "0115 946 0101";
    private const string _Fax = "0115 946 0101\"";

    public SystemData()
    {
      this._Configuration = new Configuration();
    }

    public Enums.DatabaseSystems DataBaseServerType
    {
      get
      {
        return Enums.DatabaseSystems.Microsoft_SQL_Server;
      }
    }

    public Configuration Configuration
    {
      get
      {
        return this._Configuration;
      }
    }

    public string DeletedPostfix
    {
      get
      {
        return " (Deleted)";
      }
    }

    public string Title
    {
      get
      {
        return "Field Service Manager - Beta";
      }
    }

    public string Description
    {
      get
      {
        return "Field Management System";
      }
    }

    public string Company
    {
      get
      {
        return "Gasway Services Ltd";
      }
    }

    public string Product
    {
      get
      {
        return "FSM";
      }
    }

    public string Copyright
    {
      get
      {
        return "FSM";
      }
    }

    public string Trademark
    {
      get
      {
        return "FSM";
      }
    }

    public DataTable DLLInformation
    {
      get
      {
        DataTable dataTable = new DataTable();
        dataTable.Columns.Add("Name");
        dataTable.Columns.Add("Version");
        AssemblyName[] referencedAssemblies = this.GetType().Assembly.GetReferencedAssemblies();
        int index = 0;
        while (index < referencedAssemblies.Length)
        {
          AssemblyName assemblyName = referencedAssemblies[index];
          dataTable.Rows.Add((object[]) new string[2]
          {
            assemblyName.Name,
            assemblyName.Version.ToString()
          });
          checked { ++index; }
        }
        dataTable.TableName = Enums.TableNames.NOT_IN_DATABASE_DLLs.ToString();
        return dataTable;
      }
    }

    public string Address
    {
      get
      {
        return "Exel Computer Systems plc\r\n\r\nBothe Hall\r\nSawley\r\nNottingham\r\nNG10 3XL";
      }
    }

    public string Telephone
    {
      get
      {
        return "0115 946 0101";
      }
    }

    public string Fax
    {
      get
      {
        return "0115 946 0101\"";
      }
    }

    public string ContactUs
    {
      get
      {
        return this.Address + "\r\n\r\n\r\nTel : " + this.Telephone + "\r\n\r\n\r\n";
      }
    }
  }
}
