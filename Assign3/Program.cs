
double minValue = 0;
double maxValue = 100;
int physicalSize = 31;
int logicalSize = 0;


double[] values = new double[physicalSize];
string[] dates = new string[physicalSize];

bool loopAgain = true;
  while (loopAgain)
  {
    try
    {
      DisplayMainMenu();
      string mainMenuChoice = Prompt("\nEnter a Main Menu Choice: ").ToUpper();
      if (mainMenuChoice == "L")
        logicalSize = LoadFileValuesToMemory(dates, values);
      if (mainMenuChoice == "S")
        SaveMemoryValuesToFile(dates, values, logicalSize);
      if (mainMenuChoice == "D")
        DisplayMemoryValues(dates, values, logicalSize);
      if (mainMenuChoice == "A")
        logicalSize = AddMemoryValues(dates, values, logicalSize);
      if (mainMenuChoice == "E")
        EditMemoryValues(dates, values, logicalSize);
      if (mainMenuChoice == "Q")
      {
        loopAgain = false;
        throw new Exception("Bye, hope to see you again.");
      }
      if (mainMenuChoice == "R")
      {
        while (true)
        {
          if (logicalSize == 0)
					  throw new Exception("No entries loaded. Please load a file into memory");
          DisplayAnalysisMenu();
          string analysisMenuChoice = Prompt("\nEnter an Analysis Menu Choice: ").ToUpper();
          if (analysisMenuChoice == "A")
            FindAverageOfValuesInMemory(values, logicalSize);
          if (analysisMenuChoice == "H")
            FindHighestValueInMemory(values, logicalSize);
          if (analysisMenuChoice == "L")
            FindLowestValueInMemory(values, logicalSize);
          if (analysisMenuChoice == "G")
            GraphValuesInMemory(dates, values, logicalSize);
          if (analysisMenuChoice == "R")
            throw new Exception("Returning to Main Menu");
        }
      }
    }
    catch (Exception ex)
    {
      Console.WriteLine($"{ex.Message}");
    }
  }

void DisplayMainMenu()
{
	Console.WriteLine("\nMain Menu");
	Console.WriteLine("L) Load Values from File to Memory");
	Console.WriteLine("S) Save Values from Memory to File");
	Console.WriteLine("D) Display Values in Memory");
	Console.WriteLine("A) Add Value in Memory");
	Console.WriteLine("E) Edit Value in Memory");
	Console.WriteLine("R) Analysis Menu");
	Console.WriteLine("Q) Quit");
}

void DisplayAnalysisMenu()
{
	Console.WriteLine("\nAnalysis Menu");
	Console.WriteLine("A) Find Average of Values in Memory");
	Console.WriteLine("H) Find Highest Value in Memory");
	Console.WriteLine("L) Find Lowest Value in Memory");
	Console.WriteLine("G) Graph Values in Memory");
	Console.WriteLine("R) Return to Main Menu");
}

string Prompt(string prompt)
{
  bool invalidInput = true;
  string myString = "";
  while (invalidInput)
{
	try
	{
	Console.Write(prompt)
	myString = Console.ReadLine().Trim();
	if(string.IsNullOrEmpty(myString))
		  throw new Exception($"Empty Input: Please enter something.");
    inValidInput = false;    	
    }
	catch (Exception ex)
	{
		Console.WriteLine(ex.Message);
	}
}
return myString;
}

int LoadFileValuesToMemory(string[] dates, double[] values)
{
	string filePath = $"./data/{fileName}";
	if (!File.Exists(filePath))
		throw new Exception($"The file {fileName} does not exist.");
	string[] csvFileInput = File.ReadAllLines(filePath);
	for(int i = 0; i < csvFileInput.Length; i++)
	{
		string[] items = csvFileInput[i].Split(',');
		for(int j = 0; j < items.Length; j++)
		{
			Console.WriteLine($"itemIndex: {j}; item: {items[j]}");
		}
		if(i != 0)
		{
	dates[logicalSize] = items[0];
    values[logicalSize] = double.Parse(items[1]);
    logicalSize++;
		}
	}
  Console.WriteLine($"Load complete. {fileName} has {logicalSize} data entries");
	return logicalSize;
}

void DisplayMemoryValues(string[] dates, double[] values, int logicalSize)
{
	if(logicalSize == 0)
		throw new Exception($"No Entries loaded. Please load a file to memory or add a value in memory");
	Array.Sort(dates, values, 0, logicalSize)
	Console.WriteLine($"\nCurrent Loaded Entries: {logicalSize}");
	Console.WriteLine($"   Date     Value");
	for (int i = 0; i < logicalSize; i++)
		Console.WriteLine($"{dates[i]}   {values[i]}");
}
double PromptDoulbeBetweenMinMax(string prompt, double min, double, max)
{
	bool inValidInput = true;
	double num = 0;
	while(inValidInput)
	{
		try
		{
			Console.Write($"{prompt} between {min:n2} and {max:n2}: ");
			num = double.Parse(Console.ReadLine());
			if (num < min || num > max)
			  throw new Exception($"Invalid. Must be between {min} and {max}. ");
			inValidInput = false;
		}
		catch (Exception ex)
		{
			Console.WriteLine($"{ex.Message}");
		}
	}
	return num;
}

string PromptDate(string prompt)
{
	bool inValidInput = true;
	DateTime date = DateTime.Today;
	Console.WriteLine(date);
	while (inValidInput)
	{
		try
		{
			Console.Write(prompt);
			date = DateTime.Parse(Console.ReadLine());
			Console.WriteLine(date);
			inValidInput = false;
		}
		catch (Exception ex)
		{
			Console.WriteLine($"{ex.Message}");
		}
	}
	return date.ToString("mm-dd-yyyy");
}
double FindHighestValueInMemory(double[] values, int logicalSize)
{
	double highestValue = values[0];
	if (logicalSize == 0)
	  throw new Exception("No entries loaded. Please load a file into memory or add a value to memory.");
	for (int i = 1; i < logicalSize; i++)
	{
		if (values[i] > highestValue)
		{
			highestValue = values[i];
		}
	}  
	Console.WriteLine($"Highest value in memory: {highestValue} ");
	return highestValue;
}

double FindLowestValueInMemory(double[] values, int logicalSize)
{
	double lowestValue = values[0];
	if (logicalSize == 0)
	{
		throw new Exception("No entries loaded. Please load a file into memory or add a value to memory.");
	}
	for (int i = 1; i < logicalSize; i++)
	{
		if (values[i] < lowestValue)
		{
			lowestValue = values[i];
		}
	}
	Console.WriteLine($"Lowest value in memory: {lowestValue}");
	return lowestValue;
}

void FindAverageOfValuesInMemory(double[] values, int logicalSize)
{
	double sum = 0
	if (logicalSize == 0)
	{
		throw new Exception("No entries loaded. Please load a file into memory or add a value to memory.");
	}
	for (int i = 0; i < logicalSize; i++)
	{
		sum += values[i];
	}
	double average = sum / logicalSize;
	Console.WriteLine($"Average of values in memory: {average}");

}

void SaveMemoryValuesToFile(string[] dates, double[] values, int logicalSize)
{
	Console.WriteLine("Not Implemented Yet");
	//TODO: Replace this code with yours to implement this function.
}

int AddMemoryValues(string[] dates, double[] values, int logicalSize)
{
	double value = 0.0;
	string dateString = "";

	dateString = PromptDate("Enter date format mm-dd-yyyy (eg 11-23-2023): ");
	bool found = false;
	for (int i = 0; i < logicalSize; i++)
	  if (dates[i].Equals(dateString))
	    found = true;
	if(found == true)
	  throw new Exception($"{dateString} is already in memory. Edit entry instead.");
	value = PromptDoulbeBetweenMinMax($"Enter a double value", minValue, maxValue);
	dates[logicalSize] = dateString;
	values[logicalSize] = value;
	logicalSize++;
	return logicalSize;
}

void EditMemoryValues(string[] dates, double[] values, int logicalSize)
{
	double value = 0.0
	string dateString = "";
	int foundIndex = 0;

	if(logicalSize == 0)
	  throw new Exception($"No Entries loaded. Please load a file to memory or add a value in memory.");
	dateString = PromptDate("enter date format mm-dd-yyyy (eg 11-23-2023):");
	bool found = false;
	for (int i = 0; i < logicalSize; i++)
	  if (dates[i].Equals(dateString))
	  {
		found = true;
		foundIndex = i;
	  }
	if(found == false)
	  throw new Exception($"{dateString} is not in memory. Add entry instead.");
	value = PromptDoulbeBetweenMinMax($"Enter a double value", minValue, maxValue);
	value[foundIndex] = value;
}

void GraphValuesInMemory(string[] dates, double[] values, int logicalSize)
{
	Console.WriteLine("Not Implemented Yet");
	//TODO: Replace this code with yours to implement this function.
}