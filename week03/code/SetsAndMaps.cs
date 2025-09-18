using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    ///
    /// For example, if words was: [am, at, ma, if, fi], we would return :
    ///
    /// ["am & ma", "if & fi"]
    ///
    /// The order of the array does not matter, nor does the order of the specific words in each string in the array.
    /// at would not be returned because ta is not in the list of words.
    ///
    /// As a special case, if the letters are the same (example: 'aa') then
    /// it would not match anything else (remember the assumption above
    /// that there were no duplicates) and therefore should not be returned.
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
    public static string[] FindPairs(string[] pairs)
    {
        // Use a HashSet for O(1) lookups of each pair
        var pairSet = new HashSet<string>(pairs);

        // Store the final result strings
        var result = new List<string>();

        // Iterate through each pair in the input
        foreach (var pair in pairs)
        {
            // Reverse the characters in the current pair
            var reversed = new string(new[] { pair[1], pair[0] });

            // Check if the reversed pair exists and it's not a palindrome (e.g., "aa")
            if (pairSet.Contains(reversed) && pair[0] != pair[1])
            {
                // Format the pair consistently to avoid duplicates like "ab & ba" and "ba & ab"
                var formatted = pair.CompareTo(reversed) < 0 ? $"{pair} & {reversed}" : $"{reversed} & {pair}";

                // Add to result only if not already present
                if (!result.Contains(formatted))
                {
                    result.Add(formatted);
                }
            }
        }

        // Return the result as an array
        return result.ToArray();
    }


    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.  The summary
    /// should be stored in a dictionary where the key is the
    /// degree earned and the value is the number of people that 
    /// have earned that degree.  The degree information is in
    /// the 4th column of the file.  There is no header row in the
    /// file.
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>fixed array of divisors</returns>
    public static Dictionary<string, int> SummarizeDegrees(string path)
    {
        // Dictionary to store counts of each education level
        var eduCounts = new Dictionary<string, int>();

        // Read each line from the census file
        foreach (var line in File.ReadLines(path))
        {
            // Extract the education level from the 4th column (index 3)
            var edLevel = line.Split(',')[3].Trim();

            // Increment count for this education level
            if (eduCounts.ContainsKey(edLevel))
            {
                eduCounts[edLevel]++;
            }
            else
            {
                eduCounts[edLevel] = 1;
            }
        }

        return eduCounts;
    }


    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.  An anagram
    /// is when the same letters in a word are re-organized into a 
    /// new word.  A dictionary is used to solve the problem.
    /// 
    /// Examples:
    /// is_anagram("CAT","ACT") would return true
    /// is_anagram("DOG","GOOD") would return false because GOOD has 2 O's
    /// 
    /// Important Note: When determining if two words are anagrams, you
    /// should ignore any spaces.  You should also ignore cases.  For 
    /// example, 'Ab' and 'Ba' should be considered anagrams
    /// 
    /// Reminder: You can access a letter by index in a string by 
    /// using the [] notation.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        // Normalize both words: remove spaces and convert to lowercase
        var normalizedWord1 = word1.Replace(" ", "").ToLower();
        var normalizedWord2 = word2.Replace(" ", "").ToLower();
        // If lengths differ, they cannot be anagrams
        if (normalizedWord1.Length != normalizedWord2.Length)
        {
            return false;
        }
        // Dictionary to count occurrences of each letter in word1
        var letterCounts = new Dictionary<char, int>();
        foreach (var letter in normalizedWord1)
        {
            if (letterCounts.ContainsKey(letter))
            {
                letterCounts[letter]++;
            }
            else
            {
                letterCounts[letter] = 1;
            }
        }
        // Decrease counts based on letters in word2
        foreach (var letter in normalizedWord2)
        {
            if (letterCounts.ContainsKey(letter))
            {
                letterCounts[letter]--;
                // If count goes negative, word2 has extra letters not in word1
                if (letterCounts[letter] < 0)
                {
                    return false;
                }
            }
            else
            {
                // Letter in word2 not found in word1
                return false;
            }
        }
        // If all counts are zero, they are anagrams
        foreach (var count in letterCounts.Values)
        {
            if (count != 0)
            {
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// The data will include all earthquakes in the current day.
    /// 
    /// JSON data is organized into a dictionary. After reading the data using
    /// the built-in HTTP client library, this function will return a list of all
    /// earthquake locations ('place' attribute) and magnitudes ('mag' attribute).
    /// Additional information about the format of the JSON data can be found 
    /// at this website:  
    /// 
    /// https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
    /// 
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        // TODO Problem 5:
        // 1. Add code in FeatureCollection.cs to describe the JSON using classes and properties 
        // on those classes so that the call to Deserialize above works properly.
        // 2. Add code below to create a string out each place a earthquake has happened today and its magitude.
        // 3. Return an array of these string descriptions.
        return [];
    }
}