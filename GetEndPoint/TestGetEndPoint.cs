using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyAPITestProject.Model;
using MyAPITestProject.Model.XmlModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Serialization;



namespace MyAPITestProject.GetEndPoint
{
    [TestClass]
    public class TestGetEndPoint
    {

        private string getUrl = "https://reqres.in/api/users/2";


        [TestMethod]
        public void Getmethod()
        {
            //Step 1: to create http client
            HttpClient httpClient = new HttpClient();
            //Step 2 & 3: Create the request & Execute
            httpClient.GetAsync(getUrl);
            httpClient.Dispose();
        }

        [TestMethod]
        public void GetmethodWithUri()
        {
            HttpClient httpClient = new HttpClient();
            Uri geturi = new Uri(getUrl);
            Task<HttpResponseMessage> HttpResponse = httpClient.GetAsync(geturi);
            HttpResponseMessage httpResponseMessage = HttpResponse.Result;
            Console.WriteLine(httpResponseMessage.ToString());
            //To get the response code & Status
            HttpStatusCode statusCode = httpResponseMessage.StatusCode;
            Console.WriteLine("Status Code:==>" + statusCode.ToString());
            Console.WriteLine("Status Code:==>" + (int)statusCode);
            //To get the 
            HttpContent responseContent = httpResponseMessage.Content;
            Task<String> responseData = responseContent.ReadAsStringAsync();
            string data = responseData.Result.ToString();
            Console.WriteLine("Response Content is as below:\n" + data);

            httpClient.Dispose();

        }
        [TestMethod]

        public void GetmethodWithInvalid_Uri()
        {
            HttpClient httpClient = new HttpClient();
            Uri geturi = new Uri(getUrl + "/201");
            Task<HttpResponseMessage> HttpResponse = httpClient.GetAsync(getUrl + "/201");
            HttpResponseMessage httpResponseMessage = HttpResponse.Result;
            Console.WriteLine(httpResponseMessage.ToString());
            HttpStatusCode statusCode = httpResponseMessage.StatusCode;
            Console.WriteLine("Status Code:==>" + statusCode.ToString());
            Console.WriteLine("Status Code:==>" + (int)statusCode);

            HttpContent responseContent = httpResponseMessage.Content;
            Task<String> responseData = responseContent.ReadAsStringAsync();
            string data = responseData.Result.ToString();
            Console.WriteLine("Response Content is as below:\n" + data);

            httpClient.Dispose();

        }

        //[TestMethod]
        //public void GetresponseinJSON()
        //{
        //    HttpClient httpClient = new HttpClient();
        //    HttpRequestHeaders requestHeaders = HttpClient.DefaultRequestHeaders;
        //    requestHeaders.Add("Accept", "application/json");

        //    Task<HttpResponseMessage> HttpResponse = httpClient.GetAsync(getUrl);
        //    HttpResponseMessage httpResponseMessage = HttpResponse.Result;
        //    Console.WriteLine(httpResponseMessage.ToString());

        //    //To get the response code & Status
        //    HttpStatusCode statusCode = httpResponseMessage.StatusCode;
        //    Console.WriteLine("Status Code:==>" + statusCode.ToString());
        //    Console.WriteLine("Status Code:==>" + (int)statusCode);

        //    //To get the 
        //    HttpContent responseContent = httpResponseMessage.Content;
        //    Task<String> responseData = responseContent.ReadAsStringAsync();
        //    string data = responseData.Result.ToString();
        //    Console.WriteLine("Response Content is as below:\n" + data);

        //    httpClient.Dispose();
        //}

        [TestMethod]
        public void GetresponseUsingAsync()
        {
            HttpRequestMessage httpRequesteMessage = new HttpRequestMessage();
            httpRequesteMessage.RequestUri = new Uri(getUrl);
            httpRequesteMessage.Method = HttpMethod.Get;
            httpRequesteMessage.Headers.Add("Accept", "applicatin/json");

            HttpClient httpClient = new HttpClient();
            Task<HttpResponseMessage> httpResponse = httpClient.SendAsync(httpRequesteMessage);

            HttpResponseMessage httpResponseMessage = httpResponse.Result;
            Console.WriteLine(httpResponseMessage.ToString());

            //To get the response code & Status
            HttpStatusCode statusCode = httpResponseMessage.StatusCode;
            Console.WriteLine("Status Code:==>" + statusCode.ToString());
            Console.WriteLine("Status Code:==>" + (int)statusCode);

            //To get the 
            HttpContent responseContent = httpResponseMessage.Content;
            Task<String> responseData = responseContent.ReadAsStringAsync();
            string data = responseData.Result.ToString();
            Console.WriteLine("Response Content is as below:\n" + data);

            httpClient.Dispose();
        }


        [TestMethod]
        public void AlternativeToDispose()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                using (HttpRequestMessage httpRequesteMessage = new HttpRequestMessage())
                {
                    httpRequesteMessage.RequestUri = new Uri(getUrl);
                    httpRequesteMessage.Method = HttpMethod.Get;
                    httpRequesteMessage.Headers.Add("Accept", "applicatin/json");

                    Task<HttpResponseMessage> httpResponse = httpClient.SendAsync(httpRequesteMessage);

                    using (HttpResponseMessage httpResponseMessage = httpResponse.Result)
                    {
                        Console.WriteLine(httpResponseMessage.ToString());

                        //To get the response code & Status
                        HttpStatusCode statusCode = httpResponseMessage.StatusCode;
                        //Console.WriteLine("Status Code:==>" + statusCode.ToString());
                        //Console.WriteLine("Status Code:==>" + (int)statusCode);

                        //To get the 
                        HttpContent responseContent = httpResponseMessage.Content;
                        Task<String> responseData = responseContent.ReadAsStringAsync();
                        string data = responseData.Result.ToString();
                        Console.WriteLine("Response Content is as below:\n" + data);

                        RestResponse restResponse = new RestResponse((int)statusCode, responseData.Result);
                        Console.WriteLine(restResponse);

                    }
                }
            }
        }

        [TestMethod]
        public void TestDeserializationJSONResponse()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                using (HttpRequestMessage httpRequesteMessage = new HttpRequestMessage())
                {
                    httpRequesteMessage.RequestUri = new Uri(getUrl);
                    httpRequesteMessage.Method = HttpMethod.Get;
                    httpRequesteMessage.Headers.Add("Accept", "applicatin/json");

                    Task<HttpResponseMessage> httpResponse = httpClient.SendAsync(httpRequesteMessage);

                    using (HttpResponseMessage httpResponseMessage = httpResponse.Result)
                    {
                        Console.WriteLine(httpResponseMessage.ToString());

                        //To get the response code & Status
                        HttpStatusCode statusCode = httpResponseMessage.StatusCode;
                        //Console.WriteLine("Status Code:==>" + statusCode.ToString());
                        //Console.WriteLine("Status Code:==>" + (int)statusCode);

                        //To get the 
                        HttpContent responseContent = httpResponseMessage.Content;
                        Task<String> responseData = responseContent.ReadAsStringAsync();
                        string data = responseData.Result.ToString();
                        Console.WriteLine("Response Content is as below:\n" + data);

                        RestResponse restResponse = new RestResponse((int)statusCode, responseData.Result);
                        //Console.WriteLine(restResponse);

                        JsonRootObject jsonRootObject = JsonConvert.DeserializeObject<JsonRootObject>(restResponse.ResponseContent);
                        Console.WriteLine(jsonRootObject.ToString());
                    }
                }
            }
        }
        [TestMethod]
        public void DeserializationXmlRespones()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                using (HttpRequestMessage httpRequesteMessage = new HttpRequestMessage())
                {
                    httpRequesteMessage.RequestUri = new Uri(getUrl);
                    httpRequesteMessage.Method = HttpMethod.Get;
                    httpRequesteMessage.Headers.Add("Accept", "applicatin/xml");

                    Task<HttpResponseMessage> httpResponse = httpClient.SendAsync(httpRequesteMessage);

                    using (HttpResponseMessage httpResponseMessage = httpResponse.Result)
                    {
                        Console.WriteLine(httpResponseMessage.ToString());

                        //To get the response code & Status
                        HttpStatusCode statusCode = httpResponseMessage.StatusCode;
                        //Console.WriteLine("Status Code:==>" + statusCode.ToString());
                        //Console.WriteLine("Status Code:==>" + (int)statusCode);

                        //To get the 
                        HttpContent responseContent = httpResponseMessage.Content;
                        Task<String> responseData = responseContent.ReadAsStringAsync();
                        string data = responseData.Result.ToString();
                        Console.WriteLine("Response Content is as below:\n" + data);

                        RestResponse restResponse = new RestResponse((int)statusCode, responseData.Result);
                        //Console.WriteLine(restResponse);

                        JsonRootObject jsonRootObject = JsonConvert.DeserializeObject<JsonRootObject>(restResponse.ResponseContent);
                        Console.WriteLine(jsonRootObject.ToString());

                        //Step1: Create instance of xmlSerialzer class & pass the model type as an parameter to the constroctor of class 
                        XmlSerializer xmlSerializer = new XmlSerializer(typeof(LaptopDetails));

                        //Step2: Create the instance of TextReader to read the response content
                        TextReader textReader = new StringReader(restResponse.ResponseContent);

                        //Step3: Call Deserialize() & pass the instance of the text reader as an argument
                        LaptopDetails xmlData = (LaptopDetails)xmlSerializer.Deserialize(textReader);
                        Console.WriteLine(xmlData.ToString());
                    }
                }
            }


        }

       

    }

    internal class JsonRootObject
    {
    }


}
