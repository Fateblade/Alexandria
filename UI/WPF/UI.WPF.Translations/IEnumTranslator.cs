using System;

namespace Alexandria.UI.WPF.Modules.CommonTranslations
{
    //TODO: Spezieller FlaggableEnumTranslator für kombinationen der auf struct ebene absichert und innerhalb nochmal auf basetype enum prüft

    /// <summary>
    /// Translates any Enum using EnumName.EnumValue as key
    /// Flag combined enums cannot be translated using this translator
    /// </summary>
    public interface IEnumTranslator 
    {
        string Translate<TEnum>(TEnum toTranslate) where TEnum : Enum;
    }
}