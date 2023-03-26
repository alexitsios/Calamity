//Author : https://github.com/seekeroftheball   https://gist.github.com/seekeroftheball
//Version : 1.0
//Updated : March 2023

using UnityEngine;

namespace Seeker.StringMarkupEncapsulation
{
    /// <summary>
    /// String encapsulation for rich text formatting.
    /// </summary>
    public struct StringFormatter
    {
        /// <summary>
        /// Encapsulate strings with markup tags.
        /// </summary>
        /// <param name="inputString">String to encapsulate.</param>
        /// <param name="markupFormat">Format of the markup tag (without braces). Examples: b, i, size</param>
        /// <param name="markupValue">The value to set the markup tag. Example: "Hello World", "size", "12"</param>
        /// <returns>Formatted markup string.</returns>
        public static string FormatStringWithMarkupTag(string inputString, string markupFormat, string markupValue = "")
        {
            string formattedString = $"<{markupFormat}";

            if (!markupValue.Equals(string.Empty))
                formattedString += $"={markupValue}";

            formattedString += $"> {inputString} </{markupFormat}>";
            return formattedString;
        }

        /// <summary>
        /// Overload method for encapsulating string with color markup tag for RGBA colors.
        /// </summary>
        /// <param name="inputString">String to encapsulate.</param>
        /// <param name="rgbaColor">RGBA Color.</param>
        /// <returns>Formatted markup string.</returns>
        public static string FormatStringWithMarkupTag(string inputString, Color rgbaColor)
        {
            string formattedString = $"<color";
            formattedString += "#" + ColorUtility.ToHtmlStringRGBA(rgbaColor);

            formattedString += $"> {inputString} </color>";
            return formattedString;
        }
    }
}