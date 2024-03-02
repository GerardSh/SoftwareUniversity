string input = Console.ReadLine();

int fileNameIndex = input.LastIndexOf('\\');
int fileExtensionIndex = input.IndexOf('.');

string fileExtension = input.Substring(fileExtensionIndex + 1, input.Length - (fileExtensionIndex + 1));
string fileName = input.Substring(fileNameIndex + 1, input.Length - (fileNameIndex + 1) - (fileExtension.Length + 1));

Console.WriteLine($"File name: {fileName}");
Console.WriteLine($"File extension: {fileExtension}");




//2
string[] input = Console.ReadLine().Split(new char[] { '\\', '.' });

string fileExtension = input[input.Length - 1];
string fileName = input[input.Length - 2];

Console.WriteLine($"File name: {fileName}");
Console.WriteLine($"File extension: {fileExtension}");




//3
string input = Console.ReadLine();
string[] fileNameWithExtensionName = input.Substring(input.LastIndexOf('\\') + 1).Split('.');

string fileExtension = fileNameWithExtensionName[1];
string fileName = fileNameWithExtensionName[0];

Console.WriteLine($"File name: {fileName}");
Console.WriteLine($"File extension: {fileExtension}");




//4
string[] directory = Console.ReadLine().Split('\\');

string fileNameWithExtension = directory[directory.Length - 1];
int extensionIndex = fileNameWithExtension.LastIndexOf('.');

string fileName = fileNameWithExtension.Remove(extensionIndex);
string fileExtension = fileNameWithExtension.Substring(extensionIndex + 1);

Console.WriteLine($"File name: {fileName}");
Console.WriteLine($"File extension: {fileExtension}");