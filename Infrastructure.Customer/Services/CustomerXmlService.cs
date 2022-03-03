using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Application.Interfaces.Services;
using Domain.Entities;

namespace Infrastructure.Customer.Services
{
  public class CustomerXmlService : ICustomerXmlService
  {
    public XmlDocument Load(string path)
    {
      throw new System.NotImplementedException();
    }

    public byte[] XmlSerializeToByte<T>(T value) where T : class
    {
      if (value == null)
      {
        throw new ArgumentNullException();
      }
      var serializer = new XmlSerializer(typeof(T));
      using var memoryStream = new MemoryStream();
      using var xmlWriter = XmlWriter.Create(memoryStream);
      serializer.Serialize(xmlWriter, value);
      return memoryStream.ToArray();
    }

    public CamposAdicionales SerializeToClass(CustomerEntity entity)
    {
      var xml = new CamposAdicionales
      {
        CampoAdicional = new []
        {
          new CamposAdicionalesCampoAdicional
          {
            nombre = "CustomerId",
            valor = entity.Id
          },
          new CamposAdicionalesCampoAdicional
          {
            nombre = "CustomerName",
            valor = entity.Name
          },
        }
      };
      return xml;
    }
  }
}