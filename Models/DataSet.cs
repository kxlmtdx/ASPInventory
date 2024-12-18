using Microsoft.CodeAnalysis;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace ASPInventory.Models
{
    public class DataSet
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int IN { get; set; }
        public string? From_TO { get; set; }
        public string? In_TO { get; set; }
        public DateTime? Accepted { get; set; }
        public DateTime? Given_Away { get; set; }
        public DateTime? Taken_Away { get; set; }
        public string? Transfered_To { get; set; }
        public string? Transmited_From { get; set; }
        public string? Model { get; set; }
        public string? Id_StorageLocation { get; set; }
        public string? Id_Condition { get; set; }
        public DateTime? SentToTO { get; set; }
    }
}
