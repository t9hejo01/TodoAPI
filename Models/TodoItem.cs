﻿namespace TodoAPI.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set;}

        public bool IsComplete { get; set; }

        

    }
}
