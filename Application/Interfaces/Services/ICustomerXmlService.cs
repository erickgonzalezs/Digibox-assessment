using System.Xml;

namespace Application.Interfaces.Services
{
  public interface ICustomerXmlService
  {
    XmlDocument Load(string path);
  }
}