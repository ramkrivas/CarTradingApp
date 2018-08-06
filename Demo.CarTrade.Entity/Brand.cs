using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Demo.CarTrade.Entity
{
    [DataContract]
    public class Brand
    {
        [DataMember]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BrandID { get; set; }
        [DataMember]
        public string BrandName { get; set; }
        [DataMember]
        public string BrandDescription { get; set; }
        [DataMember]
        public string BrandLogo { get; set; }
        [DataMember]
        public string BrandHeadQuarter { get; set; }
        [DataMember]
        public string Revenue { get; set; }
        [DataMember]
        public Nullable<int> NumberOfEmployees { get; set; }

        //[DataMember]
        //public IList<Car> CarsCollection { get; set; }
    }
}
