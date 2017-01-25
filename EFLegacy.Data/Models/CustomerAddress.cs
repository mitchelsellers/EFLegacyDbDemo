using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFLegacy.Data.Models
{
    [Table("tblCustomerAddresses")]
    public class CustomerAddress
    {
        [Key]
        [Column("pkCAddId")]
        public int CustomerAddressId { get; set; }
        [Column("fkCustId")]
        public int CustomerId { get; set; }
        [Column("strCAddStreet")]
        public string Street { get; set; }
        [Column("strCAddCity")]
        public string City { get; set; }
        [Column("strCAddState")]
        public string State { get; set; }
        [Column("strCAddPostalCode")]
        public string PostalCode { get; set; }

        public virtual Customer Customer { get; set; }
    }
}