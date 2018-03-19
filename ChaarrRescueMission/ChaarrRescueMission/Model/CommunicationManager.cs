﻿using ChaarrRescueMission.Model.Entity;
using ChaarrRescueMission.Properties;
using RestSharp;
using System.Net;

namespace ChaarrRescueMission.Model
{
    class CommunicationManager
    {
        public string Send(Cargo cargo)
        {
            var client = new RestClient(Resources.CaptionGET);
            var request = CreateRequest(cargo.ToJson());
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return response.Content;
            }
            else
                return response.ErrorMessage;
        }

        private RestRequest CreateRequest(string jsonCargo)
        {
            var request = new RestRequest(Method.GET);
            request.AddHeader(Resources.CaptionCacheControl, Resources.CaptionNoCache);
            request.AddHeader(Resources.CaptionContentType, Resources.CaptionJsonApp);

            request.AddParameter(Resources.CaptionJsonApp, jsonCargo, ParameterType.RequestBody);
            return request;
        }
    }
}