using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using movieappauth.Models;
using movieappauth.Data;
using MLSentymentalAnalysis;

namespace movieappauth.Controllers
{
    public class ContactoController : Controller
    {
        private readonly ILogger<ContactoController> _logger;
        private readonly ApplicationDbContext _context;


        public ContactoController(ILogger<ContactoController> logger,ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EnviarMensaje(Contacto objcontato)
        {
            _logger.LogDebug("Ingreso a Enviar Mensaje");
            
            MLModelTextClassification.ModelInput sampleData = new MLModelTextClassification.ModelInput()
            {
                Comentario = objcontato.Message
            };
            
            MLModelTextClassification.ModelOutput output = MLModelTextClassification.Predict(sampleData);
  
            //Console.WriteLine($"{output.Label}{output.PredictedLabel}");

            //output.Score.ToList().ForEach(score => Console.WriteLine(score));

            var sortedScoresWithLabel = MLModelTextClassification.PredictAllLabels(sampleData);
            var scoreKeyFirst = sortedScoresWithLabel.ToList()[0].Key;
            var scoreValueFirst = sortedScoresWithLabel.ToList()[0].Value;
            var scoreKeySecond = sortedScoresWithLabel.ToList()[1].Key;
            var scoreValueSecond = sortedScoresWithLabel.ToList()[1].Value;

            if(scoreKeyFirst == "1")
            {
                if(scoreValueFirst > 0.5)
                {
                    objcontato.Category = "Positivo";
                }
                else
                {
                    objcontato.Category = "Negativo";
                }
            }else{
                if(scoreValueFirst > 0.5)
                {
                    objcontato.Category = "Negativo";
                }
                else
                {
                    objcontato.Category = "Positivo";
                }
            }
            
            Console.WriteLine($"{scoreKeyFirst,-40}{scoreValueFirst,-20}");
            Console.WriteLine($"{scoreKeySecond,-40}{scoreValueSecond,-20}");


            /*foreach (var score in sortedScoresWithLabel)
            {
                Console.WriteLine($"{score.Key,-40}{score.Value,-20}");
            }*/
            

            //Se registran los datos del objeto a la base datos
            //_context.Add(objcontato);
            //_context.SaveChanges();

            ViewData["Message"] = "Se registro el contacto" + objcontato.Category;
            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}