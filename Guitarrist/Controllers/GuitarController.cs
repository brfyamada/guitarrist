using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Guitarrist.Models.Entities;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;

namespace Guitarrist.Controllers
{
    public class GuitarController : Controller
    {
        HttpClient client = new HttpClient();

        public async Task<List<Guitar>> getGuitarAsync()
        {
            try
            {

                string url = "https://byamada.outsystemscloud.com/guitar_api/rest/guitarapi/guitars";
                var response = await client.GetStringAsync(url);
                var guitars = JsonConvert.DeserializeObject<List<Guitar>>(response);
                return guitars;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }


  
        public async Task<ActionResult> ListagemGuitar()
        {
            List<Guitar> guitars = new List<Guitar>();
            guitars = await getGuitarAsync();

            return View(guitars);
        }
       
    }
}
