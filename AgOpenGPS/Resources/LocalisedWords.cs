using System.Globalization;
using WPFLocalizeExtension.Engine;

namespace AgOpenGPS.Resources
{
    public class LocalisedWords
    {
        public static LocalisedWords Instance { get; } = new LocalisedWords();

        public void setCulture(string cultureCode)
        {
            var culture = new CultureInfo(cultureCode);
            LocalizeDictionary.Instance.Culture = culture;
        }

        public string this[string key]
        {
            get
            {
                var result = LocalizeDictionary.Instance.GetLocalizedObject("AgOpenGPS", "Lang", key, LocalizeDictionary.Instance.Culture);
                return result as string;
            }
        }

    }

}
