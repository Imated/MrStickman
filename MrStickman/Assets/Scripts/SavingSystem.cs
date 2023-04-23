using System;
using System.IO;
using UnityEngine;

public static class SavingSystem
{
    public static string FileName = "Game.dat";
    private static string FileLocation => Path.Combine(Application.persistentDataPath, FileName);

    public static int GetInt(string key, int defaultValue = 0)
    {
        key += "_i32:";
        if (!File.Exists(FileLocation))
            return defaultValue;
        try
        {
            using var sr = new StreamReader(FileLocation);
            var data = sr.ReadToEnd();
            data = EncryptDecrypt(data);
            var subStrings = data.Split(Environment.NewLine);

            foreach (var s in subStrings)
            {
                if (s.Contains(key))
                {
                    var start = s.IndexOf(key, StringComparison.Ordinal);
                    var currentPos = start + key.Length + 1;
                    var result = s.Substring(currentPos);
                    var resultAsInt = int.Parse(result);
                    return resultAsInt;
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogWarning(e.Message);
        }

        return defaultValue;
    }
    public static void SetInt(string key, int value)
    {
        key += "_i32:";
        if (!File.Exists(FileLocation))
        {
            var sw = File.CreateText(FileLocation);
            sw.Write(EncryptDecrypt(key + " " + value));
            sw.Flush();
            sw.Close();
        }
        else
        {
            var sr = File.OpenText(FileLocation);

            var data = sr.ReadToEnd();
            data = EncryptDecrypt(data);
            sr.Close();
            
            if(data.Contains(key))
            {
                var substrings = data.Split(Environment.NewLine);
                for (var i = 0; i < substrings.Length; i++)
                {
                    if (substrings[i].Contains(key))
                        substrings[i] = key + " " + value;
                }
                data = string.Join(Environment.NewLine, substrings);
            }
            else
                data += Environment.NewLine + key + " " + value;

            data = EncryptDecrypt(data);
            var sw = new StreamWriter(FileLocation);
            sw.Write(data);
            sw.Flush();
            sw.Close();
        }
    }
    public static float GetFloat(string key, float defaultValue = 0.0f)
    {
        key += "_f32:";

        if (!File.Exists(FileLocation))
            return defaultValue;
        try
        {
            using var sr = new StreamReader(FileLocation);
            var data = sr.ReadToEnd();
            data = EncryptDecrypt(data);
            var subStrings = data.Split(Environment.NewLine);

            foreach (var s in subStrings)
            {
                if (s.Contains(key))
                {
                    var start = s.IndexOf(key, StringComparison.Ordinal);
                    var currentPos = start + key.Length + 1;
                    var result = s.Substring(currentPos);
                    var resultAsFloat = float.Parse(result);
                    return resultAsFloat;
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogWarning(e.Message);
        }

        return defaultValue;
    }
    public static void SetFloat(string key, float value)
    {
        key += "_f32:";

        if (!File.Exists(FileLocation))
        {
            var sw = File.CreateText(FileLocation);
            sw.Write(EncryptDecrypt(key + " " + value));
            sw.Flush();
            sw.Close();
        }
        else
        {
            var sr = File.OpenText(FileLocation);

            var data = sr.ReadToEnd();
            data = EncryptDecrypt(data);
            sr.Close();

            if (data.Contains(key))
            {
                var subStrings = data.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                for (var i = 0; i < subStrings.Length; i++)
                {
                    if (subStrings[i].Contains(key))
                        subStrings[i] = key + " " + value;
                }
                data = string.Join(Environment.NewLine, subStrings);
            }
            else
                data += Environment.NewLine + key + " " + value;

            data = EncryptDecrypt(data);
            var sw = new StreamWriter(FileLocation);
            sw.Write(data);
            sw.Flush();
            sw.Close();
        }
    }
    public static string GetString(string key, string defaultValue = "undefined")
    {
        key += "_str:";
        if (!File.Exists(FileLocation))
            return defaultValue;
        try
        {
            using var sr = new StreamReader(FileLocation);
            var data = sr.ReadToEnd();
            data = EncryptDecrypt(data);
            var subStrings = data.Split(Environment.NewLine);

            foreach (var s in subStrings)
            {
                if (s.Contains(key))
                {
                    var start = s.IndexOf(key, StringComparison.Ordinal);
                    var currentPos = start + key.Length + 1;
                    var result = s.Substring(currentPos, (s.Length - key.Length - 1));
                    return result;
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogWarning(e.Message);
        }

        return defaultValue;
    }
    public static void SetString(string key, string value)
    {
        key += "_str:";
        if (!File.Exists(FileLocation))
        {
            var sw = File.CreateText(FileLocation);
            sw.Write(EncryptDecrypt(key + " " + value));
            sw.Flush();
            sw.Close();
        }
        else
        {
            var sr = File.OpenText(FileLocation);

            var data = sr.ReadToEnd();
            data = EncryptDecrypt(data);
            sr.Close();

            if (data.Contains(key))
            {
                var subStrings = data.Split(Environment.NewLine);
                for (var i = 0; i < subStrings.Length; i++)
                {
                    if (subStrings[i].Contains(key))
                        subStrings[i] = key + " " + value;
                }
                data = string.Join(Environment.NewLine, subStrings);
            }
            else
                data += Environment.NewLine + key + " " + value;

            data = EncryptDecrypt(data);
            var sw = new StreamWriter(FileLocation);
            sw.Write(data);
            sw.Flush();
            sw.Close();
        }
    }
    public static bool GetBool(string key, bool defaultValue = false)
    {
        key += "_boolean:";
        if (!File.Exists(FileLocation))
            return defaultValue;
        try
        {
            using var sr = new StreamReader(FileLocation);
            var data = sr.ReadToEnd();
            data = EncryptDecrypt(data);
            var subStrings = data.Split(Environment.NewLine);

            foreach (var s in subStrings)
            {
                if (s.Contains(key))
                {
                    var start = s.IndexOf(key, StringComparison.Ordinal);
                    var currentPos = start + key.Length + 1;
                    var result = s.Substring(currentPos);
                    return result == "True";
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogWarning(e.Message);
        }

        return defaultValue;
    }
    public static void SetBool(string key, bool value)
    {
        key += "_boolean:";
        if (!File.Exists(FileLocation))
        {
            var sw = File.CreateText(FileLocation);
            sw.Write(EncryptDecrypt(key + " " + value));
            sw.Flush();
            sw.Close();
        }
        else
        {
            var sr = File.OpenText(FileLocation);

            var data = sr.ReadToEnd();
            data = EncryptDecrypt(data);
            sr.Close();

            if (data.Contains(key))
            {
                var subStrings = data.Split(Environment.NewLine);
                for (var i = 0; i < subStrings.Length; i++)
                {
                    if (subStrings[i].Contains(key))
                        subStrings[i] = key + " " + value;
                }
                data = string.Join(Environment.NewLine, subStrings);
            }
            else
                data += Environment.NewLine + key + " " + value;

            data = EncryptDecrypt(data);
            var sw = new StreamWriter(FileLocation);
            sw.Write(data);
            sw.Flush();
            sw.Close();
        }
    }
    
    public static string EncryptDecrypt(string data)
    {
        var result = "";
        const string key = "Rgp3bFASkLgWcSO9DcZ8KM";
        for (var i = 0; i < data.Length; i++)
            result += (char) (data[i] ^ key[i % key.Length]);
        return result;
    }
    
    public static void ClearSave()
    {
        File.Delete(FileLocation);
    }
}
