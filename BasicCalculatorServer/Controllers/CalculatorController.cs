using BasicCalculatorServer.Model;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace BasicCalculatorServer.Controllers
{
    [Route("api/calculator")]
    public class CalculatorController : Controller
    {
        [HttpGet("firstNumber/{firstNumber}/secondNumber/{secondNumber}/operation/{operation}")]
        public async Task<double> Get(double firstNumber, double secondNumber, string operation)
        {

            var result = operation switch
            {
                "add" => firstNumber + secondNumber,
                "subtract" => firstNumber - secondNumber,
                "multiply" => firstNumber * secondNumber,
                "divide" => firstNumber / secondNumber,
            };

            var dbModel = new CalculatorDbModel();
            dbModel.Id = new Guid();
            dbModel.CreatedOn = DateTime.Now;
            dbModel.FirstNumber = firstNumber;
            dbModel.SecondNumber = secondNumber;
            dbModel.Operator = operation;
            dbModel.Result = result;
            var collections = GetCollections("CalculatorDbModel");
            collections.InsertOne(dbModel);
            return result;
        }

        public IMongoCollection<CalculatorDbModel> GetCollections(string collectionName)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("Calculator");
            return database.GetCollection<CalculatorDbModel>(collectionName);
        }
    }
}
