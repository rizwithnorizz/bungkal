using System;
using System.Collections.Generic;
using System.IO;

public class EnvLoader
{
    private static Dictionary<string, string> envVariables = new Dictionary<string, string>();

    // Reads the .env file and loads variables into a dictionary
    public static void LoadEnv(string filePath)
    {
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException(".env file not found at: " + filePath);
        }

        string[] lines = File.ReadAllLines(filePath);
        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#"))
                continue; // Skip empty lines and comments

            string[] parts = line.Split('=', 2); // Split at the first '='
            if (parts.Length == 2)
            {
                string key = parts[0].Trim();
                string value = parts[1].Trim();
                envVariables[key] = value; // Add to dictionary
            }
        }
    }

    // Retrieves the value of an environment variable
    public static string GetEnv(string key)
    {
        return envVariables.ContainsKey(key) ? envVariables[key] : null;
    }
}