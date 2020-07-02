using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Net;
using System.IO;

namespace DecryptionBusiness
{
    class clientSoap
    {
        public static void CallWebService(string key, string filename, string content)
        {
            var _url = "http://192.168.43.211:8080/WsJax/WsJax";
            string _action = "\"sendCurrentFile\"";

            XmlDocument soapEnvelopeXml = CreateSoapEnvelope(key, filename, content);
            HttpWebRequest webRequest = CreateWebRequest(_url, _action);
            InsertSoapEnvelopeIntoWebRequest(soapEnvelopeXml, webRequest);

            // begin async call to web request.
            IAsyncResult asyncResult = webRequest.BeginGetResponse(null, null);

            // suspend this thread until call is complete. You might want to
            // do something usefull here like update your UI.
            asyncResult.AsyncWaitHandle.WaitOne();

            // get the response from the completed web request.
            string soapResult;
            using (WebResponse webResponse = webRequest.EndGetResponse(asyncResult))
            { 
                using (StreamReader rd = new StreamReader(webResponse.GetResponseStream()))
                {
                    soapResult = rd.ReadToEnd();
                }
                Console.Write(soapResult);
            }
        }

        private static HttpWebRequest CreateWebRequest(string url, string action)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Headers.Add("SOAPAction", action);
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            return webRequest;
        }

        private static XmlDocument CreateSoapEnvelope(string key, string filename, string content)
        {
            XmlDocument soapEnvelopeDocument = new XmlDocument();
            content = content.Replace("\"", "\\\"");
/*            string xml = String.Format(@"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:ser=""http://servc.t2l3a.com/"">
               <soapenv:Header/>
               <soapenv:Body>
                  <ser:getMessage>
                     <fileName>{0}</fileName>
                     <fileContent>{1}</fileContent>
                     <currentKey>{2}</currentKey>
                  </ser:getMessage>
               </soapenv:Body>
            </soapenv:Envelope>", filename, XmlConvert.EncodeName(content), key);*/
            string xml = String.Format(@"<?xml version=""1.0"" encoding=""UTF-8""?><S:Envelope xmlns:S=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/"">
                                        <SOAP-ENV:Header/>
                                           <S:Body xmlns:ns2=""http://wsJax.payara.fish/"">
                                                <ns2:sendCurrentFile>
                                                     <fileName>{0}</fileName>
                                                     <fileContent>{1}</fileContent>
                                                     <currentKey>{2}</currentKey>
                                                 </ns2:sendCurrentFile>
                                              </S:Body>
                                           </S:Envelope>", filename, XmlConvert.EncodeName(content), key);

            soapEnvelopeDocument.LoadXml(xml);
            return soapEnvelopeDocument;
        }

        private static void InsertSoapEnvelopeIntoWebRequest(XmlDocument soapEnvelopeXml, HttpWebRequest webRequest)
        {
            using (Stream stream = webRequest.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }
        }
    }
}
