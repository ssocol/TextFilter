# **Text Filter Service**

This project is a C# console application that applies a series of text filters to input text from a file. It is designed following clean code practices, **OOP**, **SOLID principles**, and uses **Dependency Injection**.

---

## **Features**

- Reads input text from a file.
- Applies multiple filters to remove words based on specific rules:
  - **Middle Vowel Filter**: Removes words with vowels in the middle characters.
  - **Length Filter**: Removes words with lengths less than 3.
  - **Letter Filter**: Removes words containing a specific letter.
- Outputs the filtered text to the console.

---

## **Prerequisites**

- **.NET 8 SDK**: Ensure that the .NET 8 SDK is installed. 
- **IDE**: Visual Studio, VS Code, or any other C# compatible editor.

---

## **Build and Run**

Follow these steps to build and run the application:

1. Clone the Repository
2. Go to the main project directory cd .\TextFilter.Console\
3. Run the following command: dotnet build
4. The project can be run pressing F5, i also pushed the vscode config files.

---

## **Run Tests**
To execute the unit tests:

1. Navigate to the test project directory: cd .\TextFilter.Tests
2. Run all tests using the following command: dotnet test

---

## **Design Decisions**
1. Dependency Injection
	The project uses Dependency Injection (DI) to manage dependencies such as the FileReader and TextFilterService.
	DI ensures that the application is decoupled, testable, and easily extendable.
2. Strategy Pattern
	A design pattern similar to the Strategy Pattern has been used for implementing the filters.
	The TextFilterService accepts multiple filters (IFilter implementations) and applies them sequentially.
	Each filter (MiddleVowelFilter, LengthFilter, LetterFilter) encapsulates a specific filtering strategy, adhering to the Open/Closed Principle.
3. SOLID Principles
	Single Responsibility Principle:
	Each class has a single responsibility.

	FileReader: Reads the file content.
	TextFilterService: Applies filters to the text, this class is also responsible of splitting the text once to improve performance
	Each filter class processes text in its own way.

	Open/Closed Principle:
	Adding new filters does not require modifying the TextFilterService—you simply create a new IFilter implementation.

	Dependency Inversion Principle:
	The TextFilterService depends on abstractions (IFilter, IFileReader) rather than concrete classes.

4. Static Global Class
	A Global static class is used to store configurable constants (like file paths, default letter for filters, etc.).
	Why this approach?
	A Task.Def file or a JSON configuration file can be added later, and the Global class can map these values dynamically based on the environment.
	For more secure and environment-specific configurations, a Secrets Manager (like AWS Secrets Manager) can be used.
5. Asynchronous File Reading
	I am aware that file I/O operations should ideally be asynchronous to avoid blocking threads.
	Due to time constraints, the FileReader currently uses synchronous methods.
	The file reading can be easily updated to ReadAsync() to improve performance and prevent locks.

---

## **Future Improvements**
Implement asynchronous file reading using StreamReader.ReadToEndAsync().
Add support for configuration files to extend the static Global class.