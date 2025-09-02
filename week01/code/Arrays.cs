public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    /// 
    /// My first idea is to create a fixed array of the given length.
    /// Then I will use a for loop to iterate through the array.
    /// In each iteration, I will calculate the multiple by multiplying the number by (i + 1) where i is the current index.
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.
        number = Math.Round(number, 2);
        double[] multiples = new double[length];    
        for (int i = 0; i < length; i++)
        {
            multiples[i] = Math.Round(number * (i + 1), 2);
        }
        return multiples

        ; // replace this return statement with your own
    }


    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    /// 
    /// My first idea is to use a loop to perform the rotation 'amount' times.
    /// In each iteration, I will remove the first element of the list and add it to the end of the list.
    /// This will effectively rotate the list to the right by one position in each iteration.
    /// After completing the loop for the specified 'amount', the list will be rotated as required.
    /// Amount will be used as one less than the actual amount to account for zero indexing.
    /// </summary>
    /// <param name="data">the list to be rotated</param>
    /// <param name="amount">the amount to rotate the list</param>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.
        List<int> tail = data.GetRange(data.Count - amount, amount); // Get the last 'amount' elements
        data.RemoveRange(data.Count - amount, amount); // Remove the last 'amount' elements from the original list
        data.InsertRange(0, tail); // Insert the removed elements at the beginning of the list

    }
}
