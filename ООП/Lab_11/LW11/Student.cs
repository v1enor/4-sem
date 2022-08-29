namespace LW11
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Student
    {
        public int StudentID { get; set; }

        public int? AddressID { get; set; }

        [StringLength(32)]
        public string Name { get; set; }

        [StringLength(32)]
        public string Surname { get; set; }

        [StringLength(32)]
        public string Patronymic { get; set; }

        [StringLength(30)]
        public string Speciality { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Birthday { get; set; }

        public int? Course { get; set; }

        public int? GroupNumber { get; set; }

        [StringLength(20)]
        public string Gender { get; set; }

        [StringLength(12)]
        public string PhoneNumber { get; set; }

        public string ImageSrc { get; set; }

        public virtual Address Address { get; set; }

        public override string ToString()
        {
            return $"Student: {Name} {Surname} {Patronymic}\n" +
                $"Address: {Address.City} {Address.Street} {Address.C_Index}";
        }
    }
}
