namespace TaskOneMVC.Models
{
	public class Task
	{
		public int TaskId { get; set; }
		public string title { get; set; }
		public DateTime startDate { get; set; }
		public DateTime endDate { get; set; }
		public string description { get; set; }
		public string levelOfImportance { get; set; }

	}
}
