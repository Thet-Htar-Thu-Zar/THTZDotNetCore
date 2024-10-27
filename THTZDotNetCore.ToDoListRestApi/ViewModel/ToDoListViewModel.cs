namespace THTZDotNetCore.ToDoListRestApi.ViewModel
{
    public class ToDoListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Descritpion { get; set; }
        public int? TaskCategoryId { get; set; }
        public byte? PriorityLevel { get; set; }
        public string? Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? CompletedDate { get; set; }
    }
}
