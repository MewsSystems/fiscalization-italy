using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Mews.Fiscalization.Italy.Dto
{
    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public class GeneralData
    {
        [XmlElement("DatiGeneraliDocumento", Form = XmlSchemaForm.Unqualified)]
        public DatiGeneraliDocumentoType DatiGeneraliDocumento { get; set; }

        [XmlElement("DatiOrdineAcquisto", Form = XmlSchemaForm.Unqualified)]
        public DatiDocumentiCorrelatiType[] DatiOrdineAcquisto { get; set; }

        [XmlElement("DatiContratto", Form = XmlSchemaForm.Unqualified)]
        public DatiDocumentiCorrelatiType[] DatiContratto { get; set; }

        [XmlElement("DatiConvenzione", Form = XmlSchemaForm.Unqualified)]
        public DatiDocumentiCorrelatiType[] DatiConvenzione { get; set; }

        [XmlElement("DatiRicezione", Form = XmlSchemaForm.Unqualified)]
        public DatiDocumentiCorrelatiType[] DatiRicezione { get; set; }

        [XmlElement("DatiFattureCollegate", Form = XmlSchemaForm.Unqualified)]
        public DatiDocumentiCorrelatiType[] DatiFattureCollegate { get; set; }

        [XmlElement("DatiSAL", Form = XmlSchemaForm.Unqualified)]
        public DatiSALType[] DatiSAL { get; set; }

        [XmlElement("DatiDDT", Form = XmlSchemaForm.Unqualified)]
        public DatiDDTType[] DatiDDT { get; set; }

        [XmlElement("DatiTrasporto", Form = XmlSchemaForm.Unqualified)]
        public DatiTrasportoType DatiTrasporto { get; set; }

        [XmlElement("FatturaPrincipale", Form = XmlSchemaForm.Unqualified)]
        public FatturaPrincipaleType FatturaPrincipale { get; set; }
    }
}