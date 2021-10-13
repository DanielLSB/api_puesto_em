using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using web_api_empresa.Models;
namespace web_api_empresa.Controllers{
[Route("api/[controller]")]
    public class Puestos1Controller : Controller {
        private Conexion dbConexion;
        public Puestos1Controller(){ dbConexion = Conectar.Create();        }
       
         [HttpGet]
        public ActionResult Get() {return Ok(dbConexion.Puestos1.ToArray());}
      
        [HttpGet("{id}")]
         public async Task<ActionResult> Get(int id) {
             var puestos1 = await dbConexion.Puestos1.FindAsync(id);
            if (puestos1 != null) {
                return Ok(puestos1);
            } else {
                return NotFound();
            }
        }


         [HttpPost]
        public async Task<ActionResult> Post([FromBody] Puestos1 puestos1){
            if (ModelState.IsValid){
             dbConexion.Puestos1.Add(puestos1);
             await dbConexion.SaveChangesAsync();
             return Ok();
       
             }else{
                 return BadRequest();
             }
             
        }


   
     public async Task<ActionResult> Put([FromBody] Puestos1 puestos1){
        var v_puestos1 = dbConexion.Puestos1.SingleOrDefault(a => a.id_puesto == puestos1.id_puesto);
        if (v_puestos1 != null && ModelState.IsValid) {
            dbConexion.Entry(v_puestos1).CurrentValues.SetValues(puestos1);
            await dbConexion.SaveChangesAsync();
            //return Created("api/clientes",clientes);
                return Ok();
            } else {
                return BadRequest();
            }
    }

[HttpDelete("{id}")]
public async Task<ActionResult> Delete(int id) {
    var puestos1 = dbConexion.Puestos1.SingleOrDefault(a => a.id_puesto == id);
    if(puestos1!= null) {
        dbConexion.Puestos1.Remove(puestos1);
        await dbConexion.SaveChangesAsync();
                return Ok();
        } 
        else {    return NotFound();
        }
}
       

}

}