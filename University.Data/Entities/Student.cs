namespace University.Data.Entities
{
    public  class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public DateTime CreatedTime { get; set; }
        public DateTime LastUpdatedTime { get; set; }
    }
}
