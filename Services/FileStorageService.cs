// Declare namespace for this class
namespace TodoList.Services;

// Declare required references
// System.Text.Json of file read/write
using System.Text.Json;

// TodoList.Models to reference the ToDoItem class
using TodoList.Models;

public class FileStorageService
{
    // Declare private variable
    private readonly string _filePath;

    public FileStorageService()
    {
        // Ensure the Data directory exists within the project root
        
        string dataDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
        //Create it if it doesn't exist
        Directory.CreateDirectory(dataDirectory);

        // Set the file path to the Data directory
        _filePath = Path.Combine(dataDirectory, "savedtodoitems.json");
    }

    // Get the current todos as an enumerable list from the json file.
    // Called when the ToDo.razor page is initialized
    public List<ToDoItem> LoadToDoItems()
    {
        // If the file exists
        if (!File.Exists(_filePath))
        {
            return new List<ToDoItem>();
        }

        // Read the file into a string variable
        string json = File.ReadAllText(_filePath);

        // Return the deserialized string to the ToDo.razor page as an enumerable list
        return JsonSerializer.Deserialize<List<ToDoItem>>(json) ?? new List<ToDoItem>();
    }

    // Called whenever the todos data is changed
    public void SaveToDoItems(List<ToDoItem> items)
    {
        string json = JsonSerializer.Serialize(items);
        File.WriteAllText(_filePath, json);
    }
}