using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTDataProcessing.Domain.Models
{
    public class DeviceData
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key] 
        public required Guid Id { get; set; }      
       
        public required string DeviceId { get; set; }        
        public DateTime Timestamp { get; set; }         
        public required double Temperature { get; set; }
        public required double Humidity { get; set; }
    }
}
