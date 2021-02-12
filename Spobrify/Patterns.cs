using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spobrify
{
    public static class Patterns
    {
        public static string AdaptiveFormats1 { get; set; } = @"(?<=""adaptiveFormats"":)(.*?)(?=\])";
        public static string AdaptiveFormats2 { get; set; } = @"(?<=\{"")(.*?)(?=},\{)";
        public static string SignatureCipher { get; set; } = @"(?<=""signatureCipher"":"")(.*?)(?="")";
        public static string FileURL { get; set; } = @"(?<=""url"":"")(.*?)(?="")";
        public static string JsURL { get; set; } = @"(?<=""jsUrl"":"")(.*?)(?="",)";
        public static string JsFunctionPattern1 { get; set; } = @"(?<sig>[a-zA-Z0-9$]{2})\s*=\s*function\(\s*a\s*\)\s*{\s*a\s*=\s*a\.split\(\s*""""\s*\).*};";
        public static string JsFunctionPattern2 { get; set; } = @"=function\(([a-zA-Z]+?)\)\{(.+?)\};";
        public static string JsFunctionPattern3 { get; set; } = @"=\{(.+?)\};";
    }
}
