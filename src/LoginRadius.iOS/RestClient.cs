using System;
using System.Net;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace LoginRadius.SDK
{
        public enum HttpMethod
        {
                GET,
                POST,
                DELETE,
                PUT
        }

        public class HttpHeader : Dictionary<string, string>
        {
                public WebHeaderCollection ToWebHeaderCollection ()
                {
                        var webheadercollection = new WebHeaderCollection ();

                        if (Count > 0) {
                                foreach (var header in this) {
                                        webheadercollection.Add (header.Key, header.Value);
                                }
                        }

                        return webheadercollection;
                }
        }

        public static class HttpHeaderExtension
        {
                public static HttpHeader ToHttpHeader (this WebHeaderCollection webHeaderCollection)
                {
                        var httpheaders = new HttpHeader ();

                        if (webHeaderCollection.Count > 0) {
                                foreach (var header in webHeaderCollection) {
                                        httpheaders.Add (header.ToString (), webHeaderCollection [header.ToString ()]);
                                }
                        }

                        return httpheaders;
                }
        }

        public class HttpRequestParameter : Dictionary<string, string>
        {
                public override string ToString ()
                {
                        return Count > 0 ? string.Join ("&", this.Select (x => x.Key + "=" + x.Value).ToArray ()) : string.Empty;
                }

                public string ToString (string uri)
                {
                        if (uri.Contains ("?")) {
                                uri = uri + "&" + ToString ();
                        } else {
                                uri = uri + "?" + ToString ();
                        }

                        return uri;
                }
        }

        public class RestClient
        {
                public RestClient ()
                {
                }

                public static string Request (string url, HttpRequestParameter parameter, HttpMethod method)
                {
                        return Request (url, parameter, method, null);
                }

                private static string Request (string url, HttpRequestParameter parameter, HttpMethod method, HttpHeader headers)
                {
                        var _params = string.Empty;

                        if (parameter != null && parameter.Count > 0) {
                                _params = parameter.ToString ();
                        }


                        if (method == HttpMethod.GET) {
                                if (url.Contains ("?")) {
                                        url = url + "&" + _params;
                                } else {
                                        url = url + "?" + _params;
                                }

                                return HttpGet (url, headers);
                        } else {
                                return HttpPost (url, _params, headers);
                        }
                }

                private static string HttpGet (string uri, HttpHeader headers)
                {
                        var req = WebRequest.Create (uri);

                        var resp = req.GetResponse ();

                        if (headers != null) {
                                req.Headers = headers.ToWebHeaderCollection ();
                        }

                        var sr = new StreamReader (resp.GetResponseStream ());

                        return sr.ReadToEnd ().Trim ();
                }

                private static string HttpPost (string uri, string parameters, HttpHeader headers)
                {
                        HttpWebRequest request = null;
                        StreamWriter requestWriter = null;
                        StreamReader responseReader = null;

                        var responseData = "";

                        request = System.Net.WebRequest.Create (uri) as HttpWebRequest;
                        request.Method = "POST";

                        if (headers != null)
                                request.Headers = headers.ToWebHeaderCollection ();

                        request.ContentType = "application/x-www-form-urlencoded";
                        //POST the data.
                        requestWriter = new StreamWriter (request.GetRequestStream ());
                        try {
                                requestWriter.Write (parameters);
                        } catch {
                                throw;
                        } finally {
                                requestWriter.Close ();
                                requestWriter = null;
                        }

                        //Read the response
                        try {
                                responseReader = new StreamReader (request.GetResponse ().GetResponseStream ());
                                responseData = responseReader.ReadToEnd ();
                        } catch {
                                throw;
                        } finally {
                                request.GetResponse ().GetResponseStream ().Close ();
                                responseReader.Close ();
                                responseReader = null;
                        }

                        return responseData;
                }
        }
}

