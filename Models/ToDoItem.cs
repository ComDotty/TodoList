// Declare namespace for this class
namespace TodoList.Models;

public class ToDoItem
{
    // Title string for the todo
    public string? Title { get; set; }

    // Boolean flag indicating the todo has been completed
    public bool IsDone { get; set; }

    // Boolean flag indicating the todo is being edited
    public bool IsEditing { get; set; }
}