﻿namespace MooVC.Serialization
{
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;
    using static System.String;

    public static partial class SerializationInfoExtensions
    {
        public static string TryGetInternalString(this SerializationInfo info, string name)
        {
            return info.TryGetInternalString(name, Empty);
        }

        [return: NotNullIfNotNull("defaultValue")]
        public static string? TryGetInternalString(this SerializationInfo info, string name, string? defaultValue)
        {
            return info.TryGetString(FormatName(name), defaultValue: defaultValue);
        }
    }
}