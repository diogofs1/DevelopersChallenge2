using FinancerData;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace Concilia.Controllers.Concilia
{
    [ApiController]
    [Route("[controller]")]
    public class ConciliaExtratosController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            ConciliaExtrato.ConciliarExtrato(@"./OfxFiles");
            List<TbImport> transactionsMerged = new List<TbImport>();


            XElement doc = ImportOfx.toXElement(@"./OfxFiles/ExtratoConciliado.ofx");

            var transactions = (from c in doc.Descendants("STMTTRN")
            where c.Element("TRNTYPE").Value != string.Empty
            select new TbImport
            {
                Amount = decimal.Parse(c.Element("TRNAMT").Value, NumberFormatInfo.InvariantInfo),
                Data = DateTime.ParseExact(c.Element("DTPOSTED").Value, "yyyyMMdd", null),
                Description = c.Element("MEMO").Value,
            });


            foreach (var item in transactions)
            {
                if (!transactionsMerged.Any(x => 
                        x.Data == item.Data && x.Description == item.Description && x.Amount == item.Amount) )
                {
                    transactionsMerged.Add(item);
                }
            }

            return Ok(transactionsMerged.OrderBy(x => x.Data));
        }

    }
}