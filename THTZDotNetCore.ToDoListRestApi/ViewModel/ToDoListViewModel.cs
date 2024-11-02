namespace THTZDotNetCore.ToDoListRestApi.ViewModel
{
    public class ToDoListViewModel
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; } = null!;
        public string? TaskDescription { get; set; }
        public int? TaskCategoryId { get; set; }
        public byte? PriorityLevel { get; set; }
        public string? Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public bool DeleteFlag { get; set; }

    }
}
