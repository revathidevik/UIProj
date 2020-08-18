using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHubTest.Models
{
   public class AttachmentMetaData
    {

        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        public class Doctor
        {
            public string firstName { get; set; }
            public string lastName { get; set; }
            public string licenseNumber { get; set; }
            public string npid { get; set; }
            public string taxId { get; set; }
            public int specialtyCodeId { get; set; }
            public string providerName { get; set; }
        }

        public class Facility
        {
            public string facilityId { get; set; }
            public string practiceAddress1 { get; set; }
            public string practiceAddress2 { get; set; }
            public string practiceCity { get; set; }
            public string practiceName { get; set; }
            public string practicePhone { get; set; }
            public string practiceStateAbbrv { get; set; }
            public string practiceZip { get; set; }
        }

        public class Payor
        {
            public string groupNumber { get; set; }
            public string insuredsFirstName { get; set; }
            public string insuredsId { get; set; }
            public string insuredsLastName { get; set; }
            public int masterId { get; set; }
            public int relationship { get; set; }
        }

        public class Procedure
        {
            public string cdtCode { get; set; }
            public DateTime procedureDate { get; set; }
            public int procedureId { get; set; }
        }

        public class Patient
        {
            public string medicalRecordNumber { get; set; }
            public string firstName { get; set; }
            public string lastName { get; set; }
            public DateTime dateOfBirth { get; set; }
        }

        public class Root
        {
            public Doctor doctor { get; set; }
            public Facility facility { get; set; }
            public Payor payor { get; set; }
            public List<Procedure> procedures { get; set; }
            public Patient patient { get; set; }
            public string dmsInternalReferenceNumber { get; set; }
            public DateTime dosFrom { get; set; }
            public DateTime dosThru { get; set; }
            public string message { get; set; }
            public string narrative { get; set; }
            public string payorRefNum { get; set; }
            public string customerRefNum { get; set; }
            public bool predeterminationFlag { get; set; }
            public string caseNum { get; set; }
            public string esMdUseCase { get; set; }
        }


    }
}
