﻿namespace OnlineTest.Services.DTO.UpdateDTO
{
    public class UpdateTechnologyDTO
    {
        public int Id { get; set; }
        public string TechName { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}