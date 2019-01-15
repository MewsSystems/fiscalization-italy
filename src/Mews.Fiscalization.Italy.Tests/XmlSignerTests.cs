﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using NUnit.Framework;

namespace Mews.Fiscalization.Italy.Tests
{
    [TestFixture]
    public class XmlSignerTests
    {
        [Test]
        public void TestSigning()
        {
            var xml = GetXml();
            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(xml);

            var cert = XmlSigner.GetCertificate("CN=Jan Novák");

            var signedXml = XmlSigner.Sign(xmlDocument, cert).OuterXml;

        }

        private string GetXml()
        {
            return @"<?xml version=""1.0"" encoding=""UTF-8""?>
            <p:FatturaElettronica versione=""1.1"" xmlns:ds=""http://www.w3.org/2000/09/xmldsig#"" xmlns:p=""http://www.fatturapa.gov.it/sdi/fatturapa/v1.1"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">
              <FatturaElettronicaHeader>
                <DatiTrasmissione>
                  <IdTrasmittente>
                    <IdPaese>IT</IdPaese>
                    <IdCodice>01234567890</IdCodice>
                  </IdTrasmittente>
                  <ProgressivoInvio>00001</ProgressivoInvio>
                  <FormatoTrasmissione>SDI11</FormatoTrasmissione>
                  <CodiceDestinatario>AAAAAA</CodiceDestinatario>
                  <ContattiTrasmittente/>
                </DatiTrasmissione>
                <CedentePrestatore>
                  <DatiAnagrafici>
                    <IdFiscaleIVA>
                      <IdPaese>IT</IdPaese>
                      <IdCodice>01234567890</IdCodice>
                    </IdFiscaleIVA>
                    <Anagrafica>
                      <Denominazione>SOCIETA' ALPHA SRL</Denominazione>
                    </Anagrafica>
                    <RegimeFiscale>RF19</RegimeFiscale>
                  </DatiAnagrafici>
                  <Sede>
                    <Indirizzo>VIALE ROMA 543</Indirizzo>
                    <CAP>07100</CAP>
                    <Comune>SASSARI</Comune>
                    <Provincia>SS</Provincia>
                    <Nazione>IT</Nazione>
                  </Sede>
                </CedentePrestatore>
                <CessionarioCommittente>
                  <DatiAnagrafici>
                    <CodiceFiscale>09876543210</CodiceFiscale>
                    <Anagrafica>
                      <Denominazione>AMMINISTRAZIONE BETA</Denominazione>
                    </Anagrafica>
                  </DatiAnagrafici>
                  <Sede>
                    <Indirizzo>VIA TORINO 38-B</Indirizzo>
                    <CAP>00145</CAP>
                    <Comune>ROMA</Comune>
                    <Provincia>RM</Provincia>
                    <Nazione>IT</Nazione>
                  </Sede>
                </CessionarioCommittente>
              </FatturaElettronicaHeader>
              <FatturaElettronicaBody>
                <DatiGenerali>
                  <DatiGeneraliDocumento>
                    <TipoDocumento>TD01</TipoDocumento>
                    <Divisa>EUR</Divisa>
                    <Data>2014-12-18</Data>
                    <Numero>123</Numero>
                    <Causale>LA FATTURA FA RIFERIMENTO AD UNA OPERAZIONE AAAA BBBBBBBBBBBBBBBBBB CCC DDDDDDDDDDDDDDD E FFFFFFFFFFFFFFFFFFFF GGGGGGGGGG HHHHHHH II LLLLLLLLLLLLLLLLL MMM NNNNN OO PPPPPPPPPPP QQQQ RRRR SSSSSSSSSSSSSS</Causale>
                    <Causale>SEGUE DESCRIZIONE CAUSALE NEL CASO IN CUI NON SIANO STATI SUFFICIENTI 200 CARATTERI AAAAAAAAAAA BBBBBBBBBBBBBBBBB</Causale>
                  </DatiGeneraliDocumento>
                  <DatiOrdineAcquisto>
                    <RiferimentoNumeroLinea>1</RiferimentoNumeroLinea>
                    <IdDocumento>66685</IdDocumento>
                    <NumItem>1</NumItem>
                    <CodiceCUP>123abc</CodiceCUP>
                <CodiceCIG>456def</CodiceCIG>
                  </DatiOrdineAcquisto>
                  <DatiContratto>
                <RiferimentoNumeroLinea>1</RiferimentoNumeroLinea>
                <IdDocumento>123</IdDocumento>
                <Data>2012-09-01</Data>
                <NumItem>5</NumItem>
                <CodiceCUP>123abc</CodiceCUP>
                <CodiceCIG>456def</CodiceCIG>
                  </DatiContratto>
                  <DatiConvenzione>
                <RiferimentoNumeroLinea>1</RiferimentoNumeroLinea>
                <IdDocumento>123</IdDocumento>
                <NumItem>5</NumItem>
                <CodiceCUP>123abc</CodiceCUP>
                <CodiceCIG>456def</CodiceCIG>
                  </DatiConvenzione>
                  <DatiRicezione>
                <RiferimentoNumeroLinea>1</RiferimentoNumeroLinea>
                <IdDocumento>123</IdDocumento>
                <NumItem>5</NumItem>
                <CodiceCUP>123abc</CodiceCUP>
                <CodiceCIG>456def</CodiceCIG>
                  </DatiRicezione>
                  <DatiTrasporto>
                <DatiAnagraficiVettore>				
                  <IdFiscaleIVA>
                    <IdPaese>IT</IdPaese>
                    <IdCodice>24681012141</IdCodice>
                  </IdFiscaleIVA>
                      <Anagrafica>
                    <Denominazione>Trasporto spa</Denominazione>
                  </Anagrafica>
                </DatiAnagraficiVettore>
                <DataOraConsegna>2012-10-22T16:46:12.000+02:00</DataOraConsegna>
                  </DatiTrasporto>
                </DatiGenerali>
                <DatiBeniServizi>
                  <DettaglioLinee>
                    <NumeroLinea>1</NumeroLinea>
                    <Descrizione>LA DESCRIZIONE DELLA FORNITURA PUO' SUPERARE I CENTO CARATTERI CHE RAPPRESENTAVANO IL PRECEDENTE LIMITE DIMENSIONALE. TALE LIMITE NELLA NUOVA VERSIONE E' STATO PORTATO A MILLE CARATTERI</Descrizione>
                    <Quantita>5.00</Quantita>
                    <PrezzoUnitario>1.00</PrezzoUnitario>
                    <PrezzoTotale>5.00</PrezzoTotale>
                    <AliquotaIVA>22.00</AliquotaIVA>
                  </DettaglioLinee>
                  <DatiRiepilogo>
                    <AliquotaIVA>22.00</AliquotaIVA>
                    <ImponibileImporto>5.00</ImponibileImporto>
                    <Imposta>1.10</Imposta>
                    <EsigibilitaIVA>I</EsigibilitaIVA>
                  </DatiRiepilogo>
                </DatiBeniServizi>
                <DatiPagamento>
                  <CondizioniPagamento>TP01</CondizioniPagamento>
                  <DettaglioPagamento>
                    <ModalitaPagamento>MP01</ModalitaPagamento>
                    <DataScadenzaPagamento>2015-01-30</DataScadenzaPagamento>
                    <ImportoPagamento>6.10</ImportoPagamento>
                  </DettaglioPagamento>
                </DatiPagamento>
              </FatturaElettronicaBody>
            </p:FatturaElettronica>";
        }
    }
}
