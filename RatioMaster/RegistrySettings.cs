using System;
using Microsoft.Win32;

namespace RatioMaster {
  // Values of the registry are read one by one: a value of a wrong type or a missing one gives the default and does not
  // stop the reading of the others.
  internal static class RegistrySettings {
    internal const string KeyPath = "Software\\RatioMaster";

    internal static string GetText(this RegistryKey key, string name, string defaultValue) {
      try {
        var value = key.GetValue(name);
        return value == null ? defaultValue : Convert.ToString(value);
      }
      catch (Exception) {
        return defaultValue;
      }
    }

    internal static bool GetFlag(this RegistryKey key, string name, bool defaultValue) {
      try {
        var value = key.GetValue(name);
        if (value == null) return defaultValue;
        if (value is int number) return number != 0;
        var text = Convert.ToString(value);
        if (bool.TryParse(text, out var flag)) return flag;
        return int.TryParse(text, out number) ? number != 0 : defaultValue;
      }
      catch (Exception) {
        return defaultValue;
      }
    }
  }
}
