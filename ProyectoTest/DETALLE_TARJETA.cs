//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoTest
{
    using System;
    using System.Collections.Generic;
    
    public partial class DETALLE_TARJETA
    {
        public int IdDetalleTarjeta { get; set; }
        public Nullable<int> IdCompra { get; set; }
        public string TipoTarjeta { get; set; }
        public string NombreTitular { get; set; }
        public string NumeroTarjeta { get; set; }
        public string Vigencia { get; set; }
        public string CVV { get; set; }
        public Nullable<System.DateTime> FechaRegistro { get; set; }
    
        public virtual COMPRA COMPRA { get; set; }
    }
}