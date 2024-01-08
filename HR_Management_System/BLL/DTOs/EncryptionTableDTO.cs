using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class EncryptionTableDTO
    {
        public int Id { get; set; }
        [Required]
        public string EncryptedText { get; set; }
        [Required]
        public string Encryptionkey { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
