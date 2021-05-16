using System;
using System.Collections.Generic;
using System.Reflection;

public class Example
{
    public string ID;
}

public class ExampleFactory
{
    private static Dictionary<string, Type> _examplesbyID;
    private static bool IsInitialized => _examplesbyID != null;

    public static void Initialize()
    {
        if (IsInitialized) return;

        var examples = Assembly.GetAssembly(typeof(Example)).GetTypes();

        _examplesbyID = new Dictionary<string, Type>();

        foreach (var type in examples)
        {
            var temp = Activator.CreateInstance(type) as Example;
            _examplesbyID.Add(temp.ID, type);
        }
    }

    public static Example Instantiate(string exampleID)
    {
        Initialize();

        if (!_examplesbyID.ContainsKey(exampleID))
            return null;

        return Activator.CreateInstance(_examplesbyID[exampleID]) as Example;
    }

    public static IEnumerable<string> GetAllExampleNames()
    {
        Initialize();
        return _examplesbyID.Keys;
    }

    public static IEnumerable<Type> GetAllExamples()
    {
        Initialize();
        return _examplesbyID.Values;
    }
}
