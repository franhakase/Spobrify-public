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
        public static string JsFunctionPattern1 { get; set; } = "(?<sig>[a-zA-Z0-9$]{3})\\s*=\\s*function\\(\\s*a\\s*\\)\\s*{\\s*a\\s*=\\s*a\\.split\\(\\s*\"\"\\s*\\).*};";
        public static string JsFunctionPattern2 { get; set; } = @"=function\(([a-zA-Z]+?)\)\{(.+?)\};";
        public static string JsFunctionPattern3 { get; set; } = @"=\{(.+?)\};";
        public static string YtInitialData { get; set; } = @"(?<=ytInitialData = )(.*?)(?=;)";
        public static string VideoRendererBlock { get; set; } = @"(\{""videoRenderer"":)(.*?)(?=,\{""videoRenderer"":)";
        public static string VideoName { get; set; } = @"(?<=""text"":"")(.*?)(?=""\}\])";
        public static string VideoID { get; set; } = @"(?<=\{""videoId"":"")(.*?)(?="")";
        public static string VideoViewCount { get; set; } = @"(?<=""viewCountText"":\{""simpleText"":"")(.*?)(?="")";
        public static string PlaylistRenderer { get; set; } = @"(\{""playlistRenderer"":)(.*?)(?=,\{""playlistRenderer"":)";
        public static string PlaylistName { get; set; } = @"(?<=""simpleText"":"")(.*?)(?=""\},)";
        public static string PlaylistVideoCount { get; set; } = @"(?<=""videoCount"":"")(.*?)(?="")";
        public static string PlaylistID { get; set; } = @"(?<=""playlistId"":"")(.*?)(?="")";
        public static string YoutubeInitialResponse { get; set; } = "(?<=ytInitialPlayerResponse\\s*=)\\s*({.+?})\\s*(?=;)";
    }
}
