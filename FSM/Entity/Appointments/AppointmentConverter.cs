// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Appointments.AppointmentConverter
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

namespace FSM.Entity.Appointments
{
  public class AppointmentConverter
  {
    public int ToNew(int appointmentID)
    {
      switch (appointmentID)
      {
        case 69938:
          return 1;
        case 69939:
          return 2;
        case 69940:
          return 3;
        case 69941:
          return 4;
        case 69942:
          return 5;
        case 69943:
          return 6;
        case 69944:
          return 7;
        case 69945:
          return 8;
        default:
          return 0;
      }
    }

    public int ToOld(int appointmentID)
    {
      switch (appointmentID)
      {
        case 1:
          return 69938;
        case 2:
          return 69939;
        case 3:
          return 69940;
        case 4:
          return 69941;
        case 5:
          return 69942;
        case 6:
          return 69943;
        case 7:
          return 69944;
        case 8:
          return 69945;
        default:
          return 0;
      }
    }
  }
}
