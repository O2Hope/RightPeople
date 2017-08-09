// Helpers/Settings.cs
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace RightPeople.Helpers
{
  /// <summary>
  /// This is the Settings static class that can be used in your Core solution or in any
  /// of your client applications. All settings are laid out the same exact way with getters
  /// and setters. 
  /// </summary>
  public static class Settings
  {
    private static ISettings AppSettings
    {
      get
      {
        return CrossSettings.Current;
      }
    }

        #region Setting Constants

        private const string UserNameKey = "username_key";
        private static readonly string UserNameDefault = string.Empty;

        private const string SomeIntKey = "int_key";
        private static readonly int SomeIntDefault = 0;

        private const string SomeIntId = "int_id";
        private static readonly string IdDefault = string.Empty;

        #endregion


        public static string UserName
        {
            get { return AppSettings.GetValueOrDefault<string>(UserNameKey, UserNameDefault); }
            set { AppSettings.AddOrUpdateValue<string>(UserNameKey, value); }
        }

        public static int SomeInt
        {
            get { return AppSettings.GetValueOrDefault<int>(SomeIntKey, SomeIntDefault); }
            set { AppSettings.AddOrUpdateValue<int>(SomeIntKey, value); }
        }

        public static string ID
        {
            get { return AppSettings.GetValueOrDefault<string>(SomeIntId, IdDefault); }
            set { AppSettings.AddOrUpdateValue<string>(SomeIntId, value); }
        }
    }
}