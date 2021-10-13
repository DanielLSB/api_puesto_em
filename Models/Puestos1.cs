using System.ComponentModel.DataAnnotations;

namespace web_api_empresa.Models{
public class Puestos1{
        [Key]
        public int id_puesto { get; set; }
        public string puesto { get; set; }
       
        
}

}