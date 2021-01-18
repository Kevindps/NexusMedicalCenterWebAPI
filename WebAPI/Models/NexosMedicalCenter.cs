using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public class NexosMedicalCenterDoctor
    { 
        [Key]
        public int DoctorId { get; set; }

        [Required]
        [Column(TypeName = "ntext")]
        public string DoctorFullName { get; set; }

        [Required]
        [Column(TypeName = "varchar(32)")]
        public string DoctorCredentialNumber { get; set; }

        [Required]
        [Column(TypeName = "ntext")]
        public string DoctorSpecialty { get; set; }

        [Required]
        [Column(TypeName = "ntext")]
        public string DoctorHospital { get; set; }

        public ICollection<NexosMedicalCenterPatient> DoctorPatients { get; set; }
    }

    public class NexosMedicalCenterPatient
    {
        [Key]
        public int PatientId { get; set; }

        [Required]
        [Column(TypeName = "ntext")]
        public string PatientFullName { get; set; }

        [Required]
        [Column(TypeName = "char(6)")]
        public string PatientPostalCode { get; set; }

        [Required]
        [Column(TypeName = "varchar(32)")]
        public string PatientSocialSecurityNumber { get; set; }

        [Required]
        [Column(TypeName = "varchar(10)")]
        public string PatientContactNumber { get; set; }

        public ICollection<NexosMedicalCenterDoctor> PatientDoctors { get; set; }
    }
}
