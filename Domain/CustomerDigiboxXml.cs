[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.digibox.com.mx/cfdi/camposadicionales")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.digibox.com.mx/cfdi/camposadicionales", IsNullable = false)]
public partial class CamposAdicionales
{
  private CamposAdicionalesCampoAdicional[] campoAdicionalField;
  [System.Xml.Serialization.XmlElementAttribute("CampoAdicional")]
  public CamposAdicionalesCampoAdicional[] CampoAdicional
  {
    get
    {
      return this.campoAdicionalField;
    }
    set
    {
      this.campoAdicionalField = value;
    }
  }
}

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.digibox.com.mx/cfdi/camposadicionales")]
public partial class CamposAdicionalesCampoAdicional
{

  private string nombreField;

  private string valorField;

  private string valueField;

  /// <remarks/>
  [System.Xml.Serialization.XmlAttributeAttribute()]
  public string nombre
  {
    get
    {
      return this.nombreField;
    }
    set
    {
      this.nombreField = value;
    }
  }

  /// <remarks/>
  [System.Xml.Serialization.XmlAttributeAttribute()]
  public string valor
  {
    get
    {
      return this.valorField;
    }
    set
    {
      this.valorField = value;
    }
  }

  /// <remarks/>
  [System.Xml.Serialization.XmlTextAttribute()]
  public string Value
  {
    get
    {
      return this.valueField;
    }
    set
    {
      this.valueField = value;
    }
  }
}
