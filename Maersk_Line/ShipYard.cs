//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Maersk_Line
{
    using System;
    using System.Collections.Generic;
    
    public partial class ShipYard
    {
        public ShipYard()
        {
            this.Bookings = new HashSet<Booking>();
        }
    
        public int ShipyardID { get; set; }
        public string ShipYardName { get; set; }
        public int CurrentNumberOfShipsDocked { get; set; }
        public int ShipYardDockNumber { get; set; }
        public int TotalNumberOfContainers { get; set; }
    
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
