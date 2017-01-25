using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFLegacy.Data.Models
{
    [Table("tblCustomer")]
    public class Customer
    {
        [Key]
        [Column("pkCustId")]
        public int CustomerId { get; set; }

        [Column("strCustName")]
        public string CustomerName { get; set; }

        [Column("strCustEmail")]
        public string CustomerEmail { get; set; }

        [Column("dteBirthdate")]
        public DateTime Birthdate { get; set; }

        public virtual ICollection<CustomerAddress> Addresses { get; set; }
    }
}