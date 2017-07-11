using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Maersk_Line.Models
{
    public class Booking
    { 
    [Key]
    public int BookingID { get; set; }

    [Required]
    public int WarehouseID { get; set; }
    public Warehouse warehouse { get; set; }

    [Required]
    public int ShipCode { get; set; }
    public Ships ships { get; set; }

    [Required]
    public int ShipyardID{ get; set; }
    public ShipYard shipYard { get; set; }

    [Required]
    public int ContainerID { get; set; }
    public Container container { get; set; }
    [Required]
    public double Price { get; set; }

    [Required]
    public string Date { get; set; }

    [Required]
    public string Time { get; set; }

    [Required]
    public string Departure { get; set; }

    [Required]
    public string Destination { get; set; }

}
}