namespace ApiJoseArquieta.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Lista_Canciones
    {
        [Key]
        public int id_Cancion { get; set; }

        [StringLength(50)]
        public string Titulo { get; set; }

        [StringLength(50)]
        public string Grupo { get; set; }

        public int? Ano { get; set; }

        [StringLength(10)]
        public string Genero { get; set; }
    }
}
