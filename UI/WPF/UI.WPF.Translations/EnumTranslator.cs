using System;
using Fateblade.Components.Logic.Foundation.Translation.Contract;

namespace Alexandria.UI.WPF.Modules.CommonTranslations
{
    /// <summary>
    /// Translates any Enum using EnumName.EnumValue as key
    /// Flag combined enums cannot be translated using this translator
    /// </summary>
    internal class EnumTranslator : IEnumTranslator
    {
        private readonly ITranslationStringProvider _stringProvider;

        public EnumTranslator(ITranslationStringProvider stringProvider)
        {
            _stringProvider = stringProvider;
        }

        public string Translate<TEnum>(TEnum toTranslate) where TEnum : Enum
        {
            return _stringProvider.GetString($"{typeof(TEnum).Name}.{toTranslate}");
        }
    }

}
