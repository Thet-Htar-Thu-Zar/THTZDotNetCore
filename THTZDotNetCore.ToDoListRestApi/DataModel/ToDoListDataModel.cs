namespace THTZDotNetCore.ToDoListRestApi.DataModel
{
    public class ToDoListDataModel
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; } = null!;
        public string? TaskDescritpion { get; set; }
        public int? TaskCategoryId { get; set; }
        public byte? PriorityLevel { get; set; }
        public string? Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        
    }
}
