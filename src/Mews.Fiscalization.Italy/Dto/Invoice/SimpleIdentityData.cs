using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Mews.Fiscalization.Italy.Dto.Invoice
{
    [Serializable, XmlType(Namespace = "http://ivaservizi.agenziaentrate.gov.it/docs/xsd/fatture/v1.2")]
    public class SimpleIdentityData
    {
        [XmlElement("IdFiscaleIVA", Form = XmlSchemaForm.Unqualified)]
        public SenderId VatTaxId { get; set; }

        [XmlElement("CodiceFiscale", Form = XmlSchemaForm.Unqualified)]
        public string TaxCode { get; set; }

        [XmlElement("Anagrafica", Form = XmlSchemaForm.Unqualified)]
        public Identity Identity { get; set; }
    }
}