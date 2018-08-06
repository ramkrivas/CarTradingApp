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
    public class Car
    {
        [DataMember]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CarID { get; set; }
        [DataMember]
        public string ModelName { get; set; }
        [DataMember]
        public string ModelYear { get; set; }
        [DataMember]
        public int BrandID { get; set; }
        [DataMember]
        public string ImageUrl { get; set; }
        [DataMember]
        public string FuelType { get; set; }
        [DataMember]
        public string Aspiration { get; set; }
        [DataMember]
        public string BodyStyle { get; set; }
        [DataMember]
        public string DriveWheels { get; set; }
        [DataMember]
        public string EngineLocation { get; set; }
        [DataMember]
        public string WheelBase { get; set; }
        [DataMember]
        public string Length { get; set; }
        [DataMember]
        public string Height { get; set; }
        [DataMember]
        public string NumberOfCylinders { get; set; }
        [DataMember]
        public string EngineSize { get; set; }
        [DataMember]
        public string FuelSystem { get; set; }
        [DataMember]
        public string CompressionRatio { get; set; }
        [DataMember]
        public string HorsePower { get; set; }
        [DataMember]
        public string PeakRPM { get; set; }
        [DataMember]
        public string CityMilleage { get; set; }
        [DataMember]
        public string HighwayMilleage { get; set; }

        [DataMember]
        public string Price { get; set; }

    }
}
