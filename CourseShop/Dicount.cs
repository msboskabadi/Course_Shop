﻿namespace CourseShop
{
    public class Dicount
    {
        public int DiscountId { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public string Name { get; set; }
        public int NewPrice { get; set; }
    }
}
