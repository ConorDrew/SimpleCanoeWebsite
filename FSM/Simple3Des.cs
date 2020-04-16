// Decompiled with JetBrains decompiler
// Type: FSM.Simple3Des
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace FSM
{
  public sealed class Simple3Des
  {
    private TripleDESCryptoServiceProvider TripleDes;

    public Simple3Des(string key)
    {
      this.TripleDes = new TripleDESCryptoServiceProvider();
      this.TripleDes.Key = this.TruncateHash(key, this.TripleDes.KeySize / 8);
      this.TripleDes.IV = this.TruncateHash("", this.TripleDes.BlockSize / 8);
    }

    private byte[] TruncateHash(string key, int length)
    {
      return (byte[]) Microsoft.VisualBasic.CompilerServices.Utils.CopyArray((Array) new SHA1CryptoServiceProvider().ComputeHash(Encoding.Unicode.GetBytes(key)), (Array) new byte[checked (length - 1 + 1)]);
    }

    public string EncryptData(string plaintext)
    {
      byte[] bytes = Encoding.Unicode.GetBytes(plaintext);
      MemoryStream memoryStream = new MemoryStream();
      CryptoStream cryptoStream = new CryptoStream((Stream) memoryStream, this.TripleDes.CreateEncryptor(), CryptoStreamMode.Write);
      cryptoStream.Write(bytes, 0, bytes.Length);
      cryptoStream.FlushFinalBlock();
      return Convert.ToBase64String(memoryStream.ToArray());
    }

    public string DecryptData(string encryptedtext)
    {
      byte[] buffer = Convert.FromBase64String(encryptedtext);
      MemoryStream memoryStream = new MemoryStream();
      CryptoStream cryptoStream = new CryptoStream((Stream) memoryStream, this.TripleDes.CreateDecryptor(), CryptoStreamMode.Write);
      cryptoStream.Write(buffer, 0, buffer.Length);
      cryptoStream.FlushFinalBlock();
      return Encoding.Unicode.GetString(memoryStream.ToArray());
    }
  }
}
