using System.Xml;
using Domain.Entities;

namespace Application.Interfaces.Services
{
  public interface ICustomerXmlService
  {
    XmlDocument Load(string path);
    byte[] XmlSerializeToByte<T>(T value) where T : class;
    CamposAdicionales SerializeToClass(CustomerEntity entity);
  }
}