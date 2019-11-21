using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace Pensees.CargoX.Localization
{
    public static class CargoXLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(CargoXConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(CargoXLocalizationConfigurer).GetAssembly(),
                        "Pensees.CargoX.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
