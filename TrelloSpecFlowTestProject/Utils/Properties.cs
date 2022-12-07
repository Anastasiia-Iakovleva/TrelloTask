using System.Collections.Generic;

namespace TrelloSpecFlowTestProject.Utils;

/// <summary>
/// Test properties manager. 
/// </summary>
public class Properties
{
    private static readonly Dictionary<string, string> _propertiesDictionary = new();

    /// <summary>
    /// Try to get test property from storage.
    /// </summary>
    /// <param name="key"> Property name. </param>
    /// <returns> Property value (or null, if property not found). </returns>
    public static string GetProperty(string key)
    {
        return !_propertiesDictionary.TryGetValue(key, out var value) ? null : value;
    }

    /// <summary>
    /// Add property to storage.
    /// </summary>
    /// <param name="key"> Property name. </param>
    /// <param name="value"> Property value. </param>
    public static void AddProperty(string key, string value)
    {
        _propertiesDictionary[key] = value;
    }
}