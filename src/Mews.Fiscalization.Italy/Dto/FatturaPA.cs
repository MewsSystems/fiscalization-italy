using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Mews.Fiscalization.Italy.Dto
{
    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1"), XmlRoot("FatturaElettronica", Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1", IsNullable = false)]
    public class ElectronicInvoice
    {
        [XmlElement("FatturaElettronicaHeader", Form = XmlSchemaForm.Unqualified)]
        public ElectronicInvoiceHeader Header { get; set; }

        [XmlElement("FatturaElettronicaBody", Form = XmlSchemaForm.Unqualified)]
        public ElectronicInvoiceBody[] Body { get; set; }

        [XmlElement(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public SignatureType Signature { get; set; }

        [XmlAttribute]
        public VersioneSchemaType versione { get; set; }
    }

    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public class ElectronicInvoiceHeader
    {
        [XmlElement("DatiTrasmissione", Form = XmlSchemaForm.Unqualified)]
        public DatiTrasmissioneType DatiTrasmissione { get; set; }

        [XmlElement("CedentePrestatore", Form = XmlSchemaForm.Unqualified)]
        public Provider Provider { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public RappresentanteFiscaleType RappresentanteFiscale { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public CessionarioCommittenteType CessionarioCommittente { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public TerzoIntermediarioSoggettoEmittenteType TerzoIntermediarioOSoggettoEmittente { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public SoggettoEmittenteType SoggettoEmittente { get; set; }

        [XmlIgnore]
        public bool SoggettoEmittenteSpecified { get; set; }
    }

    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public class DatiTrasmissioneType
    {
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public IdFiscaleType IdTrasmittente { get; set; }

        [XmlElement("ProgressivoInvio", Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string SequentialNumber { get; set; }

        [XmlElement("FormatoTrasmissione", Form = XmlSchemaForm.Unqualified)]
        public FileSchemaVersion FileSchemaVersion { get; set; }

        [XmlElement("CodiceDestinatario", Form = XmlSchemaForm.Unqualified)]
        public string FinancialOfficeId { get; set; }

        [XmlElement("ContattiTrasmittente", Form = XmlSchemaForm.Unqualified)]
        public ContattiTrasmittenteType TransmitterContact { get; set; }
    }

    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public class IdFiscaleType
    {
        [XmlElement("IdPaese", Form = XmlSchemaForm.Unqualified)]
        public string CountryCode { get; set; }

        [XmlElement("IdCodice", Form = XmlSchemaForm.Unqualified)]
        public string VatNumber { get; set; }
    }

    [Serializable, XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#"), XmlRoot("Object", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public class ObjectType
    {
        [XmlText, XmlAnyElement]
        public XmlNode[] Any { get; set; }

        [XmlAttribute(DataType = "ID")]
        public string Id { get; set; }

        [XmlAttribute]
        public string MimeType { get; set; }

        [XmlAttribute(DataType = "anyURI")]
        public string Encoding { get; set; }
    }

    [Serializable, XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#"), XmlRoot("SPKIData", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public class SPKIDataType
    {
        [XmlElement("SPKISexp", DataType = "base64Binary")]
        public byte[][] SPKISexp { get; set; }

        [XmlAnyElement]
        public XmlElement Any { get; set; }
    }

    [Serializable, XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#"), XmlRoot("PGPData", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public class PGPDataType
    {
        [XmlAnyElement, XmlElement("PGPKeyID", typeof(byte[]), DataType = "base64Binary"), XmlElement("PGPKeyPacket", typeof(byte[]), DataType = "base64Binary"), XmlChoiceIdentifierAttribute("ItemsElementName")]
        public object[] Items { get; set; }

        [XmlElement("ItemsElementName"), XmlIgnore]
        public ItemsChoiceType2[] ItemsElementName { get; set; }
    }

    [Serializable, XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#", IncludeInSchema = false)]
    public enum ItemsChoiceType2
    {
        [XmlEnum("##any:")]
        Item,
        PGPKeyID,
        PGPKeyPacket,
    }

    [Serializable, XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public class X509IssuerSerialType
    {
        public string X509IssuerName { get; set; }

        [XmlElement(DataType = "integer")]
        public string X509SerialNumber { get; set; }
    }

    [Serializable, XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#"), XmlRoot("X509Data", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public class X509DataType
    {
        [XmlAnyElement, XmlElement("X509CRL", typeof(byte[]), DataType = "base64Binary"), XmlElement("X509Certificate", typeof(byte[]), DataType = "base64Binary"), XmlElement("X509IssuerSerial", typeof(X509IssuerSerialType)), XmlElement("X509SKI", typeof(byte[]), DataType = "base64Binary"), XmlElement("X509SubjectName", typeof(string)), XmlChoiceIdentifierAttribute("ItemsElementName")]
        public object[] Items { get; set; }

        [XmlElement("ItemsElementName"), XmlIgnore]
        public ItemsChoiceType1[] ItemsElementName { get; set; }
    }

    [Serializable, XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#", IncludeInSchema = false)]
    public enum ItemsChoiceType1
    {
        [XmlEnum("##any:")]
        Item,
        X509CRL,
        X509Certificate,
        X509IssuerSerial,
        X509SKI,
        X509SubjectName,
    }

    [Serializable, XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#"), XmlRoot("RetrievalMethod", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public class RetrievalMethodType
    {

        [XmlArrayItem("Transform", IsNullable = false)]
        public TransformType[] Transforms { get; set; }

        [XmlAttribute(DataType = "anyURI")]
        public string URI { get; set; }

        [XmlAttribute(DataType = "anyURI")]
        public string Type { get; set; }
    }

    [Serializable, XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#"), XmlRoot("Transform", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public class TransformType
    {
        [XmlAnyElement, XmlElement("XPath", typeof(string))]
        public object[] Items { get; set; }

        [XmlText]
        public string[] Text { get; set; }

        [XmlAttribute(DataType = "anyURI")]
        public string Algorithm { get; set; }
    }

    [Serializable, XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#"), XmlRoot("RSAKeyValue", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public class RSAKeyValueType
    {
        [XmlElement(DataType = "base64Binary")]
        public byte[] Modulus { get; set; }

        [XmlElement(DataType = "base64Binary")]
        public byte[] Exponent { get; set; }
    }

    [Serializable, XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#"), XmlRoot("DSAKeyValue", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public class DSAKeyValueType
    {
        [XmlElement(DataType = "base64Binary")]
        public byte[] P { get; set; }

        [XmlElement(DataType = "base64Binary")]
        public byte[] Q { get; set; }

        [XmlElement(DataType = "base64Binary")]
        public byte[] G { get; set; }

        [XmlElement(DataType = "base64Binary")]
        public byte[] Y { get; set; }

        [XmlElement(DataType = "base64Binary")]
        public byte[] J { get; set; }

        [XmlElement(DataType = "base64Binary")]
        public byte[] Seed { get; set; }

        [XmlElement(DataType = "base64Binary")]
        public byte[] PgenCounter { get; set; }
    }

    [Serializable, XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#"), XmlRoot("KeyValue", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public class KeyValueType
    {
        [XmlAnyElement, XmlElement("DSAKeyValue", typeof(DSAKeyValueType)), XmlElement("RSAKeyValue", typeof(RSAKeyValueType))]
        public object Item { get; set; }

        [XmlText]
        public string[] Text { get; set; }
    }

    [Serializable, XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#"), XmlRoot("KeyInfo", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public class KeyInfoType
    {
        [XmlAnyElement, XmlElement("KeyName", typeof(string)), XmlElement("KeyValue", typeof(KeyValueType)), XmlElement("MgmtData", typeof(string)), XmlElement("PGPData", typeof(PGPDataType)), XmlElement("RetrievalMethod", typeof(RetrievalMethodType)), XmlElement("SPKIData", typeof(SPKIDataType)), XmlElement("X509Data", typeof(X509DataType)), XmlChoiceIdentifierAttribute("ItemsElementName")]
        public object[] Items { get; set; }

        [XmlElement("ItemsElementName"), XmlIgnore]
        public ItemsChoiceType3[] ItemsElementName { get; set; }

        [XmlText]
        public string[] Text { get; set; }

        [XmlAttribute(DataType = "ID")]
        public string Id { get; set; }
    }

    [Serializable, XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#", IncludeInSchema = false)]
    public enum ItemsChoiceType3
    {
        [XmlEnum("##any:")]
        Item,
        KeyName,
        KeyValue,
        MgmtData,
        PGPData,
        RetrievalMethod,
        SPKIData,
        X509Data,
    }

    [Serializable, XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#"), XmlRoot("SignatureValue", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public class SignatureValueType
    {
        [XmlAttribute(DataType = "ID")]
        public string Id { get; set; }

        [XmlText(DataType = "base64Binary")]
        public byte[] Value { get; set; }
    }

    [Serializable, XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#"), XmlRoot("DigestMethod", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public class DigestMethodType
    {
        [XmlText, XmlAnyElement]
        public XmlNode[] Any { get; set; }

        [XmlAttribute(DataType = "anyURI")]
        public string Algorithm { get; set; }
    }

    [Serializable, XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#"), XmlRoot("Reference", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public class ReferenceType
    {
        [XmlArrayItem("Transform", IsNullable = false)]
        public TransformType[] Transforms { get; set; }

        public DigestMethodType DigestMethod { get; set; }

        [XmlElement(DataType = "base64Binary")]
        public byte[] DigestValue { get; set; }

        [XmlAttribute(DataType = "ID")]
        public string Id { get; set; }

        [XmlAttribute(DataType = "anyURI")]
        public string URI { get; set; }

        [XmlAttribute(DataType = "anyURI")]
        public string Type { get; set; }
    }

    [Serializable, XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#"), XmlRoot("SignatureMethod", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public class SignatureMethodType
    {
        [XmlElement(DataType = "integer")]
        public string HMACOutputLength { get; set; }

        [XmlText, XmlAnyElement]
        public XmlNode[] Any { get; set; }

        [XmlAttribute(DataType = "anyURI")]
        public string Algorithm { get; set; }
    }

    [Serializable, XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#"), XmlRoot("CanonicalizationMethod", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public class CanonicalizationMethodType
    {
        [XmlText, XmlAnyElement]
        public XmlNode[] Any { get; set; }

        [XmlAttribute(DataType = "anyURI")]
        public string Algorithm { get; set; }
    }

    [Serializable, XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#"), XmlRoot("SignedInfo", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public class SignedInfoType
    {
        public CanonicalizationMethodType CanonicalizationMethod { get; set; }

        public SignatureMethodType SignatureMethod { get; set; }

        [XmlElement("Reference")]
        public ReferenceType[] Reference { get; set; }

        [XmlAttribute(DataType = "ID")]
        public string Id { get; set; }
    }

    [Serializable, XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#"), XmlRoot("Signature", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public class SignatureType
    {
        public SignedInfoType SignedInfo { get; set; }

        public SignatureValueType SignatureValue { get; set; }

        public KeyInfoType KeyInfo { get; set; }

        [XmlElement("Object")]
        public ObjectType[] Object { get; set; }

        [XmlAttribute(DataType = "ID")]
        public string Id { get; set; }
    }

    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public class AllegatiType
    {
        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string NomeAttachment { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string AlgoritmoCompressione { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string FormatoAttachment { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string DescrizioneAttachment { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "base64Binary")]
        public byte[] Attachment { get; set; }
    }

    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public class DettaglioPagamentoType
    {
        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string Beneficiario { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public ModalitaPagamentoType ModalitaPagamento { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "date")]
        public DateTime DataRiferimentoTerminiPagamento { get; set; }

        [XmlIgnore]
        public bool DataRiferimentoTerminiPagamentoSpecified { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "integer")]
        public string GiorniTerminiPagamento { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "date")]
        public DateTime DataScadenzaPagamento { get; set; }

        [XmlIgnore]
        public bool DataScadenzaPagamentoSpecified { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public decimal ImportoPagamento { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string CodUfficioPostale { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string CognomeQuietanzante { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string NomeQuietanzante { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string CFQuietanzante { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string TitoloQuietanzante { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string IstitutoFinanziario { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string IBAN { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string ABI { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string CAB { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string BIC { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public decimal ScontoPagamentoAnticipato { get; set; }

        [XmlIgnore]
        public bool ScontoPagamentoAnticipatoSpecified { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "date")]
        public DateTime DataLimitePagamentoAnticipato { get; set; }

        [XmlIgnore]
        public bool DataLimitePagamentoAnticipatoSpecified { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public decimal PenalitaPagamentiRitardati { get; set; }

        [XmlIgnore]
        public bool PenalitaPagamentiRitardatiSpecified { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "date")]
        public DateTime DataDecorrenzaPenale { get; set; }

        [XmlIgnore]
        public bool DataDecorrenzaPenaleSpecified { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string CodicePagamento { get; set; }
    }

    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public enum ModalitaPagamentoType
    {
        MP01,
        MP02,
        MP03,
        MP04,
        MP05,
        MP06,
        MP07,
        MP08,
        MP09,
        MP10,
        MP11,
        MP12,
        MP13,
        MP14,
        MP15,
        MP16,
        MP17,
        MP18,
        MP19,
        MP20,
        MP21,
    }

    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public class DatiPagamentoType
    {
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public CondizioniPagamentoType CondizioniPagamento { get; set; }

        [XmlElement("DettaglioPagamento", Form = XmlSchemaForm.Unqualified)]
        public DettaglioPagamentoType[] DettaglioPagamento { get; set; }
    }

    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public enum CondizioniPagamentoType
    {
        TP01,
        TP02,
        TP03,
    }

    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public class DatiVeicoliType
    {
        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "date")]
        public DateTime Data { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string TotalePercorso { get; set; }
    }

    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public class DatiRiepilogoType
    {
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public decimal AliquotaIVA { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public NaturaType Natura { get; set; }

        [XmlIgnore]
        public bool NaturaSpecified { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public decimal SpeseAccessorie { get; set; }

        [XmlIgnore]
        public bool SpeseAccessorieSpecified { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public decimal Arrotondamento { get; set; }

        [XmlIgnore]
        public bool ArrotondamentoSpecified { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public decimal ImponibileImporto { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public decimal Imposta { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public EsigibilitaIVAType EsigibilitaIVA { get; set; }

        [XmlIgnore]
        public bool EsigibilitaIVASpecified { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string RiferimentoNormativo { get; set; }
    }

    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public enum NaturaType
    {
        N1,
        N2,
        N3,
        N4,
        N5,
        N6,
    }

    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public enum EsigibilitaIVAType
    {
        D,
        I,
        S,
    }

    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public class AltriDatiGestionaliType
    {
        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string TipoDato { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string RiferimentoTesto { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public decimal RiferimentoNumero { get; set; }

        [XmlIgnore]
        public bool RiferimentoNumeroSpecified { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "date")]
        public DateTime RiferimentoData { get; set; }

        [XmlIgnore]
        public bool RiferimentoDataSpecified { get; set; }
    }

    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public class CodiceArticoloType
    {
        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string CodiceTipo { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string CodiceValore { get; set; }
    }

    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public class DettaglioLineeType
    {
        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "integer")]
        public string NumeroLinea { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public TipoCessionePrestazioneType TipoCessionePrestazione { get; set; }

        [XmlIgnore]
        public bool TipoCessionePrestazioneSpecified { get; set; }

        [XmlElement("CodiceArticolo", Form = XmlSchemaForm.Unqualified)]
        public CodiceArticoloType[] CodiceArticolo { get; set; }

        [XmlElement("Descrizione", Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string Description { get; set; }

        [XmlElement("Quantita", Form = XmlSchemaForm.Unqualified)]
        public decimal UnitCount { get; set; }

        [XmlIgnore]
        public bool UnitCountSpecified { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string UnitaMisura { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "date")]
        public DateTime DataInizioPeriodo { get; set; }

        [XmlIgnore]
        public bool DataInizioPeriodoSpecified { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "date")]
        public DateTime DataFinePeriodo { get; set; }

        [XmlIgnore]
        public bool DataFinePeriodoSpecified { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public decimal PrezzoUnitario { get; set; }

        [XmlElement("ScontoMaggiorazione", Form = XmlSchemaForm.Unqualified)]
        public ScontoMaggiorazioneType[] ScontoMaggiorazione { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public decimal PrezzoTotale { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public decimal AliquotaIVA { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public RitenutaType Ritenuta { get; set; }

        [XmlIgnore]
        public bool RitenutaSpecified { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public NaturaType Natura { get; set; }

        [XmlIgnore]
        public bool NaturaSpecified { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string RiferimentoAmministrazione { get; set; }

        [XmlElement("AltriDatiGestionali", Form = XmlSchemaForm.Unqualified)]
        public AltriDatiGestionaliType[] AltriDatiGestionali { get; set; }
    }

    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public enum TipoCessionePrestazioneType
    {
        SC,
        PR,
        AB,
        AC,
    }

    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public class ScontoMaggiorazioneType
    {
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public TipoScontoMaggiorazioneType Tipo { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public decimal Percentuale { get; set; }

        [XmlIgnore]
        public bool PercentualeSpecified { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public decimal Importo { get; set; }

        [XmlIgnore]
        public bool ImportoSpecified { get; set; }
    }

    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public enum TipoScontoMaggiorazioneType
    {
        SC,
        MG,
    }

    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public enum RitenutaType
    {
        SI,
    }

    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public class DatiBeniServiziType
    {
        [XmlElement("DettaglioLinee", Form = XmlSchemaForm.Unqualified)]
        public DettaglioLineeType[] DettaglioLinee { get; set; }

        [XmlElement("DatiRiepilogo", Form = XmlSchemaForm.Unqualified)]
        public DatiRiepilogoType[] DatiRiepilogo { get; set; }
    }

    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public class FatturaPrincipaleType
    {
        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string NumeroFatturaPrincipale { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "date")]
        public DateTime DataFatturaPrincipale { get; set; }
    }

    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public class DatiAnagraficiVettoreType
    {
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public IdFiscaleType IdFiscaleIVA { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string CodiceFiscale { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public AnagraficaType Anagrafica { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string NumeroLicenzaGuida { get; set; }
    }

    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public class AnagraficaType
    {
        [XmlElement("Cognome", typeof(string), Form = XmlSchemaForm.Unqualified, DataType = "normalizedString"), XmlElement("Denominazione", typeof(string), Form = XmlSchemaForm.Unqualified, DataType = "normalizedString"), XmlElement("Nome", typeof(string), Form = XmlSchemaForm.Unqualified, DataType = "normalizedString"), XmlChoiceIdentifierAttribute("ItemsElementName")]
        public string[] Items { get; set; }

        [XmlElement("ItemsElementName"), XmlIgnore]
        public ItemsChoiceType[] ItemsElementName { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string Titolo { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string CodEORI { get; set; }
    }

    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1", IncludeInSchema = false)]
    public enum ItemsChoiceType
    {
        [XmlEnum(":Cognome")]
        Cognome,
        [XmlEnum(":Denominazione")]
        Denominazione,
        [XmlEnum(":Nome")]
        Nome,
    }

    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public class DatiTrasportoType
    {
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public DatiAnagraficiVettoreType DatiAnagraficiVettore { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string MezzoTrasporto { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string CausaleTrasporto { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "integer")]
        public string NumeroColli { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string Descrizione { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string UnitaMisuraPeso { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public decimal PesoLordo { get; set; }

        [XmlIgnore]
        public bool PesoLordoSpecified { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public decimal PesoNetto { get; set; }

        [XmlIgnore]
        public bool PesoNettoSpecified { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public DateTime DataOraRitiro { get; set; }

        [XmlIgnore]
        public bool DataOraRitiroSpecified { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "date")]
        public DateTime DataInizioTrasporto { get; set; }

        [XmlIgnore]
        public bool DataInizioTrasportoSpecified { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string TipoResa { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public Address IndirizzoResa { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public DateTime DataOraConsegna { get; set; }

        [XmlIgnore]
        public bool DataOraConsegnaSpecified { get; set; }
    }

    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public class Address
    {
        public Address()
        {
            CountryCode = "IT";
        }

        [XmlElement("Indirizzo", Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string Street { get; set; }

        [XmlElement("NumeroCivico", Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string HouseNumber { get; set; }

        [XmlElement("CAP", Form = XmlSchemaForm.Unqualified)]
        public string Zip { get; set; }

        [XmlElement("Comune", Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string City { get; set; }

        [XmlElement("Provincia", Form = XmlSchemaForm.Unqualified)]
        public string ProvinceCode { get; set; }

        [XmlElement("Nazione", Form = XmlSchemaForm.Unqualified)]
        public string CountryCode { get; set; }
    }

    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public class DatiDDTType
    {
        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string NumeroDDT { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "date")]
        public DateTime DataDDT { get; set; }

        [XmlElement("RiferimentoNumeroLinea", Form = XmlSchemaForm.Unqualified, DataType = "integer")]
        public string[] RiferimentoNumeroLinea { get; set; }
    }

    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public class DatiSALType
    {
        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "integer")]
        public string RiferimentoFase { get; set; }
    }

    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public class DatiDocumentiCorrelatiType
    {
        [XmlElement("RiferimentoNumeroLinea", Form = XmlSchemaForm.Unqualified, DataType = "integer")]
        public string[] RiferimentoNumeroLinea { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string IdDocumento { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "date")]
        public DateTime Data { get; set; }

        [XmlIgnore]
        public bool DataSpecified { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string NumItem { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string CodiceCommessaConvenzione { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string CodiceCUP { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string CodiceCIG { get; set; }
    }

    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public class DatiCassaPrevidenzialeType
    {
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public TipoCassaType TipoCassa { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public decimal AlCassa { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public decimal ImportoContributoCassa { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public decimal ImponibileCassa { get; set; }

        [XmlIgnore]
        public bool ImponibileCassaSpecified { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public decimal AliquotaIVA { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public RitenutaType Ritenuta { get; set; }

        [XmlIgnore]
        public bool RitenutaSpecified { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public NaturaType Natura { get; set; }

        [XmlIgnore]
        public bool NaturaSpecified { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string RiferimentoAmministrazione { get; set; }
    }

    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public enum TipoCassaType
    {
        TC01,
        TC02,
        TC03,
        TC04,
        TC05,
        TC06,
        TC07,
        TC08,
        TC09,
        TC10,
        TC11,
        TC12,
        TC13,
        TC14,
        TC15,
        TC16,
        TC17,
        TC18,
        TC19,
        TC20,
        TC21,
        TC22,
    }

    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public class DatiBolloType
    {
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public BolloVirtualeType BolloVirtuale { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public decimal ImportoBollo { get; set; }
    }

    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public enum BolloVirtualeType
    {
        SI,
    }

    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public class DatiRitenutaType
    {
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public TipoRitenutaType TipoRitenuta { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public decimal ImportoRitenuta { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public decimal AliquotaRitenuta { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public CausalePagamentoType CausalePagamento { get; set; }
    }

    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public enum TipoRitenutaType
    {
        RT01,
        RT02,
    }

    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public enum CausalePagamentoType
    {
        A,
        B,
        C,
        D,
        E,
        G,
        H,
        I,
        L,
        M,
        N,
        O,
        P,
        Q,
        R,
        S,
        T,
        U,
        V,
        W,
        X,
        Y,
        Z,
        L1,
        M1,
        O1,
        V1,
    }

    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public class DatiGeneraliDocumentoType
    {
        [XmlElement("TipoDocumento", Form = XmlSchemaForm.Unqualified)]
        public DcoumentType DocumentType { get; set; }

        [XmlElement("Divisa", Form = XmlSchemaForm.Unqualified)]
        public string CurrencyCode { get; set; }

        [XmlElement("Data", Form = XmlSchemaForm.Unqualified, DataType = "date")]
        public DateTime IssueDate { get; set; }

        [XmlElement("Numero", Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string DocumentNumber { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public DatiRitenutaType DatiRitenuta { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public DatiBolloType DatiBollo { get; set; }

        [XmlElement("DatiCassaPrevidenziale", Form = XmlSchemaForm.Unqualified)]
        public DatiCassaPrevidenzialeType[] DatiCassaPrevidenziale { get; set; }

        [XmlElement("ScontoMaggiorazione", Form = XmlSchemaForm.Unqualified)]
        public ScontoMaggiorazioneType[] ScontoMaggiorazione { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public decimal ImportoTotaleDocumento { get; set; }

        [XmlIgnore]
        public bool ImportoTotaleDocumentoSpecified { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public decimal Arrotondamento { get; set; }

        [XmlIgnore]
        public bool ArrotondamentoSpecified { get; set; }

        [XmlElement("Causale", Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string[] Description { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public Art73Type Art73 { get; set; }

        [XmlIgnore]
        public bool Art73Specified { get; set; }
    }

    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public enum DcoumentType
    {
        TD01,
        TD02,
        TD03,
        TD04,
        TD05,
        TD06,
    }

    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public enum Art73Type
    {
        SI,
    }

    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public class DatiGeneraliType
    {
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
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

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public DatiTrasportoType DatiTrasporto { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public FatturaPrincipaleType FatturaPrincipale { get; set; }
    }

    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public class ElectronicInvoiceBody
    {
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public DatiGeneraliType DatiGenerali { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public DatiBeniServiziType DatiBeniServizi { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public DatiVeicoliType DatiVeicoli { get; set; }

        [XmlElement("DatiPagamento", Form = XmlSchemaForm.Unqualified)]
        public DatiPagamentoType[] DatiPagamento { get; set; }

        [XmlElement("Allegati", Form = XmlSchemaForm.Unqualified)]
        public AllegatiType[] Allegati { get; set; }
    }

    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public class DatiAnagraficiTerzoIntermediarioType
    {
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public IdFiscaleType IdFiscaleIVA { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string CodiceFiscale { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public AnagraficaType Anagrafica { get; set; }
    }

    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public class TerzoIntermediarioSoggettoEmittenteType
    {
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public DatiAnagraficiTerzoIntermediarioType DatiAnagrafici { get; set; }
    }

    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public class DatiAnagraficiCessionarioType
    {
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public IdFiscaleType IdFiscaleIVA { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string CodiceFiscale { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public AnagraficaType Anagrafica { get; set; }
    }

    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public class CessionarioCommittenteType
    {
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public DatiAnagraficiCessionarioType DatiAnagrafici { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public Address Sede { get; set; }
    }

    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public class DatiAnagraficiRappresentanteType
    {
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public IdFiscaleType IdFiscaleIVA { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string CodiceFiscale { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public AnagraficaType Anagrafica { get; set; }
    }

    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public class RappresentanteFiscaleType
    {
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public DatiAnagraficiRappresentanteType DatiAnagrafici { get; set; }
    }

    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public class ContattiType
    {
        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string Telefono { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string Fax { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string Email { get; set; }
    }

    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public class IscrizioneREAType
    {
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string Ufficio { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string NumeroREA { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public decimal CapitaleSociale { get; set; }

        [XmlIgnore]
        public bool CapitaleSocialeSpecified { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public SocioUnicoType SocioUnico { get; set; }

        [XmlIgnore]
        public bool SocioUnicoSpecified { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public StatoLiquidazioneType StatoLiquidazione { get; set; }
    }

    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public enum SocioUnicoType
    {
        SU,
        SM,
    }

    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public enum StatoLiquidazioneType
    {
        LS,
        LN,
    }

    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public class DatiAnagraficiCedenteType
    {
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public IdFiscaleType IdFiscaleIVA { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string CodiceFiscale { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public AnagraficaType Anagrafica { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string AlboProfessionale { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string ProvinciaAlbo { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string NumeroIscrizioneAlbo { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "date")]
        public DateTime DataIscrizioneAlbo { get; set; }

        [XmlIgnore]
        public bool DataIscrizioneAlboSpecified { get; set; }

        [XmlElement("RegimeFiscale", Form = XmlSchemaForm.Unqualified)]
        public FiscalRegime FiscalRegime { get; set; }
    }

    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public enum FiscalRegime
    {
        RF01,
        RF02,
        RF03,
        RF04,
        RF05,
        RF06,
        RF07,
        RF08,
        RF09,
        RF10,
        RF11,
        RF12,
        RF13,
        RF14,
        RF15,
        RF16,
        RF17,
        RF19,
        RF18,
    }

    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public class Provider
    {
        [XmlElement("DatiAnagrafici", Form = XmlSchemaForm.Unqualified)]
        public DatiAnagraficiCedenteType IdentificationData { get; set; }

        [XmlElement("Sede", Form = XmlSchemaForm.Unqualified)]
        public Address Address { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public Address StabileOrganizzazione { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public IscrizioneREAType IscrizioneREA { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public ContattiType Contatti { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string RiferimentoAmministrazione { get; set; }
    }

    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public class ContattiTrasmittenteType
    {
        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "normalizedString")]
        public string Telefono { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string Email { get; set; }
    }

    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public enum FileSchemaVersion
    {
        SDI11,
    }

    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public enum SoggettoEmittenteType
    {
        CC,
        TZ,
    }

    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public enum VersioneSchemaType
    {
        [XmlEnum("1.1")]
        Item11,
    }

    [Serializable, XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#"), XmlRoot("Transforms", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public class TransformsType
    {
        [XmlElement("Transform")]
        public TransformType[] Transform { get; set; }
    }

    [Serializable, XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#"), XmlRoot("Manifest", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public class ManifestType
    {
        [XmlElement("Reference")]
        public ReferenceType[] Reference { get; set; }

        [XmlAttribute(DataType = "ID")]
        public string Id { get; set; }
    }

    [Serializable, XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#"), XmlRoot("SignatureProperties", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public class SignaturePropertiesType
    {
        [XmlElement("SignatureProperty")]
        public SignaturePropertyType[] SignatureProperty { get; set; }

        [XmlAttribute(DataType = "ID")]
        public string Id { get; set; }
    }

    [Serializable, XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#"), XmlRoot("SignatureProperty", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public class SignaturePropertyType
    {
        [XmlAnyElement]
        public XmlElement[] Items { get; set; }

        [XmlText]
        public string[] Text { get; set; }

        [XmlAttribute(DataType = "anyURI")]
        public string Target { get; set; }

        [XmlAttribute(DataType = "ID")]
        public string Id { get; set; }
    }
}
